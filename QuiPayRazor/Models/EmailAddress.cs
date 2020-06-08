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

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public PersonalOrBusiness AddressType { get; set; }

        [StringLength(80)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WhenCreated { get; set; }

        public int MemberIdentityID { get; set; }

        public virtual MemberIdentity MemberIdentity { get; set; }
    }
}
