using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Planner.Domain.Domain.Entities;

namespace Planner.Infra.Data.EntityConfiguration;

public class CalendarConfiguration : IEntityTypeConfiguration<Calendar>
{
    public void Configure(EntityTypeBuilder<Calendar> builder)
    {
        builder.ToTable("Calendar");

        builder.HasKey(c => c.Id);

        builder.Property(p => p.UserId);
    }
}