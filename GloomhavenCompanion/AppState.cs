using GloomhavenCompanion.ViewModels;
namespace GloomhavenCompanion;

public class AppState
{
  public List<ElementViewModel> Elements { get; private set; }
  public List<CampainViewModel> Campaigns { get; private set; } = [];
  public List<DeckViewModel> Decks { get; set; } = [];
  public DeckViewModel MonsterDeck { get; set; }
  public PlayerViewModel CurrentPlayer { get; set; }
  public CampainViewModel CurrentCampaign { get; set; }
  public ScenarioViewModel CurrentScenario { get; set; } 

  public event Action OnRoundChanged;
  public GameViewModel CurrentGame { get; set; }
  private readonly IAppStateStorage _appStateStorage;

  public event Action OnChange;

  private void NotifyStateChanged() => OnChange?.Invoke();


  public AppState(IAppStateStorage appStateStorage)
  {
    _appStateStorage = appStateStorage;

    CurrentGame = new GameViewModel();
    CurrentGame.AddNewRound();

    GenerateElements();
    CreateDeck("MonsterDeck");
    CurrentPlayer = new PlayerViewModel() { Name = "Monster", Deck = MonsterDeck };

    /*Teams.Add(new TeamViewModel
		{
			CompanyName = "LA compagnie",
			Id = 1,
      Players =
        [
            new PlayerViewModel { Name = "Thomas"},
						new PlayerViewModel { Name = "Cyril"},
						new PlayerViewModel { Name = "Loïc" }
				]
		});*/

    CurrentCampaign = Campaigns.FirstOrDefault();
  }

  private Dictionary<int, ScenarioViewModel> GenerateScenarios()
  {
    Dictionary<int, ScenarioViewModel> Scenarios = [];
    string folderPath = @"C:\Users\cybea\source\repos\GloomhavenCompanion\GloomhavenCompanion\wwwroot\img\Scenarios";

    if (Directory.Exists(folderPath))
    {
      foreach (string filePath in Directory.GetFiles(folderPath, "gh-*.png"))
      {
        string fileName = Path.GetFileNameWithoutExtension(filePath); // ex: "gh-11-12"
        string[] parts = fileName.Split('-'); // Sépare les parties de "gh-11-12"

        if (parts.Length > 1 && parts[0] == "gh")
        {
          // Gestion des scénarios multiples dans un même fichier, ex: "gh-11-12"
          string[] scenarioNumbers = parts[1].Split('_');
          foreach (var numberString in scenarioNumbers)
          {
            if (int.TryParse(numberString, out int scenarioId))
            {
              Scenarios.Add(scenarioId, new ScenarioViewModel
              {
                Id = scenarioId,
                Name = $"Scenario {scenarioId}",
                ImagePath = $"img/Scenarios/{Path.GetFileName(filePath)}"
              });
            }
          }
        }
      }
    }
    else
    {
      Console.WriteLine("Le dossier des images de scénario n'existe pas.");
    }
    return Scenarios;

  }



  public async Task LoadLocalStorage()
  {
    await LoadCampaignsAsync();

  }



  #region Element
  private void GenerateElements()
  {
    Elements =
        [
            new() { Id = 1, Name = "Feu", ImagePath = "img/Elements/FirePicture.png" },
            new() { Id = 2, Name = "Ténèbre", ImagePath = "img/Elements/DarknessPicture.png" },
            new() { Id = 3, Name = "Terre", ImagePath = "img/Elements/EarthPicture.png" },
            new() { Id = 4, Name = "Vent", ImagePath = "img/Elements/WindPicture.png" },
            new() { Id = 5, Name = "Lumière", ImagePath = "img/Elements/LightPicture.png" },
            new() { Id = 6, Name = "Givre", ImagePath = "img/Elements/FrostPicture.png" }
        ];
  }
  #endregion Element

  #region Round

  public void NextRound()
  {
    CurrentGame.AddNewRound();
    OnRoundChanged?.Invoke();
  }
  #endregion Round

  #region Team
  public async Task AddCampaign(CampainViewModel NewCampaign)
  {
    NewCampaign.Scenarios = GenerateScenarios();
    Campaigns.Add(NewCampaign);

    CurrentCampaign = NewCampaign;
    await _appStateStorage.SaveCampaignsAsync(Campaigns);
  }
  // Charger les équipes depuis le storage
  public async Task LoadCampaignsAsync()
  {
    Campaigns = await _appStateStorage.LoadCampaignsAsync();
  }
  #endregion

  #region Player
  public void AddPlayer(PlayerViewModel player)
  {
    CurrentCampaign.AddPlayer(player);
  }
  public void RemovePlayer(PlayerViewModel player)
  {
    CurrentCampaign.RemovePlayer(player);
  }

  public void UpdatePlayer(PlayerViewModel player)
  {
    // Vérifier si l'équipe actuelle est définie
    if (CurrentCampaign != null)
    {
      // Trouver le joueur dans la liste des joueurs de l'équipe actuelle
      var existingPlayer = CurrentCampaign.Players.FirstOrDefault(p => p.Name == player.Name);

      // Si le joueur existe, mettre à jour ses valeurs
      if (existingPlayer != null)
      {
        existingPlayer.Xp = player.Xp;
        existingPlayer.Coins = player.Coins;
        existingPlayer.HealthPoints = player.HealthPoints;
        _appStateStorage.SaveCampaignsAsync(Campaigns);

        NotifyStateChanged(); // Notifier les abonnés
      }
    }
  }


  #endregion Player

  #region Deck

  public void CreateDeck(string name)
  {
    MonsterDeck = new DeckViewModel { Id = GenerateDeckId(), Name = name };
    InitializeDeckCards(MonsterDeck);
    if (!MonsterDeck.IsShuffled)
    {
      MonsterDeck.ShuffleDeck();
      MonsterDeck.IsShuffled = true;
    }
    Decks.Add(MonsterDeck);
  }

  private void InitializeDeckCards(DeckViewModel deck)
  {
    var imageNumbers = Enumerable.Range(1, 20).ToList(); // Générez une liste de 1 à 20

    foreach (var number in imageNumbers)
    {
      bool NeedShuffle = false;
      var imagePath = $@"/img/DeckModifier/Monsters/gh-am-m-{number:D2}.png"; // Format 2 chiffres
      if (number == 19 || number == 20)
      {
        NeedShuffle = true;
      }
      deck.CardsList.Add(new CardViewModel
      {
        Id = number, // Utilise le numéro comme ID
        Value = $"Card {number}", // La valeur peut être personnalisée selon tes besoins
        ImagePath = imagePath, // Chemin dynamique de l'image
        NeedShuffle = NeedShuffle
      });
    }
  }

  private int GenerateDeckId()
  {
    // Logique pour générer un ID unique pour le deck
    return Decks.Count + 1; // Exemple simple d'ID
  }
  #endregion Deck
}