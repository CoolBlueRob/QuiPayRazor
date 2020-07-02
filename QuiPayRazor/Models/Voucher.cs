using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuiPayRazor.Models
{
    public enum BankNoteState
    {
        Unprinted, Printed, Suspended
    }

    public class Voucher
    {
        [Key]
        public int Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public BankNoteState BankNoteState { get; set; }

        public int Printed { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WhenCreated { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }
    }
}
