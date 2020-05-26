using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata;

namespace QuiPayRazor.Models
{
    public enum AccountState
    {
        Pending, Active, Suspicious, Suspended
    };

    public class Account
    {
        [Key]
        public int ID { get; set; }

        public AccountState AccountState { get; set; }

        public HomeBusinessOther AccountType { get; set; }

        public string Name { get; set; }

        public int MemberID { get; set; }

        public int CurrencyID { get; set; }

        [Column(TypeName = "decimal(5, 2)")]
        public decimal Amount { get; set; }

        public DateTime WhenCreated { get; set; }
    }
}
