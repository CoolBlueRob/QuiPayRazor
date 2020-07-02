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
            try
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

                var members = new Member[]
                {
                    new Member
                    {
                        MemberState = MemberState.Approved,
                        WhenCreated = DateTime.Now
                    },

                    new Member
                    {
                        MemberState = MemberState.Approved,
                        WhenCreated = DateTime.Now
                    },

                    new Member
                    {
                        MemberState = MemberState.Approved,
                        WhenCreated = DateTime.Now
                    }
                };
                context.Member.AddRange(members);
                context.SaveChanges();

                var accounts = new Account[]
                {
                new Account {
                    AccountState = AccountState.Active,
                    AccountType = PersonalOrBusiness.Personal,
                    Name = "Personal Account",
                    MemberId = 1,
                    CurrencyId = 1,
                    Balance = 100.0m,
                    Allocated = 0.0m,
                    WhenCreated = DateTime.Now
                },

                new Account {
                    AccountState = AccountState.Active,
                    AccountType = PersonalOrBusiness.Personal,
                    Name = "Personal Account 2",
                    MemberId = 2,
                    CurrencyId = 1,
                    Balance = 100.0m,
                    Allocated = 0.0m,
                    WhenCreated = DateTime.Now
                },

                new Account {
                    AccountState = AccountState.Active,
                    AccountType = PersonalOrBusiness.Business,
                    Name = "Business Account",
                    MemberId = 2,
                    CurrencyId = 1,
                    Balance = 100.0m,
                    Allocated = 0.0m,
                    WhenCreated = DateTime.Now
                }
                };
                context.Account.AddRange(accounts);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
