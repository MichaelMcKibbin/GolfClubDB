using GolfClubDB.Data;
using GolfClubDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GolfClubDB.Pages.Members;

public class EditModel(ApplicationDbContext context) : PageModel
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

        // Set defaults for date fields if they haven't been set
        if (Member.DateOfBirth == default(DateTime))
        {
            Member.DateOfBirth = new DateTime(1901, 1, 1);
        }

        if (Member.MembershipStartDate == default(DateTime))
        {
            Member.MembershipStartDate = DateTime.Today;
        }

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        _context.Members.Update(Member);

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!MemberExists(Member.Id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return RedirectToPage("Index");
    }

    private bool MemberExists(int id)
    {
        return _context.Members.Any(e => e.Id == id);
    }
}
