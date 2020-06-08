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
        [StringLength(20)]
        [Display(Name = "Title",
        Prompt = "Enter Title", Description = "Mr Mrs Miss etc")]
        public string Title { get; set; }
        
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        // Address
        [Display(Name = "Personal or Business")]
        public PersonalOrBusiness AddressType { get; set; }

        [StringLength(80)]
        [Display(Name = "Address 1")]
        public string Address1 { get; set; }

        [StringLength(80)]
        [Display(Name = "Address 2")]
        public string Address2 { get; set; }

        [StringLength(80)]
        [Display(Name = "Address 3")]
        public string Address3 { get; set; }

        [StringLength(50)]
        [Display(Name = "Town/City")]
        public string City { get; set; }

        [StringLength(50)]
        [Display(Name = "County")]
        public string County { get; set; }

        [StringLength(20)]
        [Display(Name = "Post Code")]
        [DataType(DataType.PostalCode)]
        public string PostCode { get; set; }

        [StringLength(20)]
        [Display(Name = "Country")]
        public string CountryCode { get; set; }

        [StringLength(80)]
        [Display(Name = "Email Address")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(40)]
        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber)]
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

        public void OnGet()
        {
      
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
                County = Enrolment.County,
                CountryCode = Enrolment.CountryCode,
                PostCode = Enrolment.PostCode,
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