using System.ComponentModel.DataAnnotations;

namespace GloomhavenCompanion.Data.Model
{
  public class Campaign
  {
[Key]
    public int Id { get; set; }

    [Required(ErrorMessage = "Le nom de la compagnie est requis")]
    public string CompanyName { get; set; }

    [Required(ErrorMessage = "Le nombre de joueurs est requis")]
    [Range(1, int.MaxValue, ErrorMessage = "Une équipe doit être constituée de 1 à 4 joueurs max")]
    public List<Player> Players { get; set; }
    public List<Scenario> Scenarios { get; set; }


    // Propriété de navigation
    public ICollection<CampaignScenario> CampaignScenarios { get; set; }



    public void AddPlayer(Player player) { Players.Add(player); }
    public void RemovePlayer(Player player) { Players.Remove(player); }
  }
}
