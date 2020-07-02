using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public ICollection<Account> Accounts { get; set; }

        public ICollection<MemberIdentity> MemberIdentitys { get; set; }
    }
}
