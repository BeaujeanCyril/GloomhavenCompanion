using GloomhavenCompanion.ViewModels;

namespace GloomhavenCompanion
{
	public interface IAppStateStorage
	{
		Task SaveCampaignsAsync(List<CampainViewModel> campaigns);
		Task<List<CampainViewModel>> LoadCampaignsAsync();
	}

}
