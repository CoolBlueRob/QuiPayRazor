using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuiPayRazor.Models
{
    public enum AddressTyoe
    {
        Home, Business, Other
    };

    public class Address
    {
        [Key]
        public int ID { get; set; }

        public AddressTyoe AddressTyoe { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string CountryCode { get; set; }

        public string ZipCode { get; set; }

        public DateTime WhenCreated { get; set; }

        public int MemberIdentityID { get; set; }

        public virtual MemberIdentity MemberIdentity { get; set; }
    }
}
