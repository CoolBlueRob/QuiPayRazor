using QuiPayRazor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuiPayRazor.Data
{
    public class DbInitializer
    {
        public static void Initialize(QuiPayRazorContext context)
        {
            context.Database.EnsureCreated();

            if (context.Currency.Any())
            {
                return;
            }


            

            var currencies = new Currency[]
            {
                new Currency{ CurrencyState = CurrencyState.Active,
                    Name = "Sterling",
                    Symbol = "GBP",
                    Note = "Pound",
                    Coin = "Pence",
                    NoteSymbol = "£",
                    CoinSymbol = "p",
                    WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 ) },

                new Currency{ CurrencyState = CurrencyState.Active,
                    Name = "Dollar",
                    Symbol = "USD",
                    Note = "Dollar",
                    Coin = "Cent",
                    NoteSymbol = "$",
                    CoinSymbol = "c",
                    WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 ) },

                new Currency{ CurrencyState = CurrencyState.Active,
                    Name = "Euro",
                    Symbol = "EUR",
                    Note = "Euro",
                    Coin = "Cent",
                    NoteSymbol = "E",
                    CoinSymbol = "c",
                    WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 ) },

                 new Currency{ CurrencyState = CurrencyState.Active,
                    Name = "Cobb",
                    Symbol = "COB",
                    Note = "Cobb",
                    Coin = "Cent",
                    NoteSymbol = "C",
                    CoinSymbol = "c",
                    WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 ) },
            };
            context.Currency.AddRange(currencies);
            context.SaveChanges();
        }
    }
}
