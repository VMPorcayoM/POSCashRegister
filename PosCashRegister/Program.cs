using System;
using System.Collections.Generic;
using PosCashRegister.Configuration;
using PosCashRegister.Core;

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
                // Prompt user to select an available country
                string countries = String.Join(", ", currencyConfig.GetAvailableCountries());
                Console.WriteLine($"Available countries: {countries}");
                Console.Write("Enter country code: ");
                string countryCode = Console.ReadLine()!.Trim().ToUpper();
                // Get the denominations for the selected country
                var denominations = currencyConfig.GetDenominations(countryCode);
                // Create a change calculator
                var calculator = new ChangeCalculator(denominations);
                // Keep alive the program
                do
                {
                    // Input price and amount paid
                    Console.Write("Enter price: ");
                    decimal price = decimal.Parse(Console.ReadLine() ?? "0");
                    decimal amountPaid;
                    do
                    {
                        Console.Write("Enter amount paid: ");
                        amountPaid = decimal.Parse(Console.ReadLine() ?? "0");
                        if (InputValidator.IsAmountValid(price, amountPaid, denominations))
                            break; // Valid amount, exit the loop
                        else
                            Console.WriteLine("Invalid amount entered. Please it must be greater than or equal to the price and a valid amount using the correct denominations.");
                    } while (true);
                    // Calculate change
                    var change = calculator.CalculateChange(price, amountPaid);
                    // Print the calculated change
                    Console.WriteLine("Change to be returned: ");
                    foreach (var item in change)
                    {
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