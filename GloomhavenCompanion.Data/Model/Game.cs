using System.ComponentModel.DataAnnotations;

namespace GloomhavenCompanion.Data.Model;

public class Game
{
[Key]
public int Id { get; set; }
  public DateTime DateTimeStarted { get; set; } = DateTime.Now;
  public List<Player> Players { get; set; } = [];
  public List<Round> Rounds { get; set; } = [];
  public Deck MonsterDeck { get; set; }

  public void AddNewRound()
  {
    Rounds.Add(new Round
    {
      RoundNumber = Rounds.Count + 1,
      DateTime = DateTime.Now
    });
  }

  public Round CurrentRound()
  {
    if (Rounds.Count == 0)
    {
      Rounds.Add(new Round { RoundNumber = 1, DateTime = DateTime.Now });
    }
    return Rounds.Last();
  }
}
