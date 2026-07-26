using Microsoft.EntityFrameworkCore;

namespace Identity.Models;

public partial class MasterContext : DbContext
{
    public MasterContext()
    {
    }

    public MasterContext(DbContextOptions<MasterContext> options)
        : base(options)
    {
    }

    public virtual DbSet<EmailConfirmToken> EmailConfirmTokens { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<EmailConfirmToken>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EmailCon__3214EC07B11948B6");

            entity.HasIndex(e => e.TokenHash, "IX_EmailConfirmTokens_TokenHash").IsUnique();

            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysutcdatetime())");
            entity.Property(e => e.TokenHash).HasMaxLength(256);

            entity.HasOne(d => d.User).WithMany(p => p.EmailConfirmTokens)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_EmailConfirmTokens_Users");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CAD295EB1");

            entity.HasIndex(e => e.Email, "UQ__Users__A9D10534F6854D0B").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.PasswordHash).HasMaxLength(256);
            entity.Property(e => e.UserName).HasMaxLength(256);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
