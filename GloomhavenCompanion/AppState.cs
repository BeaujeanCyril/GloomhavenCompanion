using GloomhavenCompanion.ViewModels;
namespace GloomhavenCompanion;

public class AppState
{
  public List<ElementViewModel> Elements { get; private set; }
  public List<TeamViewModel> Teams { get; private set; } = [];
  public List<DeckViewModel> Decks { get; set; } = [];
  public DeckViewModel MonsterDeck { get; set; }
  public PlayerViewModel CurrentPlayer { get; set; }
  public TeamViewModel CurrentTeam { get; set; }

  public event Action OnRoundChanged;
  public GameViewModel CurrentGame { get; set; }

  public AppState()
  {

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

    CurrentTeam = Teams.FirstOrDefault();
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

  #region Team&Player
  public void AddTeam(TeamViewModel team)
  {
    Teams.Add(team);
    CurrentTeam = team;
  }

  public void AddPlayer(PlayerViewModel player)
  {
    CurrentTeam.AddPlayer(player);
  }
  public void RemovePlayer(PlayerViewModel player)
  {
    CurrentTeam.RemovePlayer(player);
  }

  public void UpdatePlayer(PlayerViewModel player)
  {
    // Vérifier si l'équipe actuelle est définie
    if (CurrentTeam != null)
    {
      // Trouver le joueur dans la liste des joueurs de l'équipe actuelle
      var existingPlayer = CurrentTeam.Players.FirstOrDefault(p => p.Name == player.Name);

      // Si le joueur existe, mettre à jour ses valeurs
      if (existingPlayer != null)
      {
        existingPlayer.Xp = player.Xp;
        existingPlayer.Coins = player.Coins;
        existingPlayer.HealthPoints = player.HealthPoints;
      }
    }
  }


  #endregion Team

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