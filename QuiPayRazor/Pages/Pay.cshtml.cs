using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using QuiPayRazor.Models;
using QuiPayRazor.Logic.Interfaces;
using SQLitePCL;
using Microsoft.Extensions.Logging;
using System.Data.Entity.Spatial;
using QuiPayRazor.Data;

namespace QuiPayRazor.Pages
{
    public class PayViewModel
    {
        [Display(Name = "Paid From")]
        public int FromAccountID { get; set; }   // Account this is paid from

        [Display(Name = "Paid To")]
        public int ToAccountID { get; set; }   // Accoun this is paid to.

        [Display(Name = "Amount")]
        public Decimal Amount { get; set; }

        [Display(Name = "Quantity")]
        [Range(0, 10000)]
        public Decimal Quantity { get; set; }

        [Display(Name = "Item")]
        [StringLength(256)]
        public string Item { get; set; }

        [Display(Name = "Buyers Comment")]
        [StringLength(256)]
        public string BuyersComment { get; set; }

        //[Display(Name = "Where Purchased")]
        //public DbGeography WhereOffered { get; set; }

        // Sellers comment is only set when the seller confirms.
        //[Display(Name = "Sellers Comment")]
        //[StringLength(256)]
        //public string SellersComment { get; set; }
    }

    public class PayModel : PageModel
    {
        private readonly QuiPayRazorContext _context;

        private IPaymentOfferedNotifier _iPaymentNotifier;

        private ILogger _logger;

        public PayModel(ILogger<PayModel> logger, QuiPayRazorContext context, IPaymentOfferedNotifier iPaymentNotifier)
        {
            _logger = logger;
            _context = context;
            _iPaymentNotifier = iPaymentNotifier;
        }

        [BindProperty]
        public PayViewModel PayViewModel { get; set; }

        public void OnGet( int payee )
        {
            PayViewModel = new PayViewModel
            {
                FromAccountID = 1,   // Paid by is logged in user.
                ToAccountID = payee,
                Amount = 0.0m,
                Quantity = 1,
                Item = "Goods",
                BuyersComment = "Thank you."
            };
        }

        public async Task<IActionResult> OnPostAsync()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Page();
                }

                DateTime now = DateTime.Now;

                Account fromAccount = _context.Account.Find(PayViewModel.FromAccountID);
                // To Do - confirm the FromAccount is owned by the logged in user.urn 

                if (fromAccount.Balance < fromAccount.MinimumAllowedBalance + PayViewModel.Amount)
                {
                    // We don't have funds!
                    // return insufficient funds
                    return RedirectToPage("Payment/InsufficientFunds/" + PayViewModel.FromAccountID.ToString());
                }
                fromAccount.Allocated += PayViewModel.Amount;
                fromAccount.Balance -= PayViewModel.Amount;

                Payment payment = new Payment
                {
                    PaymentState = PaymentState.Offered,
                    WhenOffered = now,
                    FromAccountId = PayViewModel.FromAccountID,
                    ToAccountId = PayViewModel.ToAccountID,
                    Amount = PayViewModel.Amount,
                    Quantity = PayViewModel.Quantity,
                    Item = PayViewModel.Item,
                    BuyersComment = PayViewModel.BuyersComment//,
                    //WhereOffered = PayViewModel.WhereOffered
                };

                _context.Payment.Add(payment);
                await _context.SaveChangesAsync();

                _iPaymentNotifier.NotifyPaymentOffered(payment);
                return Page();
            } catch (Exception ex) {
                _logger.LogError(ex, "An error occurred Pay.OnPostAsync " + ex.Message );
            }
            return RedirectToPage("Error/Payment/");
        }
    }
}