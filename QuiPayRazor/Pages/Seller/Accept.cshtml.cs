using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QuiPayRazor.Data;
using QuiPayRazor.Logic.Interfaces;

namespace QuiPayRazor.Pages.Seller
{
    public class AcceptModel : PageModel
    {
        private readonly QuiPayRazorContext _context;

        private ILogger _logger;

        private IPaymentAcceptedNotifier _iPaymentAcceptedNotifier;

        public AcceptModel(ILogger<AcceptModel> logger, QuiPayRazorContext context, IPaymentAcceptedNotifier iPaymentAcceptedNotifier)
        {
            _logger = logger;
            _context = context;
            _iPaymentAcceptedNotifier = iPaymentAcceptedNotifier;
        }

        public void OnGet( int MemberId)
        {
        }
    }
}
