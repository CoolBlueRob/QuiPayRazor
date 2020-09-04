using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuiPayRazor.Models
{
    public enum MemberState
    {
        Pending, Approved, Suspicious, Suspended
    };

    public class Member
    {
        [Key]
        public int Id { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public MemberState MemberState { get; set; }

        public DateTime WhenCreated { get; set; }

        [InverseProperty("Member")]
        public ICollection<Account> Accounts { get; set; }

        [InverseProperty("Member")]
        public ICollection<MemberIdentity> MemberIdentitys { get; set; }
    }
}
