namespace ProjectLippoKarawaci.Models
{
    public class Tagihan
    {
        public string Nomor { get; set; }
        public DateTime DueDate { get; set; }
        public decimal Amount { get; set; }
        public decimal RemainingAmount { get; set; }
    }
}
