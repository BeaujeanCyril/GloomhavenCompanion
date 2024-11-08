using GloomhavenCompanion.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace GloomhavenCompanion.API.Data;

public class GloomhavenCompanionDbContext : DbContext
{ 
public GloomhavenCompanionDbContext(DbContextOptions<GloomhavenCompanionDbContext> options)
    : base(options)
{
}

public DbSet<Card> Players { get; set; }
}