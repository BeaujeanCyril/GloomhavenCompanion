using GloomhavenCompanion.API.Model;
using Microsoft.EntityFrameworkCore;

namespace GloomhavenCompanion.API.Data;

public class GloomhavenCompanionDbContext : DbContext
{ 
public GloomhavenCompanionDbContext(DbContextOptions<GloomhavenCompanionDbContext> options)
    : base(options)
{
}

public DbSet<Player> Players { get; set; }
public DbSet<Team> Teams { get; set; }
}