namespace PosCashRegister.Core
{
    public class ChangeCalculator
    {
        // A private list to store the available denominations (e.g., coins or bills).
        // The list is expected to be in descending order.
        private readonly List<decimal> _denominations;

        // Constructor that takes a list of denominations.
        // Ensures that the list of denominations is not null or empty.
        public ChangeCalculator(List<decimal> denominations)
        {
            // Validate that the list of denominations is not null or empty.
            if (denominations == null || !denominations.Any())
                throw new ArgumentException("Denominations cannot be null or empty.");

            // Initialize the _denominations list with the provided denominations.
            _denominations = denominations;
        }

        // Method to calculate the change to be returned given the price and the amount paid.
        // The method returns a dictionary where the key is the denomination and the value is the count of that denomination to be returned.
        public Dictionary<decimal, int> CalculateChange(decimal price, decimal amountPaid)
        {
            // Calculate the total change required by subtracting the price from the amount paid.
            decimal change = amountPaid - price;
            // Create a dictionary to store the result (denomination and count).
            var result = new Dictionary<decimal, int>();
            // Iterate through the denominations list in descending order.
            // For each denomination, calculate how many of that denomination can be returned.
            foreach (var denomination in _denominations)
            {
                // Calculate the maximum number of coins/bills of this denomination that can be returned.
                int count = (int)(change / denomination);
                // If the denomination can be used, add it to the result dictionary.
                if (count > 0)
                {
                    result[denomination] = count;
                    // Subtract the value of the returned denominations from the remaining change.
                    change -= count * denomination;
                    // Round the remaining change to 2 decimal places to avoid floating-point precision issues.
                    change = Math.Round(change, 2);
                }
            }

            // If there is still some change left that cannot be exactly returned (due to rounding issues or lack of denominations),
            // handle this case by notifying the user.
            if (change > 0)
            {
                // Ensure there are available denominations to avoid potential errors.
                if (_denominations.Any())
                {
                    // Get the smallest denomination available.
                    decimal smallestDenomination = _denominations.Last();
                    // If the remaining change is smaller than the smallest denomination, notify the user that exact change cannot be returned.
                    if (change < smallestDenomination)
                        Console.WriteLine($"Exact change unavailable for {change}. Rounding down.");
                }
                else
                {
                    // If no denominations are available, print an error message.
                    Console.WriteLine("Error: No denominations available.");
                }
            }

            // Return the result dictionary containing the denominations and their respective counts.
            return result;
        }
    }
}