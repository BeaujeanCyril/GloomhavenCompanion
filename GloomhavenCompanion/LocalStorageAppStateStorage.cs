namespace GloomhavenCompanion;

using Blazored.LocalStorage;
using GloomhavenCompanion.Application.ViewModels;
using System.Text.Json;


public class LocalStorageAppStateStorage : IAppStateStorage
{
	private readonly ILocalStorageService _localStorageService;

	public LocalStorageAppStateStorage(ILocalStorageService localStorageService)
	{
		_localStorageService = localStorageService;
	}

	public async Task SaveCampaignsAsync(List<CampaignViewModel> campaigns)
	{
		var serializedCampaings = JsonSerializer.Serialize(campaigns);
		await _localStorageService.SetItemAsync("Campaigns", serializedCampaings);
	}

	public async Task SaveCampaignAsync(CampaignViewModel campaign)
	{
		var serializedCampaign = JsonSerializer.Serialize(campaign);

		string campaignKey = $"Campaign_{campaign.CompanyName}"; // Clé unique pour la campagne
		await _localStorageService.SetItemAsync(campaignKey, serializedCampaign);
	}

	public async Task<List<CampaignViewModel>> LoadCampaignsAsync()
	{

		var savedCampaignsJson = await _localStorageService.GetItemAsync<string>("Campaigns");

		if (string.IsNullOrEmpty(savedCampaignsJson))
		{
			return []; // Retourne une liste vide si aucun état n'est trouvé
		}

		try
		{
			var t = JsonSerializer.Deserialize<List<CampaignViewModel>>(savedCampaignsJson);
			return t;
		}
		catch (JsonException ex)
		{
			Console.WriteLine($"Erreur de désérialisation : {ex.Message}");
			return []; // Retourne une liste vide si la désérialisation échoue
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Erreur générale : {ex.Message}");
			return []; // Retourne une liste vide en cas d'erreur
		}
	}

	public async Task<List<CampaignSummary>> LoadAllCampaignNamesAsync()
	{
		var campaignSummaries = new List<CampaignSummary>();

		// Récupérer toutes les clés du localStorage
		var keys = await _localStorageService.KeysAsync(); // Récupère toutes les clés
		foreach (var key in keys)
		{
			// Vérifie que la clé commence par "Campaign_"
			if (key.StartsWith("Campaign_"))
			{
				var serializedCampaign = await _localStorageService.GetItemAsync<string>(key);
				if (!string.IsNullOrEmpty(serializedCampaign))
				{
					var campaign = JsonSerializer.Deserialize<CampaignViewModel>(serializedCampaign);
					if (campaign != null)
					{
						// Crée un objet avec le nom de la campagne et la liste des joueurs avec toutes leurs propriétés
						var campaignSummary = new CampaignSummary
						{
							CompanyName = campaign.CompanyName,
							Players = campaign.Players // Inclut tous les joueurs avec leurs propriétés complètes
						};

						campaignSummaries.Add(campaignSummary);
					}
				}
			}
		}

		return campaignSummaries;
	}

	public async Task<CampaignViewModel> LoadCampaignByCampaignSummary(string companyName)
	{
		// Recherche dans le localStorage la campagne avec le nom spécifié
		var serializedCampaign = await _localStorageService.GetItemAsync<string>($"Campaign_{companyName}");
		return JsonSerializer.Deserialize<CampaignViewModel>(serializedCampaign);
	}

  public async Task UpdateCampaign(CampaignSummary updatedCampaign)
  {
    // Récupérez la campagne existante par son nom
    string campaignKey = $"Campaign_{updatedCampaign.CompanyName}";
    var existingCampaignJson = await _localStorageService.GetItemAsync<string>(campaignKey);

    if (!string.IsNullOrEmpty(existingCampaignJson))
    {
      // Désérialisez la campagne existante
      var existingCampaign = JsonSerializer.Deserialize<CampaignViewModel>(existingCampaignJson);

      // Mettez à jour les informations de la campagne existante avec les nouvelles données
      if (existingCampaign != null)
      {
        existingCampaign.CompanyName = updatedCampaign.CompanyName;
        existingCampaign.Players = updatedCampaign.Players;

        // Sérialisez et enregistrez la campagne mise à jour
        var updatedCampaignJson = JsonSerializer.Serialize(existingCampaign);
        await _localStorageService.SetItemAsync(campaignKey, updatedCampaignJson);
      }
    }
    else
    {
      Console.WriteLine("Campagne non trouvée pour la mise à jour.");
    }
  }

  public Task<CampaignViewModel> LoadCampaignByCampaignSummary(int id)
  {
    throw new NotImplementedException();
  }

  public Task<ScenarioViewModel> GetScenarioByIdAsync(int scenarioId)
  {
    throw new NotImplementedException();
  }

  public Task<ScenarioViewModel> GetScenarioByIdAsync(int campaignId, int scenarioId)
  {
    throw new NotImplementedException();
  }

  public Task UpdateCampaign(CampaignViewModel existingCampaign)
  {
    throw new NotImplementedException();
  }
}