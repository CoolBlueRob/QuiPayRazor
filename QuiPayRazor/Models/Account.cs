using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public Currency Balance { get; set; }

        public int MemberID { get; set; }

        public int CurrencyID { get; set; }

        public DateTime WhenCreated { get; set; }
    }
}
