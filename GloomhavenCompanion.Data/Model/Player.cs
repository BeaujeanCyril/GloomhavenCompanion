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
  public Deck Deck { get; set; }

  public List<Effect> Effects { get; set; } = [];


  // Définir la relation avec Deck
  public int DeckId { get; set; } // Clé étrangère pour Deck

  // Relation avec campaign
  public int CampaignId { get; set; }
  public Campaign Campaign { get; set; }


  // Relation avec Game (relation plusieurs-à-plusieurs via une table de jonction)
  public List<PlayerGame> PlayerGames { get; set; } = new List<PlayerGame>();
}