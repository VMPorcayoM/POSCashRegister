using System;
using System.Collections.Generic;
using PosCashRegister.Configuration;
using PosCashRegister.Core;
using PosCashRegister.Utils;

namespace PosCashRegister
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Location of the currency configuration file
                string currencyFilePath = "Configuration/currencies.json";
                // Load currency configuration
                var currencyConfig = new CurrencyConfig(currencyFilePath);
                // Global configuration
                // Get available countries and prompt for country denominations
                var availableCountries = currencyConfig.GetAvailableCountries();
                string countryCode = ConsoleHandler.PromptCountryCode(availableCountries);
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
                    // Calculate change
                    var change = calculator.CalculateChange(price, amountPaid);
                    // Display calculated change
                    if(change.Count == 0)
                        Console.WriteLine("No change to be returned.");
                    else{
                        Console.WriteLine("Change to be returned: ");
                        foreach (var item in change)
                            Console.WriteLine($"{item.Value} x {item.Key:C}");
                    }
                } while (true);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}