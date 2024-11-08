using Blazored.LocalStorage;
using GloomhavenCompanion;
using GloomhavenCompanion.Views;
using Microsoft.EntityFrameworkCore;
using MudBlazor.Services;
using GloomhavenCompanion.Infrastructure; // Assure-toi que ce namespace est correct et qu'il inclut le DbContext

var builder = WebApplication.CreateBuilder(args);

// Ajouter des services à l'application
builder.Services.AddRazorComponents()
		.AddInteractiveServerComponents();

builder.Services.AddMudServices(); // MudBlazor pour les composants UI

builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>(); // Accès au contexte HTTP
builder.Services.AddBlazoredLocalStorage(); // Pour utiliser localStorage

// Enregistrer ton service personnalisé pour l'état de l'application
builder.Services.AddScoped<IAppStateStorage, LocalStorageAppStateStorage>();

// Enregistrer les services de l'application
builder.Services.AddScoped<AppStateService>();
builder.Services.AddScoped<AppState>();
builder.Services.AddLogging(logging =>
{
	logging.AddConsole();  // Affiche les logs dans la console pour le développement
});

// Configuration de la connexion à la base de données avec Entity Framework Core et MySQL
builder.Services.AddDbContext<GloomhavenCompanionDbContext>(options =>
		options.UseMySql(
				builder.Configuration.GetConnectionString("GloomhavenConnection"), // Vérifie que la clé existe dans appsettings.json
						new MySqlServerVersion(new Version(8, 0, 23))
		));

// Construire l'application
var app = builder.Build();

// Configurer le pipeline HTTP
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	app.UseHsts();
}

app.UseHttpsRedirection(); // Redirection vers HTTPS
app.UseStaticFiles(); // Pour les fichiers statiques (comme CSS, JS, etc.)
app.UseAntiforgery(); // Protection contre les attaques CSRF

// Définir la carte pour les composants Razor et démarrer le rendu interactif côté serveur
app.MapRazorComponents<App>()
		.AddInteractiveServerRenderMode();

// Lancer l'application
app.Run();
