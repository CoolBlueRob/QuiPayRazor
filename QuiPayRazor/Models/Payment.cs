using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Data.Entity.Spatial;


namespace QuiPayRazor.Models
{
    public enum PaymentState
    {
        Offered, Accepted, Declined
    }

    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public PaymentState PaymentState { get; set; }

        [ForeignKey("Id")]
        public int? FromAccountId { get; set; }
        virtual public Account FromAccount { get; set; }

        [ForeignKey("Id")]
        public int? ToAccountId { get; set; }
        virtual public Account ToAccount { get; set; }

        public Decimal Quantity { get; set; }

        [StringLength(40)]
        public string Item { get; set; }

        [StringLength(256)]
        public string BuyersComment { get; set; }

        [StringLength(256)]
        public string SellersComment { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WhenOffered { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WhenAccepted { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WhenDeclined { get; set; }

        public string WhereOffered { get; set; }    // Could not get DbGeography to work.

        public string WhereAccepted { get; set; }
        
        public string WhereDeclined { get; set; }

        [DataType(DataType.Currency)]
        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }

        public int? RefundPaymentId { get; set; }
        virtual public Payment RefundPayment { get; set; }
    }
}
