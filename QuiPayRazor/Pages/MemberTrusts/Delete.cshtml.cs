using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuiPayRazor.Data;
using QuiPayRazor.Models;

namespace QuiPayRazor.Pages.MemberTrusts
{
    public class DeleteModel : PageModel
    {
        private readonly QuiPayRazor.Data.QuiPayRazorContext _context;

        public DeleteModel(QuiPayRazor.Data.QuiPayRazorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MemberTrust MemberTrust { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MemberTrust = await _context.MemberTrust.FirstOrDefaultAsync(m => m.Id == id);

            if (MemberTrust == null)
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

            MemberTrust = await _context.MemberTrust.FindAsync(id);

            if (MemberTrust != null)
            {
                _context.MemberTrust.Remove(MemberTrust);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
