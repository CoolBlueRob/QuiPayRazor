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
        public int ID { get; set; }

        public MemberDetailsState MemberDetailsState { get; set; }

        public string Title { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int MemberID { get; set; }

        public DateTime WhenCreated { get; set; }

        public virtual Member Member { get; set; }

        public virtual ICollection<Address> Addresses { get; set; }

        public virtual ICollection<EmailAddress> EmailAddresses { get; set; }

        public virtual ICollection<PhoneNumber> PhoneNumbers { get; set; }

    }
}
