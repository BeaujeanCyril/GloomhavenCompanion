using System.ComponentModel.DataAnnotations;

namespace GloomhavenCompanion.Data.Model;

public class CampaignScenario
{
  [Key]
  public int Id { get; set; }

  public int CampaignId { get; set; }  // Clé étrangère vers la campagne
  public int ScenarioId { get; set; }  // Clé étrangère vers le scénario

  // Propriétés de navigation
  public Campaign Campaign { get; set; }
  public Scenario Scenario { get; set; }

  // Clé étrangère vers Game, chaque CampaignScenario possède une partie unique
  public int GameId { get; set; }
  public Game Game { get; set; } // Relation un-à-un avec Game
}
