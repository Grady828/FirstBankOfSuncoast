# FirstBankOfSuncoast

//Problem
-Create a console app that allows a user to manage savings and checking banking transactions.

A user will make a series of transactions.

You will compute balances by examining all the transactions in the history. For instance, if a user deposits 10 to their savings, then withdraws 8 from their savings, then deposits 25 to their checking, they have three transactions to consider. Compute the checking and saving balance, using the transaction list, when needed. In this case, their savings balance is 2 and their checking balance is 25.

The transactions will be saved in a file, using a CSV format to record the data.

//Example:

- I go to the bank and deposit $10 into my checking account. Withdraw $5 from $20 in Savings and deposit $3 back into Checking. That is 3 transactions. I have $13 in checking left and $15 in savings left.

//Data Structure:

- I will be using LINQ, a Class, Methods; reading, writing and saving files and creating a menu(User interface).

//Algorithm:

- The application should store a history of transactions in a SINGLE List<Transaction>. Your task is to design the Transaction class to support both checking and savings as well as deposits and withdraws.
- - Make a Transaction class
- - Create a Method for checking.
- - Create a Method for savings
- - Create a Method for deposits
- - Create a Method for withdrawals

- The application should load past transactions from a file when it first starts.
  -- This will be done through Writing Files at the end of the program using (StreamWriter, CSVWriter, and CultureInfo)
- As a user I should be able to see the list of transactions designated savings.
- As a user I should be able to see the list of transactions designated checking.
- Never allow withdrawing more money than is available. That is, we cannot allow our checking or savings balances to go negative.
- When prompting for an amount to deposit or withdraw always ensure the amount is positive. The value we store in the Transaction shall be positive as well. (e.g. a Transaction that is a withdraw of 25 both inputs and records a positive 25)
- As a user I should have a menu option to make a deposit transaction for savings.
- As a user I should have a menu option to make a deposit transaction for checking.
- As a user I should have a menu option to make a withdraw transaction for savings.
- As a user I should have a menu option to make a withdraw transaction for checking.
- As a user I should have a menu option to see the balance of my savings and checking.
- The application should, after each transaction, write all the transactions to a file. This is the same file the application loads.
