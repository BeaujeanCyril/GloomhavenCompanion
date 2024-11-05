namespace GloomhavenCompanion.ViewModels
{
	public class RoundViewModel
	{

		public int RoundNumber { get; set; }
		public DateTime DateTime { get; set; }

		public string Display => $"Round {RoundNumber}: {DateTime:HH:mm}";
	}
}
