using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheGymApp.Data
{
    [Table("tblUserMembershipDetails")]
    public class UserMembership
    {
        [Key]
        public int Id { get; set; }
        public int UserMembershipId { get; set; }        
        public int MembershipId { get; set; }
        public DateTime MembershipStartDate { get; set; }
        public DateTime MembershipEndDate { get; set; }
        public int Discount_InPerc { get; set; }
        public int MembershipFee { get; set; }
        [ForeignKey("UserMembershipId")]
        public ZSysUser sysUser { get; set; }
    }
}
