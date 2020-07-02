using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuiPayRazor.Data;
using QuiPayRazor.Models;

namespace QuiPayRazor.Pages.VoucherAccountLuts
{
    public class CreateModel : PageModel
    {
        private readonly QuiPayRazor.Data.QuiPayRazorContext _context;

        public CreateModel(QuiPayRazor.Data.QuiPayRazorContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AccountID"] = new SelectList(_context.Account, "Id", "Id");
        ViewData["BankNoteID"] = new SelectList(_context.Voucher, "Id", "Id");
            return Page();
        }

        [BindProperty]
        public VoucherAccountLut VoucherAccountLut { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.VoucherAccountLut.Add(VoucherAccountLut);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
