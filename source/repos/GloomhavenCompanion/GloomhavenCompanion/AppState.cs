using GloomhavenCompanion.Model;
namespace GloomhavenCompanion;

public class AppState
{
  public List<ElementViewModel> Elements { get; private set; }
  public int Round { get; private set; }
  public List<TeamViewModel> Teams { get; private set; } // Liste des équipes

  public AppState()
  {
    Round = 0;

    Elements = new List<ElementViewModel>
        {
            new() { Id = 1, Name = "Feu", ImagePath = "img/FirePicture.png" },
            new() { Id = 2, Name = "Ténèbre", ImagePath = "img/DarknessPicture.png" },
            new() { Id = 3, Name = "Terre", ImagePath = "img/EarthPicture.png" },
            new() { Id = 4, Name = "Vent", ImagePath = "img/WindPicture.png" },
            new() { Id = 5, Name = "Lumière", ImagePath = "img/LightPicture.png" },
            new() { Id = 6, Name = "Givre", ImagePath = "img/FrostPicture.png" }
        };

    Teams = []; // Initialise la liste des équipes
  }

  public void NextRound()
  {
    Round++;
  }

  // Méthode pour ajouter une équipe
  public void AddTeam(TeamViewModel team)
  {
    Teams.Add(team);
  }
}
