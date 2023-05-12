using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarWorkshop.Infrastructure.Persistence;

public class CarWorkshopDbContext : IdentityDbContext
{
    public DbSet<Domain.Entities.CarWorkshop> CarWorkshops { get; set; } = default!;
    public DbSet<Domain.Entities.CarWorkshopService> CarWorkshopServices { get; set; } = default!;

    public CarWorkshopDbContext(DbContextOptions<CarWorkshopDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Domain.Entities.CarWorkshop>()
            .OwnsOne(c => c.ContactDetails);

        modelBuilder.Entity<Domain.Entities.CarWorkshop>()
            .HasMany(c => c.Services)
            .WithOne(s => s.CarWorkshop)
            .HasForeignKey(s => s.CarWorkshopId);
    }
}