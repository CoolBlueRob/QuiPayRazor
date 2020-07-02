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

namespace QuiPayRazor.Pages.VoucherAccountLuts
{
    public class EditModel : PageModel
    {
        private readonly QuiPayRazor.Data.QuiPayRazorContext _context;

        public EditModel(QuiPayRazor.Data.QuiPayRazorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VoucherAccountLut VoucherAccountLut { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VoucherAccountLut = await _context.VoucherAccountLut
                .Include(v => v.Account)
                .Include(v => v.BankNote).FirstOrDefaultAsync(m => m.Id == id);

            if (VoucherAccountLut == null)
            {
                return NotFound();
            }
           ViewData["AccountID"] = new SelectList(_context.Account, "Id", "Id");
           ViewData["BankNoteID"] = new SelectList(_context.Voucher, "Id", "Id");
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

            _context.Attach(VoucherAccountLut).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VoucherAccountLutExists(VoucherAccountLut.Id))
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

        private bool VoucherAccountLutExists(int id)
        {
            return _context.VoucherAccountLut.Any(e => e.Id == id);
        }
    }
}
