using System.Reflection;
using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "server=172.17.0.4; uid=root; pwd=1234; database=Foryum";
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User Model Configuration
        modelBuilder.Entity<User>().ToTable("Users");

        modelBuilder.Entity<User>()
            .Property(u => u.DateCreated)
            .HasDefaultValue(DateTimeOffset.Now);

        modelBuilder.Entity<User>()
            .Property(u => u.Username)
            .HasMaxLength(60);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Posts)
            .WithOne(p => p.CreatorUser);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Communities)
            .WithMany(c => c.Users);

        modelBuilder.Entity<User>()
            .HasMany(u => u.CreatedCommunities)
            .WithOne(c => c.CreatorUser);

        modelBuilder.Entity<User>()
            .HasMany(u => u.Votes)
            .WithOne(v => v.User);
        // ------------------------

        // Post Model Configuration
        modelBuilder.Entity<Post>().ToTable("Posts");

        modelBuilder.Entity<Post>()
            .Property(p => p.DateCreated)
            .HasDefaultValue(DateTimeOffset.Now);

        modelBuilder.Entity<Post>()
            .Property(p => p.Title)
            .HasMaxLength(100);

        modelBuilder.Entity<Post>()
            .HasMany(p => p.Medias)
            .WithOne(m => m.Post);

        modelBuilder.Entity<Post>()
            .HasOne(p => p.CreatorUser)
            .WithMany(u => u.Posts);

        modelBuilder.Entity<Post>()
            .HasOne(p => p.Community)
            .WithMany(c => c.Posts);

        modelBuilder.Entity<Post>()
            .HasMany(p => p.Votes)
            .WithOne(v => v.Post);
        // ------------------------

        // Community Model Configuration
        modelBuilder.Entity<Community>().ToTable("Communities");

        modelBuilder.Entity<Community>()
            .Property(b => b.DateCreated)
            .HasDefaultValue(DateTimeOffset.Now);

        modelBuilder.Entity<Community>()
            .Property(c => c.Name)
            .HasMaxLength(100);

        modelBuilder.Entity<Community>()
            .HasMany(c => c.Posts)
            .WithOne(p => p.Community);

        modelBuilder.Entity<Community>()
            .HasMany(c => c.Users)
            .WithMany(u => u.Communities);

        modelBuilder.Entity<Community>()
            .HasOne(c => c.CreatorUser)
            .WithMany(c => c.CreatedCommunities);
        // -----------------------------

        // PostMedia Model Configuration
        modelBuilder.Entity<PostMedia>().ToTable("PostMedias");
        modelBuilder.Entity<PostMedia>().Property(b => b.DateCreated).HasDefaultValue(DateTimeOffset.Now);
        // -----------------------------

        // Vote Model Configuration
        modelBuilder.Entity<Vote>().ToTable("Votes");
        modelBuilder.Entity<Vote>().Property(b => b.DateCreated).HasDefaultValue(DateTimeOffset.Now);
        // -----------------------------
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Community> Communities => Set<Community>();
}