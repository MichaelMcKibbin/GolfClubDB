using System.ComponentModel.DataAnnotations;

namespace GolfClubDB.Models;

public class Member
{
    public int Id { get; set; }

    [Required]
    public string MembershipNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;

    public DateTime DateOfBirth { get; set; }

    [Required]
    public DateTime MembershipStartDate { get; set; }

    public DateTime? MembershipEndDate { get; set; }

    public string? ProfileImage { get; set; }
    public string? Bio { get; set; }

    public string? EmergencyContactName { get; set; }

    public string? EmergencyContactPhone { get; set; }

    public string StreetAddress { get; set; } = string.Empty;

    public string StreetAddress2 { get; set; } = string.Empty;

    public string TownAddress { get; set; } = string.Empty;

    public string CountyAddress { get; set; } = string.Empty;

    public string Postcode { get; set; } = string.Empty;

    [Required]
    public string Gender { get; set; } = string.Empty;

    [Required]
    [Range(-20, 54)]
    public int Handicap { get; set; }

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
