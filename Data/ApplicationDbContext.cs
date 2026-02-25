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

    public void SeedData()
    {
        // Only seed if database is empty
        if (Members.Any())
            return;

        var today = DateTime.Today;

        // Create sample members - let database auto-generate IDs
        var members = new List<Member>
        {
            new() { MembershipNumber = "GC001", FirstName = "John", LastName = "Smith", Email = "john.smith@email.com", PhoneNumber = "01234 567890", Gender = "Male", DateOfBirth = new DateTime(1985, 5, 15), Handicap = -5, MembershipStartDate = today.AddYears(-2), MembershipEndDate = null, StreetAddress = "123 Oak Street", StreetAddress2 = "Apt 4", TownAddress = "Manchester", CountyAddress = "Greater Manchester", Postcode = "M1 1AA", Bio = "Experienced golfer and club member", EmergencyContactName = "Jane Smith", EmergencyContactPhone = "01234 567891" },
            new() { MembershipNumber = "GC002", FirstName = "Sarah", LastName = "Johnson", Email = "sarah.johnson@email.com", PhoneNumber = "01234 567892", Gender = "Female", DateOfBirth = new DateTime(1990, 8, 22), Handicap = -2, MembershipStartDate = today.AddYears(-1), MembershipEndDate = null, StreetAddress = "456 Elm Avenue", TownAddress = "Manchester", CountyAddress = "Greater Manchester", Postcode = "M2 2BB", Bio = "Regular weekend player", EmergencyContactName = "Tom Johnson", EmergencyContactPhone = "01234 567893" },
            new() { MembershipNumber = "GC003", FirstName = "Michael", LastName = "Brown", Email = "michael.brown@email.com", PhoneNumber = "01234 567894", Gender = "Male", DateOfBirth = new DateTime(1978, 3, 10), Handicap = 5, MembershipStartDate = today.AddYears(-3), MembershipEndDate = null, StreetAddress = "789 Pine Road", StreetAddress2 = "Suite 200", TownAddress = "Manchester", CountyAddress = "Greater Manchester", Postcode = "M3 3CC", Bio = "Active tournament participant", EmergencyContactName = "Emma Brown", EmergencyContactPhone = "01234 567895" },
            new() { MembershipNumber = "GC004", FirstName = "Emma", LastName = "Wilson", Email = "emma.wilson@email.com", PhoneNumber = "01234 567896", Gender = "Female", DateOfBirth = new DateTime(1995, 11, 28), Handicap = 8, MembershipStartDate = today.AddMonths(-6), MembershipEndDate = null, StreetAddress = "321 Birch Lane", TownAddress = "Manchester", CountyAddress = "Greater Manchester", Postcode = "M4 4DD", Bio = "Beginner member, improving rapidly", EmergencyContactName = "David Wilson", EmergencyContactPhone = "01234 567897" },
            new() { MembershipNumber = "GC005", FirstName = "David", LastName = "Lee", Email = "david.lee@email.com", PhoneNumber = "01234 567898", Gender = "Male", DateOfBirth = new DateTime(1988, 7, 14), Handicap = 12, MembershipStartDate = today.AddYears(-4), MembershipEndDate = null, StreetAddress = "654 Cedar Drive", TownAddress = "Manchester", CountyAddress = "Greater Manchester", Postcode = "M5 5EE", Bio = "Club champion, excellent player", EmergencyContactName = "Lisa Lee", EmergencyContactPhone = "01234 567899" },
            new() { MembershipNumber = "GC006", FirstName = "Lisa", LastName = "Chen", Email = "lisa.chen@email.com", PhoneNumber = "01234 567900", Gender = "Female", DateOfBirth = new DateTime(1992, 1, 5), Handicap = 15, MembershipStartDate = today.AddYears(-2), MembershipEndDate = null, StreetAddress = "987 Maple Close", TownAddress = "Manchester", CountyAddress = "Greater Manchester", Postcode = "M6 6FF", Bio = "Consistent mid-range player", EmergencyContactName = "James Chen", EmergencyContactPhone = "01234 567901" },
            new() { MembershipNumber = "GC007", FirstName = "Robert", LastName = "Taylor", Email = "robert.taylor@email.com", PhoneNumber = "01234 567902", Gender = "Male", DateOfBirth = new DateTime(1980, 9, 20), Handicap = 22, MembershipStartDate = today.AddYears(-5), MembershipEndDate = null, StreetAddress = "147 Willow Street", TownAddress = "Manchester", CountyAddress = "Greater Manchester", Postcode = "M7 7GG", Bio = "Social golfer, enjoys the game", EmergencyContactName = "Patricia Taylor", EmergencyContactPhone = "01234 567903" },
            new() { MembershipNumber = "GC008", FirstName = "Catherine", LastName = "Anderson", Email = "catherine.anderson@email.com", PhoneNumber = "01234 567904", Gender = "Female", DateOfBirth = new DateTime(1987, 4, 11), Handicap = 20, MembershipStartDate = today.AddMonths(-9), MembershipEndDate = null, StreetAddress = "258 Hawthorn Close", TownAddress = "Manchester", CountyAddress = "Greater Manchester", Postcode = "M8 8HH", Bio = "Competitive and driven", EmergencyContactName = "Mark Anderson", EmergencyContactPhone = "01234 567905" },
            new() { MembershipNumber = "GC009", FirstName = "James", LastName = "Martin", Email = "james.martin@email.com", PhoneNumber = "01234 567906", Gender = "Male", DateOfBirth = new DateTime(1993, 6, 7), Handicap = 25, MembershipStartDate = today.AddMonths(-3), MembershipEndDate = null, StreetAddress = "369 Ash Road", TownAddress = "Manchester", CountyAddress = "Greater Manchester", Postcode = "M9 9II", Bio = "New member, learning the game", EmergencyContactName = "Helen Martin", EmergencyContactPhone = "01234 567907" },
            new() { MembershipNumber = "GC010", FirstName = "Victoria", LastName = "White", Email = "victoria.white@email.com", PhoneNumber = "01234 567908", Gender = "Female", DateOfBirth = new DateTime(1986, 12, 3), Handicap = 10, MembershipStartDate = today.AddYears(-1), MembershipEndDate = null, StreetAddress = "741 Sycamore Lane", TownAddress = "Manchester", CountyAddress = "Greater Manchester", Postcode = "M10 10JJ", Bio = "Strong technical player", EmergencyContactName = "Richard White", EmergencyContactPhone = "01234 567909" },
            new() { MembershipNumber = "GC011", FirstName = "Thomas", LastName = "Hughes", Email = "thomas.hughes@email.com", PhoneNumber = "01234 567910", Gender = "Male", DateOfBirth = new DateTime(1982, 2, 18), Handicap = 30, MembershipStartDate = today.AddYears(-3), MembershipEndDate = null, StreetAddress = "852 Rosewood Avenue", TownAddress = "Manchester", CountyAddress = "Greater Manchester", Postcode = "M11 11KK", Bio = "Steady player, loves match play", EmergencyContactName = "Anna Hughes", EmergencyContactPhone = "01234 567911" },
            new() { MembershipNumber = "GC012", FirstName = "Rebecca", LastName = "Davis", Email = "rebecca.davis@email.com", PhoneNumber = "01234 567912", Gender = "Female", DateOfBirth = new DateTime(1991, 10, 9), Handicap = 36, MembershipStartDate = today.AddYears(-2), MembershipEndDate = null, StreetAddress = "963 Chestnut Road", TownAddress = "Manchester", CountyAddress = "Greater Manchester", Postcode = "M12 12LL", Bio = "Former junior champion, excellent short game", EmergencyContactName = "Peter Davis", EmergencyContactPhone = "01234 567913" },
            new() { MembershipNumber = "GC013", FirstName = "Christopher", LastName = "Thompson", Email = "chris.thompson@email.com", PhoneNumber = "01234 567914", Gender = "Male", DateOfBirth = new DateTime(1975, 6, 25), Handicap = 49, MembershipStartDate = today.AddYears(-6), MembershipEndDate = null, StreetAddress = "147 Beech Close", TownAddress = "Manchester", CountyAddress = "Greater Manchester", Postcode = "M13 13MM", Bio = "Senior member, mentors new players", EmergencyContactName = "Susan Thompson", EmergencyContactPhone = "01234 567915" },
            new() { MembershipNumber = "GC014", FirstName = "Amanda", LastName = "Roberts", Email = "amanda.roberts@email.com", PhoneNumber = "01234 567916", Gender = "Female", DateOfBirth = new DateTime(1989, 3, 14), Handicap = 51, MembershipStartDate = today.AddMonths(-8), MembershipEndDate = null, StreetAddress = "258 Poplar Street", TownAddress = "Manchester", CountyAddress = "Greater Manchester", Postcode = "M14 14NN", Bio = "Improving rapidly, great team player", EmergencyContactName = "Kevin Roberts", EmergencyContactPhone = "01234 567917" },
            new() { MembershipNumber = "GC015", FirstName = "Daniel", LastName = "Parker", Email = "daniel.parker@email.com", PhoneNumber = "01234 567918", Gender = "Male", DateOfBirth = new DateTime(1994, 8, 30), Handicap = 11, MembershipStartDate = today.AddYears(-1), MembershipEndDate = null, StreetAddress = "369 Laurel Way", TownAddress = "Manchester", CountyAddress = "Greater Manchester", Postcode = "M15 15OO", Bio = "Long hitter, aggressive style", EmergencyContactName = "Michelle Parker", EmergencyContactPhone = "01234 567919" },
            new() { MembershipNumber = "GC016", FirstName = "Sophie", LastName = "Mitchell", Email = "sophie.mitchell@email.com", PhoneNumber = "01234 567920", Gender = "Female", DateOfBirth = new DateTime(1983, 12, 12), Handicap = 9, MembershipStartDate = today.AddYears(-4), MembershipEndDate = null, StreetAddress = "741 Magnolia Drive", TownAddress = "Manchester", CountyAddress = "Greater Manchester", Postcode = "M16 16PP", Bio = "Social member, organizes ladies' events", EmergencyContactName = "Graham Mitchell", EmergencyContactPhone = "01234 567921" },
            new() { MembershipNumber = "GC017", FirstName = "Andrew", LastName = "Collins", Email = "andrew.collins@email.com", PhoneNumber = "01234 567922", Gender = "Male", DateOfBirth = new DateTime(1979, 5, 22), Handicap = 33, MembershipStartDate = today.AddYears(-7), MembershipEndDate = null, StreetAddress = "852 Cypress Lane", TownAddress = "Manchester", CountyAddress = "Greater Manchester", Postcode = "M17 17QQ", Bio = "Club committee member, tournament organizer", EmergencyContactName = "Laura Collins", EmergencyContactPhone = "01234 567923" },
            new() { MembershipNumber = "GC018", FirstName = "Jennifer", LastName = "Murphy", Email = "jennifer.murphy@email.com", PhoneNumber = "01234 567924", Gender = "Female", DateOfBirth = new DateTime(1996, 1, 8), Handicap = 27, MembershipStartDate = today.AddMonths(-5), MembershipEndDate = null, StreetAddress = "963 Redwood Avenue", TownAddress = "Manchester", CountyAddress = "Greater Manchester", Postcode = "M18 18RR", Bio = "Enthusiastic newcomer, learning fast", EmergencyContactName = "Brian Murphy", EmergencyContactPhone = "01234 567925" },
            new() { MembershipNumber = "GC019", FirstName = "Matthew", LastName = "Bailey", Email = "matthew.bailey@email.com", PhoneNumber = "01234 567926", Gender = "Male", DateOfBirth = new DateTime(1984, 9, 16), Handicap = 13, MembershipStartDate = today.AddYears(-5), MembershipEndDate = null, StreetAddress = "147 Spruce Road", TownAddress = "Manchester", CountyAddress = "Greater Manchester", Postcode = "M19 19SS", Bio = "Low handicap player, exceptional putter", EmergencyContactName = "Rachel Bailey", EmergencyContactPhone = "01234 567927" },
            new() { MembershipNumber = "GC020", FirstName = "Rachel", LastName = "Foster", Email = "rachel.foster@email.com", PhoneNumber = "01234 567928", Gender = "Female", DateOfBirth = new DateTime(1988, 7, 27), Handicap = 21, MembershipStartDate = today.AddYears(-2), MembershipEndDate = null, StreetAddress = "258 Fir Close", TownAddress = "Manchester", CountyAddress = "Greater Manchester", Postcode = "M20 20TT", Bio = "Weekend golfer, plays for enjoyment", EmergencyContactName = "Steven Foster", EmergencyContactPhone = "01234 567929" }
        };

        Members.AddRange(members);
        SaveChanges();

        // Create sample bookings with varying numbers of additional players
        var todayDateOnly = DateOnly.FromDateTime(today);
        var bookings = new List<Booking>
        {
            // Bookings with no additional players
            new() { MemberId = 1, BookingDate = todayDateOnly.AddDays(1), TeeTime = new TimeOnly(7, 0) },
            new() { MemberId = 2, BookingDate = todayDateOnly.AddDays(1), TeeTime = new TimeOnly(7, 15) },

            // Bookings with 1 additional player
            new() { MemberId = 3, BookingDate = todayDateOnly.AddDays(2), TeeTime = new TimeOnly(9, 0), Player2Name = "Guest 1", Player2Handicap = 15 },
            new() { MemberId = 4, BookingDate = todayDateOnly.AddDays(2), TeeTime = new TimeOnly(9, 15) },

            // Bookings with 2 additional players
            new() { MemberId = 5, BookingDate = todayDateOnly.AddDays(3), TeeTime = new TimeOnly(10, 30), Player2Name = "Guest 2", Player2Handicap = 18, Player3Name = "Guest 3", Player3Handicap = 12 },
            new() { MemberId = 6, BookingDate = todayDateOnly.AddDays(3), TeeTime = new TimeOnly(10, 45) },

            // Bookings with 3 additional players (full group)
            new() { MemberId = 7, BookingDate = todayDateOnly.AddDays(4), TeeTime = new TimeOnly(13, 0), Player2Name = "Guest 4", Player2Handicap = 20, Player3Name = "Guest 5", Player3Handicap = 16, Player4Name = "Guest 6", Player4Handicap = 19 },
            new() { MemberId = 8, BookingDate = todayDateOnly.AddDays(4), TeeTime = new TimeOnly(13, 15) },

            // More varied bookings
            new() { MemberId = 9, BookingDate = todayDateOnly.AddDays(5), TeeTime = new TimeOnly(14, 30) },
            new() { MemberId = 10, BookingDate = todayDateOnly.AddDays(5), TeeTime = new TimeOnly(14, 45), Player2Name = "Visitor", Player2Handicap = 11 },

            // Weekend bookings
            new() { MemberId = 1, BookingDate = todayDateOnly.AddDays(7), TeeTime = new TimeOnly(8, 0), Player2Name = "Weekend Guest 1", Player2Handicap = 13, Player3Name = "Weekend Guest 2", Player3Handicap = 17 },
            new() { MemberId = 2, BookingDate = todayDateOnly.AddDays(7), TeeTime = new TimeOnly(8, 15) },
            new() { MemberId = 3, BookingDate = todayDateOnly.AddDays(8), TeeTime = new TimeOnly(9, 30), Player2Name = "Sunday Guest 1", Player2Handicap = 14, Player3Name = "Sunday Guest 2", Player3Handicap = 10, Player4Name = "Sunday Guest 3", Player4Handicap = 9 },
            new() { MemberId = 4, BookingDate = todayDateOnly.AddDays(8), TeeTime = new TimeOnly(9, 45) },

            // Early morning bookings
            new() { MemberId = 5, BookingDate = todayDateOnly.AddDays(10), TeeTime = new TimeOnly(7, 0) },
            new() { MemberId = 6, BookingDate = todayDateOnly.AddDays(10), TeeTime = new TimeOnly(7, 15), Player2Name = "Early Guest", Player2Handicap = 8 },

            // Afternoon bookings
            new() { MemberId = 7, BookingDate = todayDateOnly.AddDays(12), TeeTime = new TimeOnly(15, 0) },
            new() { MemberId = 8, BookingDate = todayDateOnly.AddDays(12), TeeTime = new TimeOnly(15, 15), Player2Name = "Afternoon Guest 1", Player2Handicap = 19, Player3Name = "Afternoon Guest 2", Player3Handicap = 21 },

            // Late afternoon bookings
            new() { MemberId = 9, BookingDate = todayDateOnly.AddDays(14), TeeTime = new TimeOnly(17, 0), Player2Name = "Late Guest", Player2Handicap = 30 },
            new() { MemberId = 10, BookingDate = todayDateOnly.AddDays(14), TeeTime = new TimeOnly(17, 15) },

            // New member bookings - GC011 (Thomas Hughes)
            new() { MemberId = 11, BookingDate = todayDateOnly.AddDays(1), TeeTime = new TimeOnly(8, 30), Player2Name = "Anna Hughes", Player2Handicap = 18, Player3Name = "Tom Hughes Jr", Player3Handicap = 22 },
            new() { MemberId = 11, BookingDate = todayDateOnly.AddDays(6), TeeTime = new TimeOnly(11, 0) },
            new() { MemberId = 11, BookingDate = todayDateOnly.AddDays(13), TeeTime = new TimeOnly(16, 0), Player2Name = "Work Colleague", Player2Handicap = 15 },

            // GC012 (Rebecca Davis)
            new() { MemberId = 12, BookingDate = todayDateOnly.AddDays(2), TeeTime = new TimeOnly(7, 30) },
            new() { MemberId = 12, BookingDate = todayDateOnly.AddDays(9), TeeTime = new TimeOnly(10, 0), Player2Name = "Practice Partner", Player2Handicap = 5, Player3Name = "Competition Player", Player3Handicap = 7 },

            // GC013 (Christopher Thompson)
            new() { MemberId = 13, BookingDate = todayDateOnly.AddDays(3), TeeTime = new TimeOnly(14, 0), Player2Name = "Senior Friend", Player2Handicap = 21, Player3Name = "Club Mate", Player3Handicap = 19, Player4Name = "New Member", Player4Handicap = 28 },
            new() { MemberId = 13, BookingDate = todayDateOnly.AddDays(11), TeeTime = new TimeOnly(13, 30) },

            // GC014 (Amanda Roberts)
            new() { MemberId = 14, BookingDate = todayDateOnly.AddDays(4), TeeTime = new TimeOnly(12, 0), Player2Name = "Kevin Roberts", Player2Handicap = 16 },
            new() { MemberId = 14, BookingDate = todayDateOnly.AddDays(7), TeeTime = new TimeOnly(9, 0), Player2Name = "Ladies Captain", Player2Handicap = 9, Player3Name = "Team Member", Player3Handicap = 14 },

            // GC015 (Daniel Parker)
            new() { MemberId = 15, BookingDate = todayDateOnly.AddDays(1), TeeTime = new TimeOnly(11, 30), Player2Name = "College Friend", Player2Handicap = 6 },
            new() { MemberId = 15, BookingDate = todayDateOnly.AddDays(5), TeeTime = new TimeOnly(7, 45) },
            new() { MemberId = 15, BookingDate = todayDateOnly.AddDays(8), TeeTime = new TimeOnly(15, 30), Player2Name = "Pro-Am Partner 1", Player2Handicap = 3, Player3Name = "Pro-Am Partner 2", Player3Handicap = 5, Player4Name = "Professional", Player4Handicap = 0 },

            // GC016 (Sophie Mitchell)
            new() { MemberId = 16, BookingDate = todayDateOnly.AddDays(6), TeeTime = new TimeOnly(10, 30), Player2Name = "Ladies Group 1", Player2Handicap = 15, Player3Name = "Ladies Group 2", Player3Handicap = 17, Player4Name = "Ladies Group 3", Player4Handicap = 18 },
            new() { MemberId = 16, BookingDate = todayDateOnly.AddDays(12), TeeTime = new TimeOnly(14, 30) },

            // GC017 (Andrew Collins)
            new() { MemberId = 17, BookingDate = todayDateOnly.AddDays(2), TeeTime = new TimeOnly(12, 30), Player2Name = "Committee Member 1", Player2Handicap = 10, Player3Name = "Committee Member 2", Player3Handicap = 12 },
            new() { MemberId = 17, BookingDate = todayDateOnly.AddDays(10), TeeTime = new TimeOnly(8, 0), Player2Name = "Tournament Player", Player2Handicap = 8 },
            new() { MemberId = 17, BookingDate = todayDateOnly.AddDays(15), TeeTime = new TimeOnly(11, 15) },

            // GC018 (Jennifer Murphy)
            new() { MemberId = 18, BookingDate = todayDateOnly.AddDays(3), TeeTime = new TimeOnly(16, 30) },
            new() { MemberId = 18, BookingDate = todayDateOnly.AddDays(9), TeeTime = new TimeOnly(13, 0), Player2Name = "Coaching Friend", Player2Handicap = 14 },

            // GC019 (Matthew Bailey)
            new() { MemberId = 19, BookingDate = todayDateOnly.AddDays(4), TeeTime = new TimeOnly(7, 15), Player2Name = "Competition Rival", Player2Handicap = 2 },
            new() { MemberId = 19, BookingDate = todayDateOnly.AddDays(7), TeeTime = new TimeOnly(16, 0), Player2Name = "Scratch Player 1", Player2Handicap = 1, Player3Name = "Scratch Player 2", Player3Handicap = 4 },
            new() { MemberId = 19, BookingDate = todayDateOnly.AddDays(11), TeeTime = new TimeOnly(10, 15) },

            // GC020 (Rachel Foster)
            new() { MemberId = 20, BookingDate = todayDateOnly.AddDays(8), TeeTime = new TimeOnly(12, 15), Player2Name = "Steven Foster", Player2Handicap = 23, Player3Name = "Neighbor", Player3Handicap = 25 },
            new() { MemberId = 20, BookingDate = todayDateOnly.AddDays(14), TeeTime = new TimeOnly(15, 0) }
        };

        Bookings.AddRange(bookings);
        SaveChanges();
    }
}
