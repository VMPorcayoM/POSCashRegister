namespace PosCashRegister.Validation
{
    /// <summary>
    /// Contains validation logic for user inputs.
    /// </summary>
    public static class InputValidator
    {
        /// <summary>
        /// Attempts to parse a user-provided string into a decimal value.
        /// Ensures the value is non-negative.
        /// </summary>
        /// <param name="input">The string input to validate and parse.</param>
        /// <param name="value">The parsed decimal value if valid.</param>
        /// <returns>True if parsing succeeds and the value is non-negative, false otherwise.</returns>
        public static bool TryParseDecimal(string? input, out decimal value)
        {
            if (decimal.TryParse(input, out value) && value >= 0)
                return true;
            value = 0;
            return false;
        }
        /// <summary>
        /// Validates whether the amount paid is valid based on the following criteria:
        /// 1. The amount paid is greater than or equal to the price.
        /// 2. The amount paid can be represented exactly using the available denominations.
        /// </summary>
        /// <param name="price">The price of the item.</param>
        /// <param name="amountPaid">The amount paid by the customer.</param>
        /// <param name="denominations">A list of available currency denominations (e.g., 100, 50, 20, 10).</param>
        /// <returns>
        /// True if the amount paid is valid (greater than or equal to the price and representable in the given denominations);
        /// False otherwise.
        /// </returns>
        public static bool IsAmountPaidValid(decimal price, decimal amountPaid, List<decimal> denominations)
        {
            // Check if the amount paid is greater than or equal to the price
            if (amountPaid < price)
                return false;
            // Iterate through the denominations to calculate if the remaining amount is valid
            decimal remainingAmount = amountPaid;
            foreach (var denomination in denominations)
            {
                // Calculate how many units of the denomination can be used
                int count = (int)(remainingAmount / denomination);
                // Reduce the remaining amount
                remainingAmount -= count * denomination;
                // Round the remaining amount to avoid floating-point precision issues
                remainingAmount = Math.Round(remainingAmount, 2); // Avoid floating-point issues
            }
            // If the remaining amount is exactly zero, the amount is valid
            return remainingAmount == 0;
        }
    }
}