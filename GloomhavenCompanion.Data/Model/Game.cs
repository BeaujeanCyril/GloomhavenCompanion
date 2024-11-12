using System.ComponentModel.DataAnnotations;

namespace GloomhavenCompanion.Data.Model;

public class Game
{
[Key]
public int Id { get; set; }
  public DateTime DateTimeStarted { get; set; } = DateTime.Now;
  public List<Round> Rounds { get; set; } = new List<Round>();
  public Deck MonsterDeck { get; set; }
  public string GameState { get; set; } // Ex: "En cours", "Terminé", "Échec", etc.
  // Propriété de navigation pour représenter la relation inverse avec CampaignScenario
  public CampaignScenario CampaignScenario { get; set; }
  // Relation plusieurs-à-plusieurs avec Player
  public List<PlayerGame> PlayerGames { get; set; } = new List<PlayerGame>();

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
