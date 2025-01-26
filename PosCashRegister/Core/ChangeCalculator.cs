namespace PosCashRegister.Core
{
    public class ChangeCalculator
    {
      private readonly List<decimal> _denominations;
      public ChangeCalculator(List<decimal> denominations)
        {
            if (denominations == null || !denominations.Any())
                throw new ArgumentException("Denominations cannot be null or empty.");

            _denominations = denominations;
        }
        public Dictionary<decimal, int> CalculateChange(decimal price, decimal amountPaid)
        {
            // Get the exact change
            decimal change = amountPaid - price;
            var result = new Dictionary<decimal, int>();
            // Iterate through the denominations in descending order
            foreach (var denomination in _denominations)
            {
                int count = (int)(change / denomination);
                if (count > 0)
                {
                    result[denomination] = count;
                    change -= count * denomination;
                    change = Math.Round(change, 2); // Avoid floating-point issues
                }
            }
            // If there is still remaining change that cannot be exactly returned
            if (change > 0)
            {
                // Ensure denominations is not empty to avoid potential errors
                if (_denominations.Any())
                {
                    decimal smallestDenomination = _denominations.Last();
                    // Notify the user if exact change is unavailable
                    if (change < smallestDenomination)
                        Console.WriteLine($"Exact change unavailable for {change}. Rounding down.");
                }
                else
                    Console.WriteLine("Error: No denominations available.");
            }
            return result;
        }
    }
}