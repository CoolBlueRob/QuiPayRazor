using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuiPayRazor.Models
{
    public enum CurrencyState
    {
        Pending, Active, Suspicious, Suspended
    };

    public class Currency
    {
        [Key]
        public int Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public CurrencyState CurrencyState { get; set; }

        [StringLength(40)]
        public string Name { get; set; }

        [StringLength(8)]
        public string Symbol { get; set; }

        [StringLength(8)]
        public string Note { get; set; }

        [StringLength(8)]
        public string NoteSymbol { get; set; }

        [StringLength(8)]
        public string Coin { get; set; }

        [StringLength(8)]
        public string CoinSymbol { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WhenCreated { get; set; }
    }
}
