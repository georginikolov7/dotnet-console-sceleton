using HubbersApp.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HubbersApp.Infrastructure.Configurations;

public class HubbersConfiguration : IEntityTypeConfiguration<Hubber>
{
    public void Configure(EntityTypeBuilder<Hubber> builder)
    {
        Hubber hubber1 = new Hubber()
        {
            Id = Guid.Parse("cfa5267c-769b-4faa-8680-b49b6d1de959"),
            Name = "Hubber 1",
        };
        Hubber hubber2 = new Hubber()
        {
            Id = Guid.Parse("64b84d3c-946c-46e7-a9df-9e3f3123c8cb"),
            Name = "Hubber 2",
        };
        builder.HasData(
            [
                hubber1, hubber2
            ]
        );
    }
}