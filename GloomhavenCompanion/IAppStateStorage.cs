using GloomhavenCompanion.ViewModels;

namespace GloomhavenCompanion
{
	public interface IAppStateStorage
	{
		Task SaveTeamsAsync(List<TeamViewModel> teams);
		Task<List<TeamViewModel>> LoadTeamsAsync();
	}

}
