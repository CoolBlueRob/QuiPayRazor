using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuiPayRazor.Models
{
    public enum BankNoteAccountLutState
    {
        Current, Historic
    }

    public class VoucherAccountLut
    {
        [Key]
        public int Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public BankNoteAccountLutState BankNoteAccountLutState { get; set; }

        public int BankNoteId { get; set; }

        public int AccountId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WhenCreated { get; set; }

        public virtual Voucher BankNote { get; set;}

        public virtual Account Account { get; set;}
    }
}
    