using GloomhavenCompanion.ViewModels;
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
	public List<CampaignSummary> CampainSummary { get; private set; }

	private readonly IAppStateStorage _appStateStorage;
	public event Action OnChange;
	private void NotifyStateChanged() => OnChange?.Invoke();

	public AppState(IAppStateStorage appStateStorage)
	{
		_appStateStorage = appStateStorage;
		GenerateElements();
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
		NewCampaign.Scenarios = GenerateScenarios();
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

	public async Task LoadCampaignByCampaignSummaryAsync(CampaignSummary campaign)
	{
		CurrentCampaign = await _appStateStorage.LoadCampaignByCampaignSummary(campaign.CompanyName);
		//Campaigns = await _appStateStorage.LoadCampaignsAsync();
		//CurrentCampaign = Campaigns[0];
	}
	public async Task UpdateCampaignAsync(CampaignSummary updatedCampaign)
	{
		// Logique pour mettre à jour la campagne, par exemple en appelant une API ou en mettant à jour une base de données.
		// Exemple simplifié :
		var existingCampaign = CampainSummary.FirstOrDefault(c => c.CompanyName == updatedCampaign.CompanyName);
		if (existingCampaign != null)
		{
			existingCampaign.CompanyName = updatedCampaign.CompanyName;
			existingCampaign.Players = updatedCampaign.Players;
			await _appStateStorage.UpdateCampaign(existingCampaign);
			// Notifiez les abonnés que l'état a changé
			NotifyStateChanged();
		}
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
			// Localiser le jeu dans le scénario de la campagne actuelle
			var scenario = CurrentCampaign.Scenarios.FirstOrDefault(s => s.Key == CurrentScenario.Id);
			if (scenario.Value != null && scenario.Value.Game != null)
			{
				// Localiser le joueur à mettre à jour dans le jeu
				var existingPlayer = scenario.Value.Game.Players.FirstOrDefault(p => p.Name == player.Name);
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
		var MonsterDeck = new DeckViewModel { Id = CurrentCampaign.Players.Count+1, Name = name };
		InitializeDeckCards(MonsterDeck);
		if (!MonsterDeck.IsShuffled)
		{
			MonsterDeck.ShuffleDeck();
			MonsterDeck.IsShuffled = true;
		}
		return MonsterDeck ;
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
	private Dictionary<int, ScenarioViewModel> GenerateScenarios()
	{
		string folderPath = Path.Combine("wwwroot", "img", "Scenarios");

		Dictionary<int, ScenarioViewModel> Scenarios = [];

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
							// Ajoute chaque scénario avec la même image
							if (!Scenarios.ContainsKey(scenarioId))
							{
								Scenarios.Add(scenarioId, new ScenarioViewModel
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
		return Scenarios;
	}


	public async Task LoadScenario(int scenarioId)
	{
		// Logique existante...
		if (CurrentCampaign != null)
		{
			if (CurrentCampaign.Scenarios.ContainsKey(scenarioId))
			{
				CurrentScenario = CurrentCampaign.Scenarios[scenarioId];
				if (CurrentScenario.Game != null)
				{
					CurrentGame = CurrentScenario.Game;
				}
				else
				{
					CurrentGame = new GameViewModel();
					CurrentGame.MonsterDeck = CreateDeck("MonsterDeck");
					CurrentGame.InitializePlayersForGame(CurrentCampaign.Players);
					CurrentScenario.Game = CurrentGame;
				}
			}
		}
		// Tu peux ajouter un délai ou un appel asynchrone ici si nécessaire
		await Task.CompletedTask; // Cela permet de respecter la signature async sans réellement être asynchrone
	}


	#endregion
}