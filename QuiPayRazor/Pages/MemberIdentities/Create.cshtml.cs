using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuiPayRazor.Data;
using QuiPayRazor.Models;

namespace QuiPayRazor.Pages.MemberIdentities
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
        ViewData["MemberID"] = new SelectList(_context.Member, "ID", "ID");
            return Page();
        }

        [BindProperty]
        public MemberIdentity MemberIdentity { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MemberIdentity.Add(MemberIdentity);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
