namespace GloomhavenCompanion.Data.Model
{
  public class PlayerGame
  {
    public int PlayerId { get; set; }   // Clé étrangère vers Player
    public Player Player { get; set; }   // Navigation vers l'entité Player

    public int GameId { get; set; }      // Clé étrangère vers Game
    public Game Game { get; set; }       // Navigation vers l'entité Game

    public int HealthPoints { get; set; } // Points de vie du joueur dans la partie
    public int HealthPointsMax { get; set; } // Points de vie max du joueur dans la partie (si nécessaire)

    public int Coins { get; set; } = 0;   // Pièces du joueur pendant la partie
    public int Xp { get; set; } = 0;      // XP du joueur dans cette partie

    public List<Effect> Effects { get; set; } = new List<Effect>();  // Liste des effets appliqués au joueur

    public bool IsAlive { get; set; } = true;  // Indicateur de l'état de vie du joueur
  }
}
