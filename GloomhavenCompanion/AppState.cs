﻿using GloomhavenCompanion.Application.ViewModels;
using GloomhavenCompanion.Data.Model;
using Microsoft.EntityFrameworkCore;
namespace GloomhavenCompanion;

public class AppState
{
  public List<ElementViewModel> Elements { get; private set; }
  public List<CampaignViewModel> Campaigns { get; private set; } = [];

  public PlayerViewModel CurrentPlayer { get; set; }
  public CampaignViewModel CurrentCampaign { get; set; }
  public ScenarioViewModel CurrentScenario { get; set; }
  public event Action OnRoundChanged;
  public GameViewModel CurrentGame { get; set; }
  public List<ScenarioViewModel> scenarios { get; private set; }

  public List<CampaignSummary> CampainSummary { get; private set; }

  private readonly IAppStateStorage _appStateStorage;
  public event Action OnChange;
  private void NotifyStateChanged() => OnChange?.Invoke();

  public AppState(IAppStateStorage appStateStorage)
  {
    _appStateStorage = appStateStorage;
    GenerateElements();
    GenerateScenarios();
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

  #region Campaign
  public async Task AddCampaign(CampaignViewModel NewCampaign)
  {
    Campaigns.Add(NewCampaign);

    CurrentCampaign = NewCampaign;
    await _appStateStorage.SaveCampaignAsync(NewCampaign);
  }

  public async Task LoadCampaignSummariesAsync()
  {
    CampainSummary = await _appStateStorage.LoadAllCampaignNamesAsync();
    //Campaigns = await _appStateStorage.LoadCampaignsAsync();
    //CurrentCampaign = Campaigns[0];
  }

  public async Task LoadCampaignsAsync()
  {
    Campaigns = await _appStateStorage.LoadCampaignsAsync();
  }

  public void ResumeGame(CampaignViewModel campaign)
  {
    CurrentCampaign = campaign;
  }
  public async Task LoadCampaignByCampaignSummaryAsync(Campaign campaign)
  {
    CurrentCampaign = await _appStateStorage.LoadCampaignByCampaignSummary(campaign.Id);
    //Campaigns = await _appStateStorage.LoadCampaignsAsync();
    //CurrentCampaign = Campaigns[0];
  }
  public async Task UpdateCampaignAsync(CampaignViewModel updatedCampaign)
  {
      await _appStateStorage.UpdateCampaign(updatedCampaign);
      NotifyStateChanged();
    
    await Task.CompletedTask;
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

  public void UpdatePlayerAfterGame(PlayerViewModel player)
  {
    if (CurrentCampaign != null)
    {
      var existingPlayer = CurrentCampaign.Players.FirstOrDefault(p => p.Name == player.Name);
      if (existingPlayer != null)
      {
        existingPlayer.Xp = player.Xp;
        existingPlayer.Coins = player.Coins;
        _appStateStorage.SaveCampaignsAsync(Campaigns);
        NotifyStateChanged(); // Notifier les abonnés
      }
    }
  }

  public async Task UpdatePlayerDuringGame(PlayerGameViewModel player)
  {
    if (CurrentCampaign != null && CurrentScenario != null)
    {
      // Localiser le scénario dans la liste des scénarios de la campagne actuelle
      var scenario = CurrentCampaign.Scenarios.FirstOrDefault(s => s.Id == CurrentScenario.Id);
      if (scenario != null && scenario.Game != null)
      {
        // Localiser le joueur à mettre à jour dans la liste des joueurs du jeu
        var existingPlayer = scenario.Game.Players.FirstOrDefault(p => p.Name == player.Name);
        if (existingPlayer != null)
        {
          // Mettre à jour les propriétés du joueur
          existingPlayer.Xp = player.Xp;
          existingPlayer.Coins = player.Coins;
          existingPlayer.HealthPoints = player.HealthPoints;

          // Sauvegarder l'état de la campagne complète, incluant les modifications de Game
          await _appStateStorage.SaveCampaignAsync(CurrentCampaign);

          // Notifier les abonnés des changements
          NotifyStateChanged();
        }
      }
    }
  }


  #endregion Player

  #region Deck

  public DeckViewModel CreateDeck(string name)
  {
    var MonsterDeck = new DeckViewModel { Id = CurrentCampaign.Players.Count + 1, Name = name };
    InitializeDeckCards(MonsterDeck);
    if (!MonsterDeck.IsShuffled)
    {
      MonsterDeck.ShuffleDeck();
      MonsterDeck.IsShuffled = true;
    }
    return MonsterDeck;
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

  /*	private int GenerateDeckId()
    {
      // Logique pour générer un ID unique pour le deck
      return Decks.Count + 1; // Exemple simple d'ID
    }*/
  #endregion Deck

  #region Scenario
  private void GenerateScenarios()
  {
    string folderPath = Path.Combine("wwwroot", "img", "Scenarios");

    scenarios = new List<ScenarioViewModel>();

    if (Directory.Exists(folderPath))
    {
      foreach (string filePath in Directory.GetFiles(folderPath, "gh-*.png"))
      {
        string fileName = Path.GetFileNameWithoutExtension(filePath); // ex: "gh-11-12"
        string[] parts = fileName.Split('-'); // Sépare "gh" et "11-12" (ou plus)

        if (parts.Length > 1 && parts[0] == "gh")
        {
          // Boucle sur chaque scénario à partir de l'index 1
          for (int i = 1; i < parts.Length; i++)
          {
            if (int.TryParse(parts[i], out int scenarioId))
            {
              // Vérifie si le scénario existe déjà dans la liste
              if (!scenarios.Any(s => s.Id == scenarioId))
              {
                // Ajoute le scénario à la liste avec la même image
                scenarios.Add(new ScenarioViewModel
                {
                  Id = scenarioId,
                  Name = $"Scenario {scenarioId}",
                  ImagePath = $"img/Scenarios/{Path.GetFileName(filePath)}",
                });
              }
            }
          }
        }
      }
    }
    else
    {
      Console.WriteLine("Le dossier des images de scénario n'existe pas.");
    }

  }


  public async Task LoadScenario(int scenarioId)
  {
    // Vérifie si une campagne est en cours
    if (CurrentCampaign == null)
      return;

    // Recherche le scénario dans la liste de la campagne actuelle
    var scenario = CurrentCampaign.Scenarios.FirstOrDefault(s => s.Id == scenarioId);

    // Si le scénario n'est pas encore chargé dans la campagne, on le récupère
    if (scenario == null)
    {
      // Charger le scénario depuis la base de données
      scenario = await _appStateStorage.GetScenarioByIdAsync(CurrentCampaign.Id, scenarioId);

      if (scenario == null)
      {
        // Le scénario n'existe pas en base de données
        Console.WriteLine($"Scénario {scenarioId} introuvable.");
        return;
      }

      // Ajoute le scénario chargé à la campagne
      CurrentCampaign.Scenarios.Add(scenario);
    }

    // Assigne le scénario actuel
    CurrentScenario = scenario;

    // Initialise le jeu si nécessaire
    if (CurrentScenario.Game != null)
    {
      CurrentGame = CurrentScenario.Game;
    }
    else
    {
      CurrentGame = new GameViewModel
      {
        MonsterDeck = CreateDeck("MonsterDeck")
      };
      CurrentGame.InitializePlayersForGame(CurrentCampaign.Players);
      CurrentScenario.Game = CurrentGame;
    }

    await Task.CompletedTask; // Conserve la signature asynchrone
  }




  #endregion
}