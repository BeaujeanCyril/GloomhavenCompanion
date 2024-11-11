using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GloomhavenCompanion.Data.Model;
public class Card
{
[Key]
  public int Id { get; set; }
  public string Value { get; set; }
  public string ImagePath { get; set; }
  public bool NeedShuffle { get; set; } = false;

  // Clé étrangère pour Deck
  [ForeignKey("Deck")]
  public int DeckId { get; set; }  // Clé étrangère vers le deck auquel cette carte appartient
  public Deck Deck { get; set; }  // Navigation vers le deck
}