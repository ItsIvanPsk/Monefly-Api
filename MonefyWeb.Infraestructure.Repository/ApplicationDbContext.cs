using Microsoft.EntityFrameworkCore;
using MonefyWeb.Infraestructure.Models;

public class ApplicationDbContext : DbContext
{
    public DbSet<UserDm> Users { get; set; }
    public DbSet<AccountDm> Accounts { get; set; }
    public DbSet<CategoryDm> Categories { get; set; }
    public DbSet<MovementDm> Movements { get; set; }
    public DbSet<CurrencyDm> Currencies { get; set; }
    public DbSet<UsersCategoriesDm> UsersCategories { get; set; }
    public DbSet<UsersAccountsDm> UsersAccounts { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the Users table
        modelBuilder.Entity<UserDm>().ToTable("Users");
        modelBuilder.Entity<UserDm>()
            .HasKey(u => u.Id);

        // Configure the Accounts table
        modelBuilder.Entity<AccountDm>().ToTable("Accounts");
        modelBuilder.Entity<AccountDm>()
            .HasKey(a => a.Id);
        modelBuilder.Entity<AccountDm>()
            .HasOne(a => a.User)
            .WithMany(u => u.Accounts)
            .HasForeignKey(a => a.UserId)
            .IsRequired();

        // Create a Many-to-Many relationship with UsersAccountsDm
        modelBuilder.Entity<AccountDm>()
            .HasMany(a => a.UsersAccounts)
            .WithOne(ua => ua.Account)
            .HasForeignKey(ua => ua.AccountId);

        // Configure the Categories table
        modelBuilder.Entity<CategoryDm>().ToTable("Categories");
        modelBuilder.Entity<CategoryDm>()
            .HasKey(c => c.Id);

        // Configure the Movements table
        modelBuilder.Entity<MovementDm>().ToTable("Movements");
        modelBuilder.Entity<MovementDm>()
            .HasKey(m => m.Id);
        modelBuilder.Entity<MovementDm>()
            .HasOne(m => m.Account)
            .WithMany(a => a.Movements)
            .HasForeignKey(m => m.AccountId);
        modelBuilder.Entity<MovementDm>()
            .HasOne(m => m.Category)
            .WithMany(c => c.Movements)
            .HasForeignKey(m => m.CategoryId);

        modelBuilder.Entity<MovementDm>()
            .Property(b => b.Concept)
            .HasMaxLength(100)
            .IsRequired();

        modelBuilder.Entity<MovementDm>()
            .Property(b => b.Amount)
            .HasColumnType("decimal(18,0)")
            .IsRequired();

        modelBuilder.Entity<MovementDm>()
            .Property(b => b.Date)
            .IsRequired();

        modelBuilder.Entity<MovementDm>()
            .Property(b => b.Type)
            .IsRequired();

        modelBuilder.Entity<MovementDm>()
            .Property(b => b.PaymentMethod)
            .IsRequired();

        modelBuilder.Entity<MovementDm>()
            .HasOne(b => b.Category)
            .WithMany(p => p.Movements)
            .HasForeignKey(a => a.CategoryId);

        // Configure the Currencies table
        modelBuilder.Entity<CurrencyDm>().ToTable("Currencies");
        modelBuilder.Entity<CurrencyDm>()
            .HasKey(c => c.Id);

        // Configure the UsersCategories table (Many-to-Many)
        modelBuilder.Entity<UsersCategoriesDm>().ToTable("Users_Categories");
        modelBuilder.Entity<UsersCategoriesDm>()
            .HasKey(uc => new { uc.UserId, uc.CategoryId });
        modelBuilder.Entity<UsersCategoriesDm>()
            .HasOne(uc => uc.User)
            .WithMany(u => u.UsersCategories)
            .HasForeignKey(uc => uc.UserId);
        modelBuilder.Entity<UsersCategoriesDm>()
            .HasOne(uc => uc.Category)
            .WithMany(c => c.UsersCategories)
            .HasForeignKey(uc => uc.CategoryId);

        // Configure the UsersAccounts table (Many-to-Many)
        modelBuilder.Entity<UsersAccountsDm>().ToTable("Users_Accounts");
        modelBuilder.Entity<UsersAccountsDm>()
            .HasKey(ua => new { ua.UserId, ua.AccountId });
        modelBuilder.Entity<UsersAccountsDm>()
            .HasOne(ua => ua.User)
            .WithMany(u => u.UsersAccounts)
            .HasForeignKey(ua => ua.UserId);
        modelBuilder.Entity<UsersAccountsDm>()
            .HasOne(ua => ua.Account)
            .WithMany(a => a.UsersAccounts)
            .HasForeignKey(ua => ua.AccountId);
    }
}
