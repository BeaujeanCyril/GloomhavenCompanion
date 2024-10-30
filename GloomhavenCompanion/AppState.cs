﻿using GloomhavenCompanion.Model;
namespace GloomhavenCompanion;

public class AppState
{
  public List<ElementViewModel> Elements { get; private set; }
  public int Round { get; private set; }
  public List<TeamViewModel> Teams { get; private set; } // Liste des équipes

  public AppState()
  {
    Round = 0;

    Elements =
        [
            new() { Id = 1, Name = "Feu", ImagePath = "img/Elements/FirePicture.png" },
            new() { Id = 2, Name = "Ténèbre", ImagePath = "img/Elements/DarknessPicture.png" },
            new() { Id = 3, Name = "Terre", ImagePath = "img/Elements/EarthPicture.png" },
            new() { Id = 4, Name = "Vent", ImagePath = "img/Elements/WindPicture.png" },
            new() { Id = 5, Name = "Lumière", ImagePath = "img/Elements/LightPicture.png" },
            new() { Id = 6, Name = "Givre", ImagePath = "img/Elements/FrostPicture.png" }
        ];

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
