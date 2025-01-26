using System;
using System.Collections.Generic;
using PosCashRegister.Core;
using Xunit;

namespace PosCashRegister.Tests
{
    public class ChangeCalculatorTests
    {
        [Fact]
        public void CalculateChange_ExactAmount_ReturnsNoChange()
        {
            // Arrange
            var denominations = new List<decimal> { 0.25m, 0.1m, 0.05m, 0.01m };
            var calculator = new ChangeCalculator(denominations);
            decimal price = 1.00m;
            decimal amountPaid = 1.00m;

            // Act
            var result = calculator.CalculateChange(price, amountPaid);

            // Assert
            Assert.Empty(result); // No change expected
        }

        [Fact]
        public void CalculateChange_WithChange_ReturnsCorrectDenominations()
        {
            // Arrange
            var denominations = new List<decimal> { 0.25m, 0.1m, 0.05m, 0.01m };
            var calculator = new ChangeCalculator(denominations);
            decimal price = 0.75m;
            decimal amountPaid = 1.00m;

            // Act
            var result = calculator.CalculateChange(price, amountPaid);

            // Assert
            Assert.Equal(1, result[0.25m]); // 1 quarter
        }

        [Fact]
        public void CalculateChange_WithRounding_ReturnsCorrectChange()
        {
            // Arrange
            var denominations = new List<decimal> { 0.25m, 0.1m, 0.05m, 0.01m };
            var calculator = new ChangeCalculator(denominations);
            decimal price = 0.99m;
            decimal amountPaid = 1.00m;

            // Act
            var result = calculator.CalculateChange(price, amountPaid);

            // Assert
            Assert.Equal(1, result[0.01m]); // 1 penny
        }

        [Fact]
        public void CalculateChange_WithInsufficientDenominations_ReturnsRoundedChange()
        {
            // Arrange
            var denominations = new List<decimal> { 0.1m, 0.05m }; // No pennies
            var calculator = new ChangeCalculator(denominations);
            decimal price = 0.98m;
            decimal amountPaid = 1.00m;

            // Act
            var result = calculator.CalculateChange(price, amountPaid);

            // Assert
            Assert.Equal(1, result[0.05m]); // Rounding to nearest nickel
        }

        [Fact]
        public void Constructor_WithNullOrEmptyDenominations_ThrowsArgumentException()
        {
            // Arrange & Act
            void Action() => new ChangeCalculator(null!);

            // Assert
            Assert.Throws<ArgumentException>(Action);
        }
    }
}