using GolfClubDB.Data;
using GolfClubDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GolfClubDB.Pages.Members;

public class ViewModel(ApplicationDbContext context) : PageModel
{
    private readonly ApplicationDbContext _context = context;

    public Member Member { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Member = await _context.Members.FirstOrDefaultAsync(m => m.Id == id);

        if (Member == null)
        {
            return NotFound();
        }

        return Page();
    }
}
