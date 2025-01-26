# POSCashRegister

This is a .NET-based Point-of-Sale (POS) system designed to calculate the correct change due to a customer based on the amount they provide, and return the smallest number of bills and coins.

## Problem Description

The system solves the problem where cashiers are increasingly unable to return the correct amount of change. The objective is to calculate the change from the total amount paid by the customer and display the minimum number of bills and coins.

### Functional Requirements

- The routine takes two inputs:
  - **Price of the item(s)** being purchased.
  - **Bills and coins provided by the customer** to pay for the item(s).

- The routine calculates the minimum number of bills and coins that the cashier should return to the customer.

- The customer may provide an arbitrary mix of bills and coins, but the total must be greater than or equal to the price of the items.

- The denominations vary by country. For example:
  - **US**
  - **Mexico**

### Non-Functional Requirements

- The solution is implemented as a **C# .NET Console Application**.
- The code is **commented** to guide future engineers on how to use and extend the functionality.
- The system has **unit tests** that provide complete coverage of all key aspects of the function.
- **Object-Oriented Principles** are applied throughout the code.
- The routine is optimized for **performance**.
- The solution contains **robust error handling** with clear exception definitions for callers of the function.

## Solution Overview

The solution consists of the following key components:

1. **CurrencyConfig Class**:
   - Loads the currency configuration (i.e., denominations for different countries).
   - Provides the denominations for the country selected in the configuration.

2. **ChangeCalculator Class**:
   - Calculates the change required from the price and the amount provided by the customer.
   - Returns the change in the form of a dictionary, where keys are the denominations, and values are the quantity of each denomination required to give the correct change.

3. **POSCashRegister Class** (Console Application):
   - Demonstrates the working of the change calculator with a sample transaction.

4. **Unit Tests**:
   - A set of unit tests for testing different scenarios including valid transactions and edge cases.

## How to Run

1. Clone the repository:
   ```bash
   git clone https://github.com/VMPorcayoM/POSCashRegister.git
   cd POSCashRegister
