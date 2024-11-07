namespace GloomhavenCompanion.ViewModels
{
	public class ScenarioViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = "";
		public bool IsFinished { get; set; } = false;
		public string ImagePath { get; set; }
	}
}
