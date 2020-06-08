using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

namespace QuiPayRazor.Models
{
    public enum PaymentState
    {
        Offered, Accepted, Declined
    }

    public class Payment
    {
        [Key]
        public int ID { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public PaymentState PaymentState { get; set; }

        public int FromAccountID { get; set; }
        
        public int ToAccountID { get; set; }

        [StringLength(200)]
        public string Note { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WhenProposed { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WhenAccepted { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WhenDeclined { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }

        public int RefundPaymentID { get; set; }
    }
}
