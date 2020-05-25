using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuiPayRazor.Data;
using QuiPayRazor.Models;

namespace QuiPayRazor.Pages.MemberIdentities
{
    public class IndexModel : PageModel
    {
        private readonly QuiPayRazor.Data.QuiPayRazorContext _context;

        public IndexModel(QuiPayRazor.Data.QuiPayRazorContext context)
        {
            _context = context;
        }

        public IList<MemberIdentity> MemberIdentity { get;set; }

        public async Task OnGetAsync()
        {
            MemberIdentity = await _context.MemberIdentity
                .Include(m => m.Member).ToListAsync();
        }
    }
}
