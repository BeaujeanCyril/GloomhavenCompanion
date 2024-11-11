using System.ComponentModel.DataAnnotations;

namespace GloomhavenCompanion.Data.Model;
public class Element
{
[Key]
	public int Id { get; set; }
	public string Name { get; set; }
	public int State { get; set; } = 0;
	public string ImagePath { get; set; }
}
