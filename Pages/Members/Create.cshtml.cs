using GolfClubDB.Data;
using GolfClubDB.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace GolfClubDB.Pages.Members;

public class CreateModel(ApplicationDbContext context) : PageModel
{
    private readonly ApplicationDbContext _context = context;

    [BindProperty]
    public Member Member { get; set; } = new();

    public string? NextMembershipNumber { get; set; }

    public async Task OnGetAsync()
    {
        NextMembershipNumber = await GenerateNextMembershipNumberAsync();
        Member.MembershipNumber = NextMembershipNumber;
        Member.DateOfBirth = new DateTime(1901, 1, 1);
        Member.MembershipStartDate = DateTime.Today;
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        // Ensure the membership number is set (in case of manual POST without GET)
        if (string.IsNullOrEmpty(Member.MembershipNumber))
        {
            Member.MembershipNumber = await GenerateNextMembershipNumberAsync();
        }

        _context.Members.Add(Member);
        await _context.SaveChangesAsync();

        return RedirectToPage("Index");
    }

    private async Task<string> GenerateNextMembershipNumberAsync()
    {
        // Get the highest membership number from the database
        var lastMember = await _context.Members
            .Where(m => m.MembershipNumber.StartsWith("GC"))
            .OrderByDescending(m => m.MembershipNumber)
            .FirstOrDefaultAsync();

        if (lastMember == null)
        {
            // No members exist yet, start with GC0001
            return "GC0001";
        }

        // Extract the numeric part and increment
        if (int.TryParse(lastMember.MembershipNumber.Substring(2), out int lastNumber))
        {
            int nextNumber = lastNumber + 1;
            return $"GC{nextNumber:D4}";
        }

        // Fallback if parsing fails
        return "GC0001";
    }
}
