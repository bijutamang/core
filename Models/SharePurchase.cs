using System.ComponentModel.DataAnnotations;

namespace coresystem.Models
{
    public class SharePurchase
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        [Required]
        public int ShareNo { get; set; }
        public int ShareAmount { get; set; }
        [Required]
        public string? Remarks { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
        public char RecStatus { get; set; } = 'A';
    }
}