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
    public class DetailsModel : PageModel
    {
        private readonly QuiPayRazor.Data.QuiPayRazorContext _context;

        public DetailsModel(QuiPayRazor.Data.QuiPayRazorContext context)
        {
            _context = context;
        }

        public MemberTrust MemberTrust { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MemberTrust = await _context.MemberTrust.FirstOrDefaultAsync(m => m.ID == id);

            if (MemberTrust == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
