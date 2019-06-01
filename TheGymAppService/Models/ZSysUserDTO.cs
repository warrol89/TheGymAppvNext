using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace TheGymApp.Service.Models
{
    public class ZSysUserDTO
    {
        private string _userName;
        
        public int Id { get; set; }
       [Required]
        public string firstName { get; set; }
        [Required]
        public string lastName { get; set; }
        [JsonIgnore]
        public string UserName
        {
            get { return _userName = $"{firstName}.{lastName}"; }
            
        }
        [Required]
        [Phone]
        public string phoneNumber { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
       [Required]
        public string paymentMethod { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime DOB { get; set; }
        public string appointmentDate { get; set; }
        public string notes { get; set; }
        public string membership { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string postalCode { get; set; }
        public string discount { get; set; }
        

    }
}
