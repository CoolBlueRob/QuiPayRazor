using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuiPayRazor.Models
{
    public class EmailAddress
    {
        [Key]
        public int ID { get; set; }

        public AddressTyoe AddressTyoe { get; set; }

        public string Email { get; set; }

        public int MemberIdentityID { get; set; }

        public virtual MemberIdentity MemberIdentity { get; set; }
    }
}
