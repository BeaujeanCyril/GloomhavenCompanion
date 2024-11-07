using System.ComponentModel.DataAnnotations;

namespace GloomhavenCompanion.ViewModels
{
	public class CampainViewModel
	{
		public int Id { get; set; }

		[Required(ErrorMessage = "Le nom de la compagnie est requis")]

		public string CompanyName { get; set; }

		[Required(ErrorMessage = "Le nombre de joueurs est requis")]
		[Range(1, int.MaxValue, ErrorMessage = "Une équipe doit être constituée de 1 à 4 joueurs max")]
		public List<PlayerViewModel> Players { get; set; }
public Dictionary<int, ScenarioViewModel> Scenarios { get; set; }

		public void AddPlayer(PlayerViewModel player) { Players.Add(player); }
		public void RemovePlayer(PlayerViewModel player) { Players.Remove(player); }
	}
}