using GloomhavenCompanion.Application.ViewModels;
using GloomhavenCompanion.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace GloomhavenCompanion.Infrastructure;
public class DBAppStateStorage : IAppStateStorage
{
  private readonly GloomhavenCompanionDbContext _dbContext;

  public DBAppStateStorage(GloomhavenCompanionDbContext dbContext)
  {
    _dbContext = dbContext;
  }

  public Task<List<CampaignSummary>> LoadAllCampaignNamesAsync()
  {
    throw new NotImplementedException();
  }

  public async Task<ScenarioViewModel> GetScenarioByIdAsync(int campaignId, int scenarioId)
  {
    try
    {
      // Rechercher la campagne existante par son ID
      var campaign = await _dbContext.Campaigns
          .Include(c => c.CampaignScenarios)
          .ThenInclude(cs => cs.Scenario)
          .FirstOrDefaultAsync(c => c.Id == campaignId);

      if (campaign == null)
        return null; // Si la campagne n'existe pas, retourner null

      // Rechercher le scénario existant dans la base de données
      var scenario = await _dbContext.Scenarios
          .FirstOrDefaultAsync(s => s.Id == scenarioId);

      if (scenario == null)
        return null; // Si le scénario n'existe pas, retourner null

      // Vérifier si ce scénario est déjà lié à la campagne via CampaignScenario
      var campaignScenario = campaign.CampaignScenarios
          .FirstOrDefault(cs => cs.ScenarioId == scenarioId);

      // Si le CampaignScenario n'existe pas, créer un nouveau
      if (campaignScenario == null)
      {


        // Créer une transaction pour assurer la cohérence des inserts
        using (var transaction = await _dbContext.Database.BeginTransactionAsync())
        {
          try
          {
            // Créer un deck MonsterDeck
            Deck deck = new Deck { Name = "MonsterDeck" };

            // Créer un nouveau Game (partie)
            var newGame = new Game
            {
              MonsterDeck = deck,  // Initialiser le MonsterDeck
              GameState = "En cours",  // Initialiser un état de jeu par défaut
            };

            // Sauvegarder d'abord le Game avant d'ajouter la relation avec CampaignScenario
            _dbContext.Games.Add(newGame);
            await _dbContext.SaveChangesAsync();  // Sauvegarder le Game dans la base de données

            int newGameId = newGame.Id;

            // Créer un nouveau CampaignScenario et l'associer à la campagne et au scénario
            campaignScenario = new CampaignScenario
            {
              CampaignId = campaignId,  // Associe la campagne existante
              ScenarioId = scenarioId,  // Associe le scénario existant
            GameId = newGameId,
            };

            // Ajouter le CampaignScenario au DbContext pour qu'il soit persisté
            _dbContext.CampaignScenarios.Add(campaignScenario);
            await _dbContext.SaveChangesAsync(); // Sauvegarder le CampaignScenario et la liaison avec Game

            // Charger les joueurs existants de la base de données
            var players = await _dbContext.Players.ToListAsync();

            // Ajouter chaque joueur au jeu (via PlayerGame)
            foreach (var player in players)
            {
              var playerGame = new PlayerGame
              {
                PlayerId = player.Id,
                GameId = newGame.Id,
                HealthPoints = player.HealthPointsMax, // Initialiser avec les points de vie max
                HealthPointsMax = player.HealthPointsMax,
                Coins = 0, // Initialiser les coins (à ajuster selon la logique)
                Xp = 0,    // Initialiser l'XP (à ajuster selon la logique)
                Effects = new List<Effect>() // Liste d'effets vide pour chaque joueur au début
              };

              // Ajouter chaque PlayerGame au DbContext
              _dbContext.PlayerGames.Add(playerGame);
            }

            // Sauvegarder les PlayerGames
            await _dbContext.SaveChangesAsync();

            // Valider la transaction pour appliquer les changements
            await transaction.CommitAsync();
          }
          catch (Exception)
          {
            // En cas d'erreur, annuler la transaction
            await transaction.RollbackAsync();
            throw;
          }
        }
      }

      // Inclure les PlayerGame et leurs informations sur Player dans Game
      var gameWithPlayers = await _dbContext.Games
          .Include(g => g.PlayerGames)
          .ThenInclude(pg => pg.Player)
          .FirstOrDefaultAsync(g => g.Id == campaignScenario.GameId);

      // Retourner le ScenarioViewModel avec le Game associé, les Players, et les autres détails
      var scenarioViewModel = new ScenarioViewModel
      {
        Id = campaignScenario.Scenario.Id,
        Name = campaignScenario.Scenario.Name,
        ImagePath = campaignScenario.Scenario.ImagePath,
        Game = gameWithPlayers != null ? new GameViewModel
        {
          Id = gameWithPlayers.Id,
          MonsterDeck = new DeckViewModel { }, // Remplir avec les informations nécessaires
          Players = gameWithPlayers.PlayerGames.Select(pg => new PlayerGameViewModel
          {
            Name = pg.Player.Name,
            HealthPoints = pg.HealthPoints,
            HealthPointsMax = pg.HealthPointsMax,
            Coins = pg.Coins,
            Xp = pg.Xp,
            Deck = new DeckViewModel { },  // Remplir avec les informations nécessaires
            Effects = pg.Effects.Select(e => new EffectViewModel { }).ToList()
          }).ToList(),
          GameState = gameWithPlayers.GameState,
          DateTimeStarted = gameWithPlayers.DateTimeStarted
        } : null
      };

      return scenarioViewModel;
    }
    catch (Exception ex)
    {
      Console.WriteLine(ex.Message);
    }

    return null;
  }


  public async Task<CampaignViewModel> LoadCampaignByCampaignSummary(int id)
  {
    var campaigns = await _dbContext.Campaigns
        .Include(c => c.Players)  // Inclure les joueurs associés à chaque campagne
        .Include(c => c.CampaignScenarios) // Inclure les scénarios associés à chaque campagne
        .ToListAsync();  // Récupérer les campagnes de la base de données

    // Mapper les campagnes en CampaignViewModel
    var campaignViewModels = campaigns.Select(campaign => new CampaignViewModel
    {
      Id = campaign.Id,
      CompanyName = campaign.CompanyName,
      Players = campaign.Players.Select(player => new PlayerViewModel
      {
        Name = player.Name,
        HealthPointsMax = player.HealthPointsMax,
        Coins = player.Coins,
        Xp = player.Xp,
        // Si tu as besoin d'autres propriétés, ajoute-les ici
      }).ToList(),
      Scenarios = campaign.CampaignScenarios.Select(scenario => new ScenarioViewModel
      {
        // Mapper les propriétés de Scenario ici
      }).ToList()
    }).ToList();

    return new CampaignViewModel();
  }

  public async Task<List<CampaignViewModel>> LoadCampaignsAsync()
  {
    var campaigns = await _dbContext.Campaigns
        .Include(c => c.Players)  // Inclure les joueurs associés à chaque campagne
        .Include(c => c.CampaignScenarios) // Inclure les scénarios associés à chaque campagne
        .ToListAsync();  // Récupérer les campagnes de la base de données

    // Mapper les campagnes en CampaignViewModel
    var campaignViewModels = campaigns.Select(campaign => new CampaignViewModel
    {
      Id = campaign.Id,
      CompanyName = campaign.CompanyName,
      Players = campaign.Players.Select(player => new PlayerViewModel
      {
        Name = player.Name,
        HealthPointsMax = player.HealthPointsMax,
        Coins = player.Coins,
        Xp = player.Xp,
        // Si tu as besoin d'autres propriétés, ajoute-les ici
      }).ToList(),
      Scenarios = campaign.CampaignScenarios.Select(scenario => new ScenarioViewModel
      {
        // Mapper les propriétés de Scenario ici
      }).ToList()
    }).ToList();

    return campaignViewModels;
  }


  public async Task SaveCampaignAsync(CampaignViewModel campaign)
  {
    // Convertir le ViewModel en modèle de données
    var campaignEntity = new Campaign
    {
      CompanyName = campaign.CompanyName ?? throw new ArgumentNullException(nameof(campaign.CompanyName)),
      Players = campaign.Players?.Select(player => new Player
      {
        Name = player.Name ?? throw new ArgumentNullException(nameof(player.Name)),
        HealthPointsMax = player.HealthPointsMax,
        Coins = player.Coins,
        Xp = player.Xp,
        Deck = player.Deck != null ? new Deck
        {
          Name = player.Deck.Name ?? throw new ArgumentNullException(nameof(player.Deck.Name)),
          CardsList = new List<Card>()
        } : null
      }).ToList(),

    };

    // Ajouter la campagne à la base de données
    await _dbContext.Campaigns.AddAsync(campaignEntity);
    await _dbContext.SaveChangesAsync();
  }

  public async Task SaveCampaignsAsync(List<CampaignViewModel> campaigns)
  {
    throw new NotImplementedException();
  }

  public Task UpdateCampaign(CampaignSummary existingCampaign)
  {
    throw new NotImplementedException();
  }
}
