using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace TheGymApp.Data
{
    [Table("tblMembership")]
    public class Membership
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string MembershipName { get; set; }
        [MaxLength(100)]
        public string MembershipPrice { get; set; }
        public int MembershipFee { get; set; }
        public int MembershipMonths { get; set; }


    }
}
