using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuiPayRazor.Data;
using QuiPayRazor.Models;

namespace QuiPayRazor.Pages.Vouchers
{
    public class DetailsModel : PageModel
    {
        private readonly QuiPayRazor.Data.QuiPayRazorContext _context;

        public DetailsModel(QuiPayRazor.Data.QuiPayRazorContext context)
        {
            _context = context;
        }

        public Voucher Voucher { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Voucher = await _context.Voucher.FirstOrDefaultAsync(m => m.Id == id);

            if (Voucher == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
