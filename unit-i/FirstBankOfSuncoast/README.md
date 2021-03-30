# FirstBankOfSuncoast

# (P)roblem

- The application should store a history of transactions in a _SINGLE_ `List<Transaction>`. Your task is to design the `Transaction` class to support both checking and savings as well as deposits and withdraws.
- The application should load past transactions from a file when it first starts.
- As a user I should be able to see the list of transactions designated `savings`.
- As a user I should be able to see the list of transactions designated `checking`.
- Never allow withdrawing more money than is available. That is, we cannot allow our `checking` or `savings` balances to go negative.
- When prompting for an amount to deposit or withdraw always ensure the amount is positive. The value we store in the `Transaction` shall be positive as well. (e.g. a `Transaction` that is a withdraw of 25 both inputs and records a positive `25`)
- As a user I should have a menu option to make a deposit transaction for `savings`.
- As a user I should have a menu option to make a deposit transaction for `checking`.
- As a user I should have a menu option to make a withdraw transaction for `savings`.
- As a user I should have a menu option to make a withdraw transaction for `checking`.
- As a user I should have a menu option to see the balance of my `savings` and `checking`.
- The application should, after **each** transaction, write **all** the transactions to a file. This is the same file the application loads.

# (E)xamples

- I see the menu, I choose "deposit to savings". I enter $50.
- I see the menu, I choose "withdraw from savings", I enter $10.
- I see the menu, I choose "check balance from savings", I have $40.

```
Transaction { account: Savings,   type: Deposit,   amount: 10.00 }
Transaction { account: Checking,  type: Deposit,   amount: 50.00 }
Transaction { account: Checking,  type: Withdrawl, amount: 22.00 }
Transaction { account: Savings,   type: Withdrawl, amount: 10.00 }
Transaction { account: Checking,  type: Deposit,   amount: 71.00 }
```
Checking Balance: $99.00
Savings Balance: $40.00

# (D)ata Structure

Nouns

- **Transaction**
  - **Type** (i.e., deposit or withdrawl)
  - **Account** (i.e., checking or savings)
  - **Amount** (always a positive number)
- **Balance** (sum of transactions)
- **Menu**
  - **Option**
- Application
- **List** of Transactions
- **File**
- User

# (A)lgorithm

## Making a Deposit

Assume the user has chosen "Deposit" from the menu:

- Ask the user for the account type (e.g. "checking");
- Ask the user how much they want to deposit.
- Create a deposit `Transaction` with the given amount and account type (from previous step).
- Add the transaction to the transaction list.
- Write the transactions to a file.

## Making a Withdrawal

Assume the user has chosen "Withdraw" from the menu:

- Ask the user for the account type (e.g. "checking");
- Ask the user how much they want to withdraw.
- Create a withdrawal `Transaction` with the given amount and account type (from previous step).
- Ensure the account balance is greater than or equal to the transaction amount.
- Add the transaction to the transaction list.
- Write the transactions to a file.

## Checking a Balance

- For a given account type
    - Add up all the deposits
    - Add up all the withdrawls
    - Subtract withdrawls from deposits

<!-- - let balance = 0
- For each transaction
  - if deposit, balance += amount
  - if withdrawl, balance -= amount -->

# (C)ode!