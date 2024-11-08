using Microsoft.EntityFrameworkCore;
using GloomhavenCompanion.Data.Model;
namespace GloomhavenCompanion.Infrastructure;

public class GloomhavenCompanionDbContext : DbContext  // Hérite de DbContext
{
	public GloomhavenCompanionDbContext(DbContextOptions<GloomhavenCompanionDbContext> options)
			: base(options)
	{ }

	public DbSet<Card> Cards { get; set; }
}
