using PosCashRegister.Configuration;
using Xunit;

namespace PosCashRegister.Tests
{
      public class CurrencyConfigTests
      {
            [Fact]
            public void CurrencyConfig_WithDefaultValues_ReturnsCorrectDenominations()
            {
                  // Arrange
                  // Get base directory and merge with relative route
                  string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                  string relativePath = Path.Combine(baseDirectory, @"../../../../PosCashRegister/Configuration/currencies.json");
                  string currencyFilePath = Path.GetFullPath(relativePath);  // Obtén la ruta absoluta completa
                  // Load currency configuration
                  var config = new CurrencyConfig(currencyFilePath);
                  // Act
                  var result = config.GetDenominations("US");
                  // Assert
                  Assert.Equal(12, result.Count);
                  Assert.Contains(0.01m, result);
                  Assert.Contains(0.50m, result);
                  Assert.Contains(1.0m, result);
                  Assert.Contains(100m, result);
                  Assert.DoesNotContain(1000m, result);
            }
      }
}