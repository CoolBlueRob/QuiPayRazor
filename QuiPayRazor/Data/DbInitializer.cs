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

            var addresses = new Address[]
            {
                    new Address{ AddressTyoe = AddressTyoe.Home,
                        Address1 = "Home",
                        Address2 = "Home Road",
                        City = "Home Town",
                        State = "Home County",
                        CountryCode = "UK",
                        ZipCode = "Home Zip",
                        WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 ),
                        MemberIdentityID = 1
                    },

                    new Address{ AddressTyoe = AddressTyoe.Home,
                        Address1 = "5",
                        Address2 = "Any Road",
                        City = "Any Town",
                        State = "Any County",
                        CountryCode = "UK",
                        ZipCode = "Any Zip",
                        WhenCreated = new DateTime( 2020, 5, 24, 20, 30, 0 ),
                        MemberIdentityID = 2
                    },

                    new Address{ AddressTyoe = AddressTyoe.Business,
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

            var emailAddresses = new EmailAddress[]
            {
                    new EmailAddress{ AddressTyoe = AddressTyoe.Home,
                        Email = "bob@coolbluesoftware.com",
                        MemberIdentityID = 1
                    },

                    new EmailAddress{ AddressTyoe = AddressTyoe.Home,
                        Email = "bob@coolbluesoftware.com",
                        MemberIdentityID = 1
                    },

                    new EmailAddress{ AddressTyoe = AddressTyoe.Business,
                        Email = "bob@coolbluesoftware.com",
                        MemberIdentityID = 1
                    }
            };

            var phoneNumbes = new PhoneNumber[]
            {           
                    new PhoneNumber{ AddressTyoe = AddressTyoe.Home,
                        Phone = "07817716237",
                        MemberIdentityID = 1
                    },

                    new PhoneNumber{ AddressTyoe = AddressTyoe.Home,
                        Phone = "07817716237",
                        MemberIdentityID = 1
                    },

                    new PhoneNumber{ AddressTyoe = AddressTyoe.Business,
                        Phone = "07817716237",
                        MemberIdentityID = 1
                    }
             };

            context.SaveChanges();
        }
    }
}
