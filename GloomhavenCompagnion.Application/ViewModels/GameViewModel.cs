namespace GloomhavenCompanion.Application.ViewModels;
public class GameViewModel
{
public int Id { get; set; }
	public DateTime DateTimeStarted { get; set; } = DateTime.Now;
	public List<PlayerGameViewModel> Players { get; set; } = [];
	public List<RoundViewModel> Rounds { get; set; } = [];
	public DeckViewModel MonsterDeck { get; set; }
  public string GameState { get; set; } // Ex: "En cours", "Terminé", "Échec", etc.
                                        // Propriété de navigation pour représenter la relation inverse avec CampaignScenario


  public void AddNewRound()
	{
		Rounds.Add(new RoundViewModel
		{
			RoundNumber = Rounds.Count + 1,
			DateTime = DateTime.Now
		});
	}

	public RoundViewModel CurrentRound()
	{
		if (Rounds.Count == 0)
		{
			Rounds.Add(new RoundViewModel { RoundNumber = 1, DateTime = DateTime.Now });
		}
		return Rounds.Last();
	}

	public void InitializePlayersForGame(List<PlayerViewModel> globalPlayers)
	{
		Players = globalPlayers.Select(p => new PlayerGameViewModel(p)).ToList();
	}
}
