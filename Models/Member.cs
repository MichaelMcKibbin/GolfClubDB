using System.ComponentModel.DataAnnotations;

namespace GolfClubDB.Models;

public class Member
{
    public int Id { get; set; }

    [Required]
    public string MembershipNumber { get; set; } = string.Empty;

    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = string.Empty;

    [Required]
    public string Gender { get; set; } = string.Empty;

    [Required]
    [Range(0, 54)]
    public int Handicap { get; set; }

    public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
}
