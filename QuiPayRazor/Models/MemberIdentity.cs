using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace QuiPayRazor.Models
{
    public enum MemberDetailsState
    {
        Pending, Approved, Suspicious, Suspended
    };

    public class MemberIdentity
    {
        [Key]
        public int Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public MemberDetailsState MemberDetailsState { get; set; }

        [StringLength(20)]
        public string Title { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [StringLength(50)]
        public string LastName { get; set; }

        public int MemberId { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime WhenCreated { get; set; }

        public virtual Member Member { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<EmailAddress> EmailAddresses { get; set; }

        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }

    }
}
