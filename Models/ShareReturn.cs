using System.ComponentModel.DataAnnotations;

namespace coresystem.Models
{
    public class ShareReturn
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        [Required]
        public int ShareNo { get; set; }
        public int Amount { get; set; }
        [Required]
        public string? Remarks { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
        public char RecStatus { get; set; } = 'A';
    }
}
