﻿using Microsoft.EntityFrameworkCore;
using Planner.Domain.Domain.Entities;
using Planner.Infra.Data.EntityConfiguration;

namespace Planner.Infra.Data.Data;

public class PlannerDbContext : DbContext
{
    public PlannerDbContext(DbContextOptions<PlannerDbContext> options) : base(options) { }

    public DbSet<User> User { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UserConfiguration());

        base.OnModelCreating(modelBuilder);
    }

}
