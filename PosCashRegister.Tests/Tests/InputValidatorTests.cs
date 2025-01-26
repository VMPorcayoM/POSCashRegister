using System.Collections.Generic;
using PosCashRegister.Core;
using Xunit;

namespace PosCashRegister.Tests
{
    public class InputValidatorTests
    {
        [Fact]
        public void IsAmountValid_ExactAmount_ReturnsTrue()
        {
            // Arrange
            decimal price = 1.00m;
            decimal amountPaid = 1.00m;
            var denominations = new List<decimal> { 0.25m, 0.1m, 0.05m, 0.01m };

            // Act
            var result = InputValidator.IsAmountValid(price, amountPaid, denominations);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsAmountValid_InsufficientAmount_ReturnsFalse()
        {
            // Arrange
            decimal price = 1.00m;
            decimal amountPaid = 0.99m;
            var denominations = new List<decimal> { 0.25m, 0.1m, 0.05m, 0.01m };

            // Act
            var result = InputValidator.IsAmountValid(price, amountPaid, denominations);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsAmountValid_WithRoundingIssues_ReturnsFalse()
        {
            // Arrange
            decimal price = 1.00m;
            decimal amountPaid = 1.03m;
            var denominations = new List<decimal> { 0.25m, 0.1m, 0.05m };

            // Act
            var result = InputValidator.IsAmountValid(price, amountPaid, denominations);

            // Assert
            Assert.False(result);
        }
    }
}