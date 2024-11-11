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

  public async Task<CampaignViewModel> LoadCampaignByCampaignSummary(int id)
  {
    var campaigns = await _dbContext.Campaigns
        .Include(c => c.Players)  // Inclure les joueurs associés à chaque campagne
        .Include(c => c.Scenarios) // Inclure les scénarios associés à chaque campagne
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
      Scenarios = campaign.Scenarios.Select(scenario => new ScenarioViewModel
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
        .Include(c => c.Scenarios) // Inclure les scénarios associés à chaque campagne
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
      Scenarios = campaign.Scenarios.Select(scenario => new ScenarioViewModel
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
      CompanyName = campaign.CompanyName,
      Players = campaign.Players.Select(player => new Player
      {
        Name = player.Name,
        HealthPointsMax = player.HealthPointsMax,
        Coins = player.Coins,
        Xp = player.Xp,
        Deck = new Deck
        {
          Name = player.Deck.Name,
          CardsList = []
        }
      }).ToList(),
      Scenarios = campaign.Scenarios.Select(scenario => new Scenario
      {
        // Remplir les propriétés de Scenario ici
      }).ToList()
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
