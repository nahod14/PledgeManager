
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PledgeManager.Domain;

namespace PledgeManager.Infrastructure;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Donor> Donors => Set<Donor>();
    public DbSet<Pledge> Pledges => Set<Pledge>();
    public DbSet<Payment> Payments => Set<Payment>();
    public DbSet<FileBlob> FileBlobs => Set<FileBlob>();

    protected override void OnModelCreating(ModelBuilder b)
    {
        base.OnModelCreating(b);
        b.Entity<Pledge>()
            .HasMany(p => p.Payments)
            .WithOne()
            .HasForeignKey(p => p.PledgeId)
            .OnDelete(DeleteBehavior.Cascade);
        b.Entity<Donor>()
            .HasIndex(d => d.Email)
            .IsUnique();
        b.Entity<Pledge>()
            .HasIndex(p => p.Status);
    }
}

public static class SeedData
{
    public static async Task InitAsync(IServiceProvider services)
    {
        using var scope = services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        // Database migrations should be run separately via dotnet ef database update
        // await db.Database.MigrateAsync();

        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<IdentityUser>>();

        // Seed default admin
        var email = "admin@example.com";
        if (await userManager.FindByEmailAsync(email) is null)
        {
            var user = new IdentityUser { UserName = email, Email = email, EmailConfirmed = true };
            await userManager.CreateAsync(user, "Passw0rd!");
        }

        if (!db.Donors.Any())
        {
            var d1 = new Donor { Name = "Alice Johnson", Email = "alice@example.com" };
            var d2 = new Donor { Name = "Bob Smith", Email = "bob@example.com" };
            db.Donors.AddRange(d1, d2);

            var p1 = new Pledge { Donor = d1, Amount = 1000m, Frequency = "Monthly", Status = "Active" };
            var p2 = new Pledge { Donor = d2, Amount = 200m, Frequency = "OneTime", Status = "Active" };
            db.Pledges.AddRange(p1, p2);

            db.Payments.Add(new Payment { PledgeId = p1.Id, Amount = 200m });
            db.Payments.Add(new Payment { PledgeId = p2.Id, Amount = 200m });

            await db.SaveChangesAsync();
        }
    }
}
