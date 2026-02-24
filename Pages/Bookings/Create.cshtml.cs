using GolfClubDB.Data;
using GolfClubDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GolfClubDB.Pages.Bookings;

public class CreateModel(ApplicationDbContext context) : PageModel
{
    private readonly ApplicationDbContext _context = context;

    [BindProperty]
    public Booking Booking { get; set; } = new();

    public SelectList MemberOptions { get; set; } = default!;

    public async Task<IActionResult> OnGetAsync()
    {
        // Set default booking date to today
        Booking.BookingDate = DateOnly.FromDateTime(DateTime.Today);
        
        await LoadMembersAsync();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        await LoadMembersAsync();

        if (Booking.TeeTime.Minute % 15 != 0)
        {
            ModelState.AddModelError("Booking.TeeTime", "Tee times must be in 15-minute intervals.");
        }

        var existingBooking = await _context.Bookings
            .AsNoTracking()
            .AnyAsync(b => b.MemberId == Booking.MemberId && b.BookingDate == Booking.BookingDate);

        if (existingBooking)
        {
            ModelState.AddModelError(string.Empty, "This member already has a booking for the selected date.");
        }

        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Bookings.Add(Booking);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError(string.Empty, "Unable to save booking. Ensure the member does not already have a booking for the selected date.");
            return Page();
        }

        return RedirectToPage("./Index");
    }

    private async Task LoadMembersAsync()
    {
        var members = await _context.Members
            .AsNoTracking()
            .OrderBy(m => m.LastName)
            .ThenBy(m => m.FirstName)
            .ToListAsync();

        // Create display text as "LastName, FirstName"
        MemberOptions = new SelectList(
            members.Select(m => new { m.Id, DisplayName = $"{m.LastName}, {m.FirstName}" }),
            nameof(Member.Id),
            "DisplayName"
        );
    }
}
