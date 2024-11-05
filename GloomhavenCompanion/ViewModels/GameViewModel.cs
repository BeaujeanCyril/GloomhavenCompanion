namespace GloomhavenCompanion.ViewModels
{
	public class GameViewModel
	{
		public DateTime DateTimeStarted { get; set; } = DateTime.Now;
		public List<RoundViewModel> Rounds { get; set; }= new List<RoundViewModel>();

		public void AddNewRound()
		{
			Rounds.Add(new RoundViewModel
			{
				RoundNumber = Rounds.Count + 1,
				DateTime = DateTime.Now
			});
		}

		public RoundViewModel CurrentRound(){
			return Rounds.Last();
		}
	}
}
