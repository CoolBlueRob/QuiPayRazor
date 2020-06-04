using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using QuiPayRazor.Models;

namespace QuiPayRazor.Pages.Enrol
{
    public class Enrolment
    {
        // Member Identity
        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        // Address
        public PersonalOrBusiness AddressType { get; set; }

        [StringLength(80)]
        public string Address1 { get; set; }

        [StringLength(80)]
        public string Address2 { get; set; }

        [StringLength(80)]
        public string Address3 { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string State { get; set; }

        [StringLength(20)]
        public string CountryCode { get; set; }

        [StringLength(20)]
        public string ZipCode { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }
    }

    public class EnrolModel : PageModel
    {
        private readonly QuiPayRazor.Data.QuiPayRazorContext _context;

        public EnrolModel(QuiPayRazor.Data.QuiPayRazorContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Enrolment Enrolment { get; set; }

        public SelectList AddressTypeSL { get; set; }

        public void OnGet()
        {
            AddressTypeSL = new SelectList(new List<string> { "Personal", "Business" });
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            DateTime now = DateTime.Now;

            var address = new Address
            {
                AddressType = Enrolment.AddressType,
                Address1 = Enrolment.Address1,
                Address2 = Enrolment.Address2,
                Address3 = Enrolment.Address3,
                City = Enrolment.City,
                State = Enrolment.State,
                CountryCode = Enrolment.CountryCode,
                ZipCode = Enrolment.ZipCode,
                WhenCreated = now

            };

            var phoneNumber = new PhoneNumber
            {
                Phone = Enrolment.Phone,
                AddressType = Enrolment.AddressType,
                WhenCreated = now
            };

            var emailAddress = new EmailAddress
            {
                Email = Enrolment.Email,
                AddressType = Enrolment.AddressType,
                WhenCreated = now
            };

            var memberIdentity = new MemberIdentity
            {
                Title = Enrolment.Title,
                FirstName = Enrolment.FirstName,
                LastName = Enrolment.LastName,
                Addresses = new List<Address> { address },
                EmailAddresses = new List<EmailAddress> { emailAddress },
                PhoneNumbers = new List<PhoneNumber> { phoneNumber },
                WhenCreated = now
            };

            var account = new Account
            {
                AccountState = AccountState.Active,
                AccountType = Enrolment.AddressType,
                Name = Enrolment.Title + " " + Enrolment.FirstName + " " + Enrolment.LastName,
                CurrencyID = 1,
                Amount = 0,
                WhenCreated = now
            };

            var member = new Member
            {
                MemberIdentitys = new List<MemberIdentity> {
                    memberIdentity },
                Accounts = new List<Account> { account },
                WhenCreated = now
            };

            _context.Member.Add(member);
            await _context.SaveChangesAsync();

            var memberId = member.ID;

            return RedirectToPage("Members/Details/" + memberId);
        }
    }
}