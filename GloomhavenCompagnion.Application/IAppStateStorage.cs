using GloomhavenCompanion.Application.ViewModels;

namespace GloomhavenCompanion
{
	public interface IAppStateStorage
	{
		Task SaveCampaignsAsync(List<CampaignViewModel> campaigns);
		Task SaveCampaignAsync(CampaignViewModel campaign);
		Task<List<CampaignSummary>> LoadAllCampaignNamesAsync();
		Task<CampaignViewModel> LoadCampaignByCampaignSummary(int id);
		Task<List<CampaignViewModel>> LoadCampaignsAsync();
    Task UpdateCampaign(CampaignSummary existingCampaign);
    Task<ScenarioViewModel> GetScenarioByIdAsync(int campaignId, int scenarioId);

  }

}
