using System;
using System.Collections.Generic;
using PosCashRegister.Configuration;
using PosCashRegister.Core;
using PosCashRegister.Utils;

namespace PosCashRegister
{
    class Program
    {
        static async Task Main(string[] args)
        {
            try
            {
                // Location of the currency configuration file
                string currencyFilePath = "Configuration/currencies.json";
                // Load currency configuration asynchronously
                var currencyConfig = new CurrencyConfig();
                await currencyConfig.LoadConfigurationAsync(currencyFilePath);
                // Global configuration
                // Get available countries and prompt for country denominations
                string countryCode = ConsoleHandler.PromptCountryCode(currencyConfig.GetAvailableCountries());
                // Get the denominations for the selected country
                var denominations = currencyConfig.GetDenominations(countryCode);
                // Create a change calculator
                var calculator = new ChangeCalculator(denominations);
                // Main loop to keep the program alive
                do
                {
                    // Prompt for price
                    decimal price = ConsoleHandler.PromptForDecimalInput("Enter price: ");
                    // Prompt for valid amount paid
                    decimal amountPaid = ConsoleHandler.PromptForValidAmountPaid(price, denominations);
                    // Calculate and display change
                    var change = calculator.CalculateChange(price, amountPaid);
                    ConsoleHandler.DisplayChange(change);
                } while (true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}