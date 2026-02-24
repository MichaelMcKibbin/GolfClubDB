using GolfClubDB.Data;
using GolfClubDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GolfClubDB.Pages.Members;

public class IndexModel(ApplicationDbContext context) : PageModel
{
    private readonly ApplicationDbContext _context = context;

    public IList<Member> Members { get; set; } = new List<Member>();
    public string? CurrentSort { get; set; }
    public string? NameSort { get; set; }
    public string? HandicapSort { get; set; }
    public string? MembershipNumberSort { get; set; }

    [BindProperty(SupportsGet = true)]
    public string? GenderFilter { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? HandicapMin { get; set; }

    [BindProperty(SupportsGet = true)]
    public int? HandicapMax { get; set; }

    public SelectList GenderOptions { get; set; } = default!;

    public async Task OnGetAsync(string? sortOrder)
    {
        CurrentSort = sortOrder;

        NameSort = sortOrder == "name_desc" ? "name_asc" : "name_desc";
        HandicapSort = sortOrder == "handicap_desc" ? "handicap_asc" : "handicap_desc";
        MembershipNumberSort = sortOrder == "membernumber_desc" ? "membernumber_asc" : "membernumber_desc";

        GenderOptions = new SelectList(await _context.Members
            .AsNoTracking()
            .Select(m => m.Gender)
            .Distinct()
            .OrderBy(g => g)
            .ToListAsync());

        var membersQuery = _context.Members.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(GenderFilter))
        {
            membersQuery = membersQuery.Where(m => m.Gender == GenderFilter);
        }

        if (HandicapMin.HasValue)
        {
            membersQuery = membersQuery.Where(m => m.Handicap >= HandicapMin.Value);
        }

        if (HandicapMax.HasValue)
        {
            membersQuery = membersQuery.Where(m => m.Handicap <= HandicapMax.Value);
        }

        membersQuery = sortOrder switch
        {
            "name_desc" => membersQuery.OrderByDescending(m => m.LastName).ThenByDescending(m => m.FirstName),
            "handicap_asc" => membersQuery.OrderBy(m => m.Handicap),
            "handicap_desc" => membersQuery.OrderByDescending(m => m.Handicap),
            "membernumber_asc" => membersQuery.OrderBy(m => m.MembershipNumber),
            "membernumber_desc" => membersQuery.OrderByDescending(m => m.MembershipNumber),
            _ => membersQuery.OrderBy(m => m.LastName).ThenBy(m => m.FirstName)
        };

        Members = await membersQuery.ToListAsync();
    }
}
