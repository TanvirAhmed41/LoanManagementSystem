using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LoanManagementSystem.Models
{
    public class Member
    {
        internal DateTime CreatedDate;

        public int MemberId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        public string Contact { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Address { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}