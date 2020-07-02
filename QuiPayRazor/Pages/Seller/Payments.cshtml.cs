using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using QuiPayRazor.Data;
using QuiPayRazor.Logic.Interfaces;
using QuiPayRazor.Models;

namespace QuiPayRazor.Pages.Seller
{
    public class PaymentsModel : PageModel
    {
        private readonly QuiPayRazorContext _context;

        private IPaymentNotifier _iPaymentNotifier;

        private ILogger _logger;

        class AccountAndPayments
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public Currency Currency { get; set; }
            public List<Payment> PaymentsToAccount { get; set; }
        }

        class SellerAccountsAndPayments
        {
            public List<Account> accounts { get; set; }
        }

        public PaymentsModel(ILogger<PayModel> logger, QuiPayRazorContext context, IPaymentNotifier iPaymentNotifier)
        {
            _logger = logger;
            _context = context;
            _iPaymentNotifier = iPaymentNotifier;
        }

        public void OnGet( int paymentId)
        {
        }
    }
}
