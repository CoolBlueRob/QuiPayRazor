using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using QuiPayRazor.Models;

namespace QuiPayRazor.Data
{
    public class QuiPayRazorContext : DbContext
    {
        public QuiPayRazorContext (DbContextOptions<QuiPayRazorContext> options)
            : base(options)
        {
        }

        public DbSet<QuiPayRazor.Models.Account> Account { get; set; }

        public DbSet<QuiPayRazor.Models.MemberIdentity> MemberIdentity { get; set; }

        public DbSet<QuiPayRazor.Models.Member> Member { get; set; }

        public DbSet<QuiPayRazor.Models.Payment> Payment { get; set; }

        public DbSet<QuiPayRazor.Models.Currency> Currency { get; set; }

        public DbSet<QuiPayRazor.Models.Address> Address { get; set; }

        public DbSet<QuiPayRazor.Models.EmailAddress> EmailAddress { get; set; }

        public DbSet<QuiPayRazor.Models.MemberTrust> MemberTrust { get; set; }

        public DbSet<QuiPayRazor.Models.PhoneNumber> PhoneNumber { get; set; }

        public DbSet<QuiPayRazor.Models.Voucher> Voucher { get; set; }

        public DbSet<QuiPayRazor.Models.VoucherAccountLut> VoucherAccountLut { get; set; }

    }
}
