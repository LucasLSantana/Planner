using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Planner.Domain.Domain.Entities;

namespace Planner.Infra.Data.EntityConfiguration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("User");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Email)
               .IsRequired();

        builder.HasIndex(c => c.Email)
               .IsUnique();
    }
}