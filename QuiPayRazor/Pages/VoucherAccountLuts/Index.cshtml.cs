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
    public class IndexModel : PageModel
    {
        private readonly QuiPayRazor.Data.QuiPayRazorContext _context;

        public IndexModel(QuiPayRazor.Data.QuiPayRazorContext context)
        {
            _context = context;
        }

        public IList<VoucherAccountLut> VoucherAccountLut { get;set; }

        public async Task OnGetAsync()
        {
            VoucherAccountLut = await _context.VoucherAccountLut
                .Include(v => v.Account)
                .Include(v => v.BankNote).ToListAsync();
        }
    }
}
