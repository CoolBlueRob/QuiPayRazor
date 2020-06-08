using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuiPayRazor.Models
{
    public enum PersonalOrBusiness
    {
        [Display(Name = "Personal")]
        Personal,
        
        [Display(Name = "Business")] 
        Business
    };

    public class Address
    {
        [Key]
        public int ID { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public PersonalOrBusiness AddressType { get; set; }

        [StringLength(80)]
        public string Address1 { get; set; }

        [StringLength(80)]
        public string Address2 { get; set; }

        [StringLength(80)]
        public string Address3 { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string County { get; set; }

        [StringLength(20)]
        public string PostCode { get; set; }

        [StringLength(20)]
        public string CountryCode { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WhenCreated { get; set; }

        public int MemberIdentityID { get; set; }

        public virtual MemberIdentity MemberIdentity { get; set; }
    }
}
