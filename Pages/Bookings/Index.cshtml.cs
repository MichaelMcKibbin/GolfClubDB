using GolfClubDB.Data;
using GolfClubDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GolfClubDB.Pages.Bookings;

public class IndexModel(ApplicationDbContext context) : PageModel
{
    private readonly ApplicationDbContext _context = context;

    public IList<Booking> Bookings { get; set; } = new List<Booking>();
    public Member? FilteredMember { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? MemberId { get; set; }

    public async Task OnGetAsync()
    {
        var bookingsQuery = _context.Bookings.AsNoTracking();

        if (MemberId.HasValue)
        {
            bookingsQuery = bookingsQuery.Where(b => b.MemberId == MemberId.Value);
            FilteredMember = await _context.Members
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == MemberId.Value);
        }

        Bookings = await bookingsQuery
            .Include(b => b.Member)
            .OrderBy(b => b.BookingDate)
            .ThenBy(b => b.TeeTime)
            .ToListAsync();
    }
}
