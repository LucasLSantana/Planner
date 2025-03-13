using Microsoft.EntityFrameworkCore;
using Planner.Domain.Domain.Entities;

namespace Planner.Infra.Data.Data;

public class PlannerDbContext : DbContext
{
    public PlannerDbContext(DbContextOptions<PlannerDbContext> options) : base(options) { }

    public DbSet<User> User { get; set; }

}
