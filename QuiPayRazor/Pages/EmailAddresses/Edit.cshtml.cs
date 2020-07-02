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

namespace QuiPayRazor.Pages.EmailAddresses
{
    public class EditModel : PageModel
    {
        private readonly QuiPayRazor.Data.QuiPayRazorContext _context;

        public EditModel(QuiPayRazor.Data.QuiPayRazorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public EmailAddress EmailAddress { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            EmailAddress = await _context.EmailAddress
                .Include(e => e.MemberIdentity).FirstOrDefaultAsync(m => m.Id == id);

            if (EmailAddress == null)
            {
                return NotFound();
            }
           ViewData["MemberIdentityID"] = new SelectList(_context.MemberIdentity, "Id", "Id");
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

            _context.Attach(EmailAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailAddressExists(EmailAddress.Id))
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

        private bool EmailAddressExists(int id)
        {
            return _context.EmailAddress.Any(e => e.Id == id);
        }
    }
}
