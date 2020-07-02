using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuiPayRazor.Data;
using QuiPayRazor.Models;

namespace QuiPayRazor.Pages.VoucherAccountLuts
{
    public class DeleteModel : PageModel
    {
        private readonly QuiPayRazor.Data.QuiPayRazorContext _context;

        public DeleteModel(QuiPayRazor.Data.QuiPayRazorContext context)
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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VoucherAccountLut = await _context.VoucherAccountLut.FindAsync(id);

            if (VoucherAccountLut != null)
            {
                _context.VoucherAccountLut.Remove(VoucherAccountLut);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
