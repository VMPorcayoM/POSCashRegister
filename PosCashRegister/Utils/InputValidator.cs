namespace PosCashRegister.Core
{
    public static class InputValidator
    {
        public static bool IsAmountValid(decimal price, decimal amountPaid, List<decimal> denominations)
        {
            // Validate paid amount is greater than or equal to the price
            if (amountPaid < price)
                return false;
            decimal remainingAmount = amountPaid;
            foreach (var denomination in denominations)
            {
                int count = (int)(remainingAmount / denomination);
                remainingAmount -= count * denomination;
                remainingAmount = Math.Round(remainingAmount, 2); // Avoid floating-point issues
            }
            // If the remaining amount is not zero, it's not valid
            return remainingAmount == 0;
        }
    }
}