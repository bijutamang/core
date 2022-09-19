namespace coresystem.Models
{
    public class ShareReturn
    {
        public int Id { get; set; }
        public int MemberId { get; set; }
        public int ShareNo { get; set; }
        public int Amount { get; set; }
        public string? Remarks { get; set; }
        public DateTime ReturnDate { get; set; }
        public char RecStatus { get; set; } = 'A';
    }
}
