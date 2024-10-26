namespace GloomhavenCompanion.Model
{
  public class TeamViewModel
  {
    public int Id { get; set; }
    public string CompanyName { get; set; }
    public List<PlayerViewModel> Players { get; set; }
  }
}
