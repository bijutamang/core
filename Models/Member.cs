using coresystem.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Reflection;

namespace coresystem.Models
{
    public class Member
    {
		public int Id { get; set; }
		[Required]
        [DisplayName("Full Name")]
		public string? FullName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string? LastName { get; set; }
        [Required]
        [DisplayName("Father Name")]
        public string? FatherName { get; set; }
        [Required]
        [DisplayName("Mother Name")]
        public string? MotherName { get; set; }
        [Required]
        [DisplayName("Grand Father Name")]
        public string? GrandFatherName { get; set; }
        [Required]
        public string? Address { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? Number { get; set; }
        [Required]
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public char RecStatus { get; set; } = 'A';
    }
}
