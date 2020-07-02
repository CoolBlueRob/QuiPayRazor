using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuiPayRazor.Data;
using QuiPayRazor.Models;

namespace QuiPayRazor.Pages.MemberIdentities
{
    public class EditModel : PageModel
    {
        private readonly QuiPayRazor.Data.QuiPayRazorContext _context;

        public EditModel(QuiPayRazor.Data.QuiPayRazorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MemberIdentity MemberIdentity { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MemberIdentity = await _context.MemberIdentity
                .Include(m => m.Member).FirstOrDefaultAsync(m => m.Id == id);

            if (MemberIdentity == null)
            {
                return NotFound();
            }
           ViewData["MemberID"] = new SelectList(_context.Member, "Id", "Id");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(MemberIdentity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MemberIdentityExists(MemberIdentity.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MemberIdentityExists(int id)
        {
            return _context.MemberIdentity.Any(e => e.Id == id);
        }
    }
}
