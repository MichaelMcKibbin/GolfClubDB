using GolfClubDB.Models;
using Microsoft.EntityFrameworkCore;

namespace GolfClubDB.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Member> Members => Set<Member>();
    public DbSet<Booking> Bookings => Set<Booking>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Member>()
            .HasIndex(m => m.MembershipNumber)
            .IsUnique();

        modelBuilder.Entity<Booking>()
            .HasIndex(b => new { b.MemberId, b.BookingDate })
            .IsUnique();
    }
}
