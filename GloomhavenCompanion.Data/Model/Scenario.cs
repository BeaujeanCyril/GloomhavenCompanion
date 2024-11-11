using System.ComponentModel.DataAnnotations;

namespace GloomhavenCompanion.Data.Model;

public class Scenario
{
  [Key]
  public int Id { get; set; }
  public string Name { get; set; } = "";
  public string ImagePath { get; set; } = "";

  public ICollection<CampaignScenario> CampaignScenarios { get; set; }
}
