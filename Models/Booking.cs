using System.ComponentModel.DataAnnotations;

namespace GolfClubDB.Models;

public class Booking
{
    public int Id { get; set; }

    [Required]
    public int MemberId { get; set; }

    public Member? Member { get; set; }

    [Required]
    [DataType(DataType.Date)]
    public DateOnly BookingDate { get; set; }

    [Required]
    [DataType(DataType.Time)]
    public TimeOnly TeeTime { get; set; }

    public string? Player1Name { get; set; }

    [Range(0, 54)]
    public int? Player1Handicap { get; set; }

    public string? Player2Name { get; set; }

    [Range(0, 54)]
    public int? Player2Handicap { get; set; }

    public string? Player3Name { get; set; }

    [Range(0, 54)]
    public int? Player3Handicap { get; set; }

    public string? Player4Name { get; set; }

    [Range(0, 54)]
    public int? Player4Handicap { get; set; }
}
