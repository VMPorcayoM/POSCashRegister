namespace PosCashRegister.Models
{
    public class ChangeResult
    {
        public required Dictionary<decimal, int> Denominations { get; set; }
        public decimal TotalChange { get; set; }
    }
}