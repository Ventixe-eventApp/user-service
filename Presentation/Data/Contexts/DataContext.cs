using Microsoft.EntityFrameworkCore;
using Presentation.Data.Entites;

namespace Presentation.Data.Contexts;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<UserProfileEntity> UserProfiles { get; set; } = null!;
    public DbSet<UserAdressEntity> UserAdresses { get; set; } = null!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserProfileEntity>()
            .HasOne(u => u.Address)
            .WithOne(a => a.UserProfile)
            .HasForeignKey<UserAdressEntity>(a => a.UserId);

        base.OnModelCreating(modelBuilder);
    }
}
