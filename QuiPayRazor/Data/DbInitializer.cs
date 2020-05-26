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

            if (context.MemberIdentity.Any())
            {
                return;
            }

            var members = new Member[]
            {
                    new Member
                    {
                        MemberState = MemberState.Approved,
                        WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 )
                    },

                    new Member
                    {
                        MemberState = MemberState.Approved,
                        WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 )
                    },

                    new Member
                    {
                        MemberState = MemberState.Approved,
                        WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 )
                    }
            };
            context.Member.AddRange(members);
            context.SaveChanges();

            var memberIdentities = new MemberIdentity[]
            {
                    new MemberIdentity{ MemberDetailsState = MemberDetailsState.Approved,
                        Title = "Mr",
                        FirstName = "Rob",
                        LastName = "Smith",
                        WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 ),
                        MemberID = 1
                    },

                    new MemberIdentity{ MemberDetailsState = MemberDetailsState.Approved,
                        Title = "Mr",
                        FirstName = "John",
                        LastName = "Jones",
                        WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 ),
                        MemberID = 2
                    },

                    new MemberIdentity{ MemberDetailsState = MemberDetailsState.Approved,
                        Title = "Mr",
                        FirstName = "Bill",
                        LastName = "Gates",
                        WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 ),
                        MemberID = 3
                    }
            };
            context.MemberIdentity.AddRange(memberIdentities);
            context.SaveChanges();

            var addresses = new Address[]
            {
                    new Address{ AddressTyoe = HomeBusinessOther.Home,
                        Address1 = "Home",
                        Address2 = "Home Road",
                        City = "Home Town",
                        State = "Home County",
                        CountryCode = "UK",
                        ZipCode = "Home Zip",
                        WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 ),
                        MemberIdentityID = 1
                    },

                    new Address{ AddressTyoe = HomeBusinessOther.Home,
                        Address1 = "5",
                        Address2 = "Any Road",
                        City = "Any Town",
                        State = "Any County",
                        CountryCode = "UK",
                        ZipCode = "Any Zip",
                        WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 ),
                        MemberIdentityID = 2
                    },

                    new Address{ AddressTyoe = HomeBusinessOther.Business,
                        Address1 = "1",
                        Address2 = "Bill Road",
                        City = "Bill Town",
                        State = "Bill County",
                        CountryCode = "USA",
                        ZipCode = "Bill Zip",
                        WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 ),
                        MemberIdentityID = 3
                    }
            };
            context.Address.AddRange(addresses);
            context.SaveChanges();

            var emailAddresses = new EmailAddress[]
            {
                    new EmailAddress{ AddressTyoe = HomeBusinessOther.Home,
                        Email = "bob@coolbluesoftware.com",
                        MemberIdentityID = 1
                    },

                    new EmailAddress{ AddressTyoe = HomeBusinessOther.Home,
                        Email = "bob@coolbluesoftware.com",
                        MemberIdentityID = 1
                    },

                    new EmailAddress{ AddressTyoe = HomeBusinessOther.Business,
                        Email = "bob@coolbluesoftware.com",
                        MemberIdentityID = 1
                    }
            };
            context.EmailAddress.AddRange(emailAddresses);
            context.SaveChanges();

            var phoneNumbes = new PhoneNumber[]
            {           
                    new PhoneNumber{ AddressTyoe = HomeBusinessOther.Home,
                        Phone = "07817716237",
                        MemberIdentityID = 1
                    },

                    new PhoneNumber{ AddressTyoe = HomeBusinessOther.Home,
                        Phone = "07817716237",
                        MemberIdentityID = 1
                    },

                    new PhoneNumber{ AddressTyoe = HomeBusinessOther.Business,
                        Phone = "07817716237",
                        MemberIdentityID = 1
                    }
            };
            context.PhoneNumber.AddRange(phoneNumbes);
            context.SaveChanges();

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
            context.PhoneNumber.AddRange(phoneNumbes);
            context.SaveChanges();

            var accounts = new Account[]
            {
                new Account
                {
                    AccountState = AccountState.Active,
                    AccountType = HomeBusinessOther.Home,
                    Name = "Current",
                    MemberID = 1,
                    CurrencyID = 4,
                    Amount = 1.00m,
                    WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 )
                },

                new Account
                {
                    AccountState = AccountState.Active,
                    AccountType = HomeBusinessOther.Business,
                    Name = "Business",
                    MemberID = 2,
                    CurrencyID = 4,
                    Amount = 5.00m,
                    WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 )
                },

                new Account
                {
                    AccountState = AccountState.Active,
                    AccountType = HomeBusinessOther.Home,
                    Name = "Current",
                    MemberID = 3,
                    CurrencyID = 1,
                    Amount = 5.00m,
                    WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 )
                }
            };

            context.Account.AddRange(accounts);
            context.SaveChanges();
        }
    }
}
