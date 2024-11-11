using System.ComponentModel.DataAnnotations;

namespace GloomhavenCompanion.Data.Model;

public class CampaignScenario
{

[Key]
  public int Id { get; set; }

  public int CampaignId { get; set; }  // Clé étrangère vers la campagne
  public int ScenarioId { get; set; }  // Clé étrangère vers le scénario
  public bool IsFinished { get; set; }
  public string GameState { get; set; } // Ex: "En cours", "Terminé", "Échec", etc.

  public Campaign Campaign { get; set; }
  public Scenario Scenario { get; set; }

}
