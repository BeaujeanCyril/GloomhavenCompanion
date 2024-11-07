namespace GloomhavenCompanion;

using Blazored.LocalStorage;
using GloomhavenCompanion.ViewModels;
using Microsoft.AspNetCore.Components;
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
			return new List<CampaignViewModel>(); // Retourne une liste vide si aucun état n'est trouvé
		}

		try
		{
			var t = JsonSerializer.Deserialize<List<CampaignViewModel>>(savedCampaignsJson);
			return t;
		}
		catch (JsonException ex)
		{
			Console.WriteLine($"Erreur de désérialisation : {ex.Message}");
			return new List<CampaignViewModel>(); // Retourne une liste vide si la désérialisation échoue
		}
		catch (Exception ex)
		{
			Console.WriteLine($"Erreur générale : {ex.Message}");
			return new List<CampaignViewModel>(); // Retourne une liste vide en cas d'erreur
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
}