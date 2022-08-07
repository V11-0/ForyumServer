using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class AppDbContext : DbContext
{
    public AppDbContext() {
        this.ChangeTracker.LazyLoadingEnabled = false;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = "server=172.17.0.4; uid=root; pwd=1234; database=Foryum";
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

        optionsBuilder.UseMySql(connectionString, serverVersion);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // User Model
        modelBuilder.Entity<User>().ToTable("Users");

        modelBuilder.Entity<User>()
            .Property(u => u.DateCreated)
            .HasColumnType("DATETIME")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<User>()
            .Property(u => u.Username)
            .HasMaxLength(60);

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Username)
            .IsUnique();
        // -----------------------------

        // Post Model Configuration
        modelBuilder.Entity<Post>().ToTable("Posts");

        modelBuilder.Entity<Post>()
            .Property(p => p.DateCreated)
            .HasColumnType("DATETIME")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Post>()
            .Property(p => p.Title)
            .HasMaxLength(100);
        // ---------------------------

        // PostMedia Model Configuration
        modelBuilder.Entity<PostMedia>().ToTable("PostMedias");
        modelBuilder.Entity<PostMedia>().Property(b => b.DateCreated)
            .HasColumnType("DATETIME")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");
        // -----------------------------

        // Vote Model Configuration
        modelBuilder.Entity<Vote>().ToTable("Votes");
        modelBuilder.Entity<Vote>().Property(b => b.DateCreated)
            .HasColumnType("DATETIME")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        // Define Unique for columns
        modelBuilder.Entity<Vote>()
            .HasIndex(v => new { v.UserId, v.PostId }).IsUnique();
        // -----------------------------

        // Session Model Configuration
        modelBuilder.Entity<Session>().ToTable("Sessions");
        modelBuilder.Entity<Session>().Property(b => b.DateCreated)
            .HasColumnType("DATETIME")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Session>().Ignore(s => s.Token);
        // -------------------------------

        // Community Model Configuration
        modelBuilder.Entity<Community>().ToTable("Communities");

        modelBuilder.Entity<Community>()
            .Property(b => b.DateCreated)
            .HasColumnType("DATETIME")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Community>()
            .Property(c => c.Name)
            .HasMaxLength(100);
        // ----------------------

        modelBuilder.Entity<Comment>().ToTable("Comments");

        modelBuilder.Entity<Comment>()
            .Property(b => b.DateCreated)
            .HasColumnType("DATETIME")
            .HasDefaultValueSql("CURRENT_TIMESTAMP");

        modelBuilder.Entity<Comment>()
            .Property(c => c.Text)
            .HasMaxLength(2000);

        // Relations Configuration ----------------------
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

        modelBuilder.Entity<User>()
            .HasMany(u => u.Sessions)
            .WithOne(s => s.User);
        // ------------------------

        modelBuilder.Entity<Session>()
            .HasOne(s => s.User)
            .WithMany(u => u.Sessions);
        // ------------------------

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

        modelBuilder.Entity<Community>()
            .HasMany(c => c.Posts)
            .WithOne(p => p.Community);

        modelBuilder.Entity<Community>()
            .HasMany(c => c.Users)
            .WithMany(u => u.Communities);

        modelBuilder.Entity<Community>()
            .HasOne(c => c.CreatorUser)
            .WithMany(c => c.CreatedCommunities);

        modelBuilder.Entity<Community>()
            .HasIndex(c => c.Name)
            .IsUnique();
        // ------------------------
        modelBuilder.Entity<Comment>()
            .HasOne(c => c.ParentComment)
            .WithMany(p => p.SubComments);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Post)
            .WithMany(p => p.Comments);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.CreatorUser)
            .WithMany(u => u.Comments);
    }

    public DbSet<User> Users => Set<User>();
    public DbSet<Session> Sessions => Set<Session>();
    public DbSet<Community> Communities => Set<Community>();
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Vote> Votes => Set<Vote>();
    public DbSet<Comment> Comments => Set<Comment>();
}