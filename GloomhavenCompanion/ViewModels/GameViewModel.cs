namespace GloomhavenCompanion.ViewModels;
public class GameViewModel
{
	public DateTime DateTimeStarted { get; set; } = DateTime.Now;
	public List<PlayerGameViewModel> Players { get; set; } = [];
	public List<RoundViewModel> Rounds { get; set; } = [];
	public DeckViewModel MonsterDeck { get; set; }

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
