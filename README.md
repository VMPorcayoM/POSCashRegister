# POSCashRegister

This is a .NET-based Point-of-Sale (POS) system designed to calculate the correct change due to a customer based on the amount they provide and return the smallest number of bills and coins.

## Problem Description

The system solves the problem where cashiers are increasingly unable to return the correct amount of change. The objective is to calculate the change from the total amount paid by the customer and display the minimum number of bills and coins.

### Functional Requirements

- The system accepts two main inputs:
  - **Price of the item(s)** being purchased.
  - **Bills and coins provided by the customer** to pay for the item(s).

- The system calculates the minimum number of bills and coins that the cashier should return to the customer.

- The customer may provide an arbitrary mix of bills and coins, but the total must be greater than or equal to the price of the items.

- The denominations vary by country. For example:
  - **US**
  - **Mexico**

- User inputs must be validated to ensure correctness, and the system provides feedback for invalid inputs.

### Non-Functional Requirements

- The solution is implemented as a **C# .NET Console Application**.
- The code is **commented** to guide future engineers on how to use and extend the functionality.
- The system includes **unit tests** that provide complete coverage of all key aspects of the function.
- **Object-Oriented Principles** are applied throughout the code.
- The routine is optimized for **performance**.
- The solution includes **robust error handling** with clear exception definitions for callers of the function.

## Solution Overview

The solution consists of the following key components:

1. **CurrencyConfig Class**:
   - Loads the currency configuration (i.e., denominations for different countries).
   - Provides the denominations for the country selected in the configuration.

2. **ChangeCalculator Class**:
   - Calculates the change required from the price and the amount provided by the customer.
   - Returns the change in the form of a dictionary, where keys are the denominations, and values are the quantity of each denomination required to give the correct change.

3. **InputValidator Class**:
   - Validates the inputs provided by the user, ensuring they meet the application's requirements.
   - Includes methods such as `TryParseDecimal` to parse numeric values and `IsAmountPaidValid` to ensure the amount paid is sufficient.

4. **ConsoleHandler Class**:
   - Handles user interaction, including displaying prompts for inputs and presenting the calculated change.
   - Provides feedback for invalid inputs and guides the user through the process.

5. **POSCashRegister Class** (Console Application):
   - Serves as the entry point of the application.
   - Demonstrates the working of the change calculator and manages the flow of input validation and output display.

6. **Unit Tests**:
   - A comprehensive set of unit tests that cover various scenarios, including valid transactions, edge cases, and input validation logic.

## Input Validation

- The system ensures that:
  - Prices and amounts paid are non-negative decimal values.
  - The amount paid is greater than or equal to the price.
  - Valid country codes are provided for currency configuration.

- For invalid inputs, the user is prompted to enter the value again, with clear feedback on what needs to be corrected.

## How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/VMPorcayoM/POSCashRegister.git
   cd POSCashRegister
   ```

2. Build the project using the .NET CLI:
   ```bash
   dotnet build
   ```

3. Run the application:
   ```bash
   dotnet run
   ```

4. Follow the prompts to input the price, amount paid, and select the currency configuration.

## Running Unit Tests

1. Navigate to the `POSCashRegister.Tests` directory:
   ```bash
   cd POSCashRegister.Tests
   ```

2. Run the tests using the .NET CLI:
   ```bash
   dotnet test
   ```

## Example Usage

### Input
- **Price**: $37.75
- **Amount Paid**: $50.00
- **Currency**: US

### Output
- Change Due: $12.25
- Denominations Returned:
  - $10 bill: 1
  - $2 coin: 1
  - $0.25 coin: 1