namespace GloomhavenCompanion.Data.Model
{
  public class Campaign
  {
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public List<Player> Players { get; set; }
  }
}
