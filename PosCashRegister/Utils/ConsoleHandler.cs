using System;
using PosCashRegister.Validation;

namespace PosCashRegister.Utils
{
      /// <summary>
      /// Handles console input and output operations for the application.
      /// </summary>
      public static class ConsoleHandler
      {
            /// <summary>
            /// Validates if the given country code matches one of the available countries.
            /// Prompts the user to re-enter the country code until a valid input is provided.
            /// </summary>
            /// <param name="availableCountries">A list of valid country codes.</param>
            /// <returns>A valid country code from the availableCountries list.</returns>
            public static string PromptCountryCode(List<string> availableCountries)
            {
                  // Display available countries
                  Console.WriteLine($"Available countries: {String.Join(", ", availableCountries)}");
                  while (true)
                  {
                        // Prompt the user to re-enter the country code
                        Console.Write("Enter a valid country code: ");
                        var input = Console.ReadLine()!.Trim();
                        // Ensure input is non-null, non-empty, and contains only letters
                        if (!string.IsNullOrWhiteSpace(input) && input.All(char.IsLetter))
                        {
                              // Check if the input exists in the available countries list
                              if (availableCountries.Contains(input.ToUpper()))
                                    return input.ToUpper(); // Return the valid country code in uppercase
                        }
                        // If input is invalid, display an error message and prompt for re-entry
                        Console.WriteLine("Invalid country code. Please select from the available countries");
                  }
            }
            /// <summary>
            /// Prompts the user for a valid decimal input with a given message.
            /// Retries until a valid decimal is provided.
            /// </summary>
            /// <param name="promptMessage">The message displayed to the user.</param>
            /// <returns>A valid decimal value entered by the user.</returns>
            public static decimal PromptForDecimalInput(string promptMessage)
            {
                  decimal value;
                  while (true)
                  {
                        Console.Write(promptMessage);
                        string? input = Console.ReadLine();
                        // Validate and parse input
                        if (InputValidator.TryParseDecimal(input, out value))
                              return value;
                        Console.WriteLine("Invalid input. Please enter a non-negative decimal value.");
                  }
            }
            /// <summary>
            /// Prompts the user for an amount paid that is greater than or equal to the price.
            /// Retries until a valid amount is provided.
            /// </summary>
            /// <param name="price">The price of the item being purchased.</param>
            /// <param name="denominations">VA list of available currency denominations (e.g., 100, 50, 20, 10).</param>
            /// <returns>A valid decimal value for the amount paid.</returns>
            public static decimal PromptForValidAmountPaid(decimal price, List<decimal> denominations)
            {
                  decimal amountPaid;
                  while (true)
                  {
                        Console.Write("Enter amount paid: ");
                        string? input = Console.ReadLine();
                        // Validate and parse input
                        if (InputValidator.TryParseDecimal(input, out amountPaid))
                        {
                              if (InputValidator.IsAmountPaidValid(price, amountPaid, denominations))
                                    return amountPaid;
                              Console.WriteLine($"Invalid input. Amount paid must be greater than or equal to the price ({price:C}) and match available denominations.");
                        }
                        else
                              Console.WriteLine("Invalid input. Please enter a valid decimal value.");
                  }
            }
      }
}