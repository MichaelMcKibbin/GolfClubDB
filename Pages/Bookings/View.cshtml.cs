using GolfClubDB.Data;
using GolfClubDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GolfClubDB.Pages.Bookings;

public class ViewModel(ApplicationDbContext context) : PageModel
{
    private readonly ApplicationDbContext _context = context;

    public Booking Booking { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Booking = await _context.Bookings
            .AsNoTracking()
            .Include(b => b.Member)
            .FirstOrDefaultAsync(b => b.Id == id);

        if (Booking == null)
        {
            return NotFound();
        }

        return Page();
    }
}
