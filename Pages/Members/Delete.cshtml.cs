using GolfClubDB.Data;
using GolfClubDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GolfClubDB.Pages.Members;

public class DeleteModel(ApplicationDbContext context) : PageModel
{
    private readonly ApplicationDbContext _context = context;

    [BindProperty]
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

    public async Task<IActionResult> OnPostAsync(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        Member = await _context.Members.FindAsync(id);

        if (Member != null)
        {
            _context.Members.Remove(Member);
            await _context.SaveChangesAsync();
        }

        return RedirectToPage("Index");
    }
}
