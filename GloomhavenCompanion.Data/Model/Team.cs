namespace GloomhavenCompanion.Data.Model
{
  public class Team
  {
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public List<Player> Players { get; set; }
  }
}
