using System.ComponentModel.DataAnnotations;
namespace GloomhavenCompanion.Application.ViewModels;

public class CampaignViewModel
{
  public int Id { get; set; }

  [Required(ErrorMessage = "Le nom de la compagnie est requis")]
  public string CompanyName { get; set; }

  [Required(ErrorMessage = "Le nombre de joueurs est requis")]
  [Range(1, int.MaxValue, ErrorMessage = "Une équipe doit être constituée de 1 à 4 joueurs max")]
  public List<PlayerViewModel> Players { get; set; } = new List<PlayerViewModel>(); // Initialisation de Players
  public List<ScenarioViewModel> Scenarios { get; set; } = new List<ScenarioViewModel>(); // Initialisation de Scenarios

  public void AddPlayer(PlayerViewModel player) { Players.Add(player); }
  public void RemovePlayer(PlayerViewModel player) { Players.Remove(player); }
}