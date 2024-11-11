using System.ComponentModel.DataAnnotations;

namespace GloomhavenCompanion.Data.Model;

public class Round
{
[Key]
  public int Id { get; set; }  // Id unique pour chaque round
  public int RoundNumber { get; set; }
  public DateTime DateTime { get; set; }

  public string Display => $"Round {RoundNumber}: {DateTime:HH:mm}";
}
