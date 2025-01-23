using System;
using System.ComponentModel.DataAnnotations;

namespace LoanManagementSystem.Models
{
    public class Member
    {
        public int MemberId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(50)]
        [Required]
        [Phone]
        public string Contact { get; set; }

        [StringLength(100)]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        // Public property to store the created date
        public DateTime CreatedDate { get; set; }
    }
}
