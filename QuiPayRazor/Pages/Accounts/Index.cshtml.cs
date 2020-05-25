using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuiPayRazor.Data;
using QuiPayRazor.Models;

namespace QuiPayRazor.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly QuiPayRazor.Data.QuiPayRazorContext _context;

        public IndexModel(QuiPayRazor.Data.QuiPayRazorContext context)
        {
            _context = context;
        }

        public IList<Account> Account { get;set; }

        public async Task OnGetAsync()
        {
            Account = await _context.Account
                .Include(a => a.Balance).ToListAsync();
        }
    }
}
