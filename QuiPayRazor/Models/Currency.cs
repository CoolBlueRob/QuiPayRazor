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
        public int ID { get; set; }

        public CurrencyState CurrencyState { get; set; }

        public string Name { get; set; }

        public DateTime WhenCreated { get; set; }
    }
}
