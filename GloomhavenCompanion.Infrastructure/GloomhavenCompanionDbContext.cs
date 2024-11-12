using Microsoft.EntityFrameworkCore;
using GloomhavenCompanion.Data.Model;
using GloomhavenCompanion.Application.ViewModels;
using System.IO;

namespace GloomhavenCompanion.Infrastructure
{
  public class GloomhavenCompanionDbContext : DbContext  // Hérite de DbContext
  {
    public GloomhavenCompanionDbContext(DbContextOptions<GloomhavenCompanionDbContext> options)
        : base(options)
    { }

    public DbSet<Campaign> Campaigns { get; set; }
    public DbSet<Player> Players { get; set; }
    public DbSet<Effect> Effects { get; set; }
    public DbSet<Scenario> Scenarios { get; set; }
    public DbSet<CampaignScenario> CampaignScenarios { get; set; }
    public DbSet<PlayerGame> PlayerGames { get; set; }

    public DbSet<Game> Games { get; set; }
    public DbSet<Round> Rounds { get; set; }
    public DbSet<Deck> Decks { get; set; }
    public DbSet<Card> Cards { get; set; }
    public DbSet<Element> Elements { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<CampaignScenario>()
           .HasOne(cs => cs.Campaign)
           .WithMany(c => c.CampaignScenarios) // Assurez-vous que Campaign a une collection CampaignScenarios
           .HasForeignKey(cs => cs.CampaignId);

      modelBuilder.Entity<CampaignScenario>()
          .HasOne(cs => cs.Scenario)
          .WithMany(s => s.CampaignScenarios) // Assurez-vous que Scenario a une collection CampaignScenarios
          .HasForeignKey(cs => cs.ScenarioId);

      // Définir une clé composite pour PlayerGame
      modelBuilder.Entity<PlayerGame>()
          .HasKey(pg => new { pg.PlayerId, pg.GameId });




      // Ajouter des données fixes pour Elements si elles n'existent pas déjà
      AddElementIfNotExists(modelBuilder);

      // Ajouter des scénarios s'ils n'existent pas déjà
      GenerateScenarios(modelBuilder);
    }

    // Vérifier si l'élément existe déjà avant d'ajouter
    private void AddElementIfNotExists(ModelBuilder modelBuilder)
    {
      var existingElements = modelBuilder.Model.FindEntityType(typeof(Element))
          .GetSeedData()
          .Select(e => (string)e.GetType().GetProperty("Name").GetValue(e))
          .ToList();

      var elementsToAdd = new List<Element>
            {
                new Element { Id = 1, Name = "Feu", ImagePath = "img/Elements/FirePicture.png" },
                new Element { Id = 2, Name = "Ténèbre", ImagePath = "img/Elements/DarknessPicture.png" },
                new Element { Id = 3, Name = "Terre", ImagePath = "img/Elements/EarthPicture.png" },
                new Element { Id = 4, Name = "Vent", ImagePath = "img/Elements/WindPicture.png" },
                new Element { Id = 5, Name = "Lumière", ImagePath = "img/Elements/LightPicture.png" },
                new Element { Id = 6, Name = "Givre", ImagePath = "img/Elements/FrostPicture.png" }
            };

      foreach (var element in elementsToAdd)
      {
        if (!existingElements.Contains(element.Name))
        {
          modelBuilder.Entity<Element>().HasData(element);
        }
      }
    }

    private void GenerateScenarios(ModelBuilder modelBuilder)
    {
      // Vérifie si la table 'Scenario' est vide
      var existingScenarios = modelBuilder.Model.FindEntityType(typeof(Scenario))
                                                 .GetSeedData()
                                                 .ToList();

      // Si la table Scenario est vide (aucune donnée), on peut ajouter les scénarios
      if (!existingScenarios.Any())
      {
        string folderPath = Path.Combine("wwwroot", "img", "Scenarios");

        if (Directory.Exists(folderPath))
        {
          foreach (string filePath in Directory.GetFiles(folderPath, "gh-*.png"))
          {
            string fileName = Path.GetFileNameWithoutExtension(filePath);
            string[] parts = fileName.Split('-');

            if (parts.Length > 1 && parts[0] == "gh")
            {
              for (int i = 1; i < parts.Length; i++)
              {
                if (int.TryParse(parts[i], out int scenarioId))
                {
                  // Ajouter le scénario à la base de données
                  modelBuilder.Entity<Scenario>().HasData(new Scenario
                  {
                    Id = scenarioId,
                    Name = $"Scenario {scenarioId}",
                    ImagePath = $"img/Scenarios/{Path.GetFileName(filePath)}"
                  });
                }
              }
            }
          }
        }
        else
        {
          Console.WriteLine("Le dossier des images de scénario n'existe pas.");
        }
      }
      else
      {
        // La table Scenario contient déjà des données, donc rien à ajouter
        Console.WriteLine("La table des scénarios contient déjà des données. Aucune insertion effectuée.");
      }
    }

  }
}
