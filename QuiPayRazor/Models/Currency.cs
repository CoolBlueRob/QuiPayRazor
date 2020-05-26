﻿using System;
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

        public string Symbol { get; set; }

        public string Note { get; set; }

        public string NoteSymbol { get; set; }

        public string Coin { get; set; }

        public string CoinSymbol { get; set; }

        public DateTime WhenCreated { get; set; }
    }
}
