namespace coresystem.Models
{
    public class SharePurchase
    {

        public int Id { get; set; }
        public int MemberId { get; set; }
        public int ShareNo { get; set; }
        public int ShareAmount { get; set; }
        public string? Remarks { get; set; }
        public DateTime PurchaseDate { get; set; }
        public char RecStatus { get; set; } = 'A';
    }
}