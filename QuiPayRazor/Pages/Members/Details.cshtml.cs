using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuiPayRazor.Data;
using QuiPayRazor.Models;

namespace QuiPayRazor.Pages.Members
{
    public class DetailsModel : PageModel
    {
        private readonly QuiPayRazor.Data.QuiPayRazorContext _context;

        public DetailsModel(QuiPayRazor.Data.QuiPayRazorContext context)
        {
            _context = context;
        }

        public Member Member { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Member = await _context.Member.FirstOrDefaultAsync(m => m.Id == id);

            Member = await _context.Member
                .Include(m => m.MemberIdentitys)
                .ThenInclude(mi => mi.Addresses)
                .Include(m => m.Accounts)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Member == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
