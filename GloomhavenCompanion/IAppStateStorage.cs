using GloomhavenCompanion.ViewModels;

namespace GloomhavenCompanion
{
	public interface IAppStateStorage
	{
		Task SaveCampaignsAsync(List<CampaignViewModel> campaigns);
		Task SaveCampaignAsync(CampaignViewModel campaign);
		Task<List<CampaignSummary>> LoadAllCampaignNamesAsync();
		Task<CampaignViewModel> LoadCampaignByCampaignSummary(string companyName);
		Task<List<CampaignViewModel>> LoadCampaignsAsync();
    Task UpdateCampaign(CampaignSummary existingCampaign);
  }

}
