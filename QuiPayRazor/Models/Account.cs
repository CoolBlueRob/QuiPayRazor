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
        public int Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public AccountState AccountState { get; set; }

        public PersonalOrBusiness AccountType { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int MemberId { get; set; }
        public virtual Member Member { get; set; }

        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        public decimal Balance { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        public decimal MinimumAllowedBalance { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        public decimal Allocated { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WhenCreated { get; set; }

        [InverseProperty("ToAccount")]
        virtual public List<Payment> ToAccounts { get; set; }

        [InverseProperty("FromAccount")]
        virtual public List<Payment> FromAccounts { get; set; }
    }
}
