using APBD_Z5.Models;
using Microsoft.EntityFrameworkCore;

namespace ZAL_APBD.Models;

public class SQLDBContext : DbContext
{
    public SQLDBContext(DbContextOptions<SQLDBContext> options) : base(options)
    {
    }

    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<Payment> Payments { get; set; }
    public virtual DbSet<Sale> Sales { get; set; }
    public virtual DbSet<Subscription> Subscriptions { get; set; }
    public virtual DbSet<Discount> Discounts { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("dbo");
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient)
                .HasName("Client_pk");

            entity.ToTable("Client");

            entity.Property(e => e.IdClient).ValueGeneratedNever();

            entity.Property(e => e.Email)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.FirstName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.LastName)
                .IsRequired();

            entity.Property(e => e.Phone)
                .IsRequired(false)
                .HasMaxLength(100);
            
        });

        modelBuilder.Entity<Sale>(entity =>
        {
            entity.HasKey(e => new { e.IdSale })
                .HasName("Sale_pk");
            entity.ToTable("Sale");
            entity.HasOne(d => d.VSubscription)
                .WithMany(p => p.VSales)
                .HasForeignKey(d => d.IdSubscription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Table_5_Subscription");
            
            entity.HasOne(d => d.VClient)
                .WithMany(p => p.VSales)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Table_5_Client");
            
            entity.Property(e => e.IdSale).ValueGeneratedNever();
            
            entity.Property(e => e.CreatedAt)
                .IsRequired();
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity.HasKey(e => e.IdSubscription);
            entity.ToTable("Subscription");
            entity.Property(e => e.IdSubscription).ValueGeneratedNever();

            
            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(e => e.RenewalPeriod)
                .IsRequired();

            entity.Property(e => e.Price)
                .HasColumnType("money")
                .IsRequired();
            
            entity.Property(e => e.EndTime)
                .IsRequired();
        });
        
        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.IdPayment);
            entity.ToTable("Payment");
            entity.Property(e => e.IdPayment).ValueGeneratedNever();


            entity.Property(e => e.Date)
                .IsRequired();
            
            entity.HasOne(d => d.VSubscription)
                .WithMany(p => p.VPayments)
                .HasForeignKey(d => d.IdSubscription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Payment_Subscription");
            
            entity.HasOne(d => d.VClient)
                .WithMany(p => p.VPayments)
                .HasForeignKey(d => d.IdClient)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Payment_Client");

        });

        modelBuilder.Entity<Discount>(entity =>
        {
            entity.HasKey(e => e.IdDiscount)
                .HasName("Discount_pk");
            entity.ToTable("Discount");
            entity.Property(e => e.IdDiscount).ValueGeneratedNever();

            entity.HasOne(d => d.VSubscription)
                .WithMany(p => p.VDiscounts)
                .HasForeignKey(d => d.IdSubscription)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Discount_Subscription");
            
            entity.Property(e => e.Value)
                .IsRequired();

            entity.Property(e => e.DateFrom)
                .IsRequired();
            
            entity.Property(e => e.DateTo)
                .IsRequired();
        });

        base.OnModelCreating(modelBuilder);
    }
}