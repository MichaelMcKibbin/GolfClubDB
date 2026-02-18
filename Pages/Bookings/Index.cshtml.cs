using GolfClubDB.Data;
using GolfClubDB.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GolfClubDB.Pages.Bookings;

public class IndexModel(ApplicationDbContext context) : PageModel
{
    private readonly ApplicationDbContext _context = context;

    public IList<Booking> Bookings { get; set; } = new List<Booking>();

    public async Task OnGetAsync()
    {
        Bookings = await _context.Bookings
            .AsNoTracking()
            .Include(b => b.Member)
            .OrderBy(b => b.BookingDate)
            .ThenBy(b => b.TeeTime)
            .ToListAsync();
    }
}
