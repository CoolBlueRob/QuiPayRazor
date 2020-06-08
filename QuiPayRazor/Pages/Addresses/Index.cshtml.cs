using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using QuiPayRazor.Data;
using QuiPayRazor.Models;

namespace QuiPayRazor.Pages.Addresses
{
    public class IndexModel : PageModel
    {
        private readonly QuiPayRazor.Data.QuiPayRazorContext _context;

        public IndexModel(QuiPayRazor.Data.QuiPayRazorContext context)
        {
            _context = context;
        }

        public IList<Address> Address { get;set; }

        public string CitySort { get; set; }
        public string StateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public async Task OnGetAsync( string sortOrder )
        {
            CitySort = String.IsNullOrEmpty(sortOrder) ? "city_desc" : "";
            StateSort = sortOrder == "state" ? "state_desc" : "state";

            IQueryable<Address> iqAddress = from a in _context.Address
                                            select a;
            switch (sortOrder)
            {
                case "city_desc":
                    iqAddress = iqAddress.OrderByDescending(s => s.City);
                    break;
                case "state":
                    iqAddress = iqAddress.OrderBy(s => s.County);
                    break;
                case "state_desc":
                    iqAddress = iqAddress.OrderByDescending(s => s.County);
                    break;
                default:
                    iqAddress = iqAddress.OrderBy(s => s.AddressType);
                    break;
            }

            Address = await iqAddress.AsNoTracking().ToListAsync();
        }
    }
}
