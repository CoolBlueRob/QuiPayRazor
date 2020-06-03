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

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public AccountState AccountState { get; set; }

        public HomeBusinessOther AccountType { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int MemberID { get; set; }

        public int CurrencyID { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WhenCreated { get; set; }
    }
}
