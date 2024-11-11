using System.ComponentModel.DataAnnotations;

namespace GloomhavenCompanion.Data.Model;
public class Player
{
[Key]
  public int Id { get; set; }
  public string Name { get; set; }
  public int HealthPointsMax { get; set; }
  public int Coins { get; set; } = 0;
  public int Xp { get; set; } = 0;
  public Deck Deck { get; set; } = new Deck();

  public List<Effect> Effects { get; set; } = [];


  // Définir la relation avec Deck
  public int DeckId { get; set; } // Clé étrangère pour Deck

  // Relation avec campaign
  public int CampaignId { get; set; }
  public Campaign Campaign { get; set; }
}