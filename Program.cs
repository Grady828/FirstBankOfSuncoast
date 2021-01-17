using System;
using FirstBankOfSuncoast.Models;
using System.Linq;
using System.Collections.Generic;

namespace FirstBankOfSuncoast
{
    class Transaction
    {
        public string Type { get; set; }
        public string Account { get; set; }
        public int Amount { get; set; }
        public DateTime TimeStamp { get; set; }
    }
    class Program

    {
        static void Main(string[] args)
        {
            // Welcome to the app
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Welcome to First Bank OF Suncoast");
            Console.WriteLine();

            // Add filereader later after testing
            // While the User hasn’t chosen to QUIT: (Bool is false)






            // Add a List<Transactions>
            var transactions = new List<Transaction>() {
                      new Transaction()

                      {
                        Account = "savings",
                        Type = "deposit",
                        Amount = 50,
                        TimeStamp = DateTime.Now,

                      },
                      new Transaction()
                     {
                        Account = "checking",
                        Type = "deposit",
                        Amount = 10,
                        TimeStamp = DateTime.Now,
                      },
                      new Transaction()
                      {
                        Account = "savings",
                        Type = "withdrawal",
                        Amount = 5,
                        TimeStamp = DateTime.Now,
                      },
                       new Transaction()
                      {
                        Account = "checking",
                        Type = "withdrawal",
                        Amount = 5,
                        TimeStamp = DateTime.Now
                      }
                };
            var userHasNotChosenToQuit = false;
            while (userHasNotChosenToQuit == false)
            {
                // Display the Menu Options:
                // 	Deposit
                // 	Withdraw
                // 	Balance 
                // 	Transaction History
                // 	Quit

                Console.WriteLine();
                Console.WriteLine("Hi, please choose from the following options:");
                Console.WriteLine();
                Console.WriteLine("Deposit");
                Console.WriteLine("Withdrawal");
                Console.WriteLine("Balance");
                Console.WriteLine("Transaction History");
                Console.WriteLine("Quit");
                Console.WriteLine();
                Console.WriteLine("Please make a choice");
                var choice = Console.ReadLine();
                string v = choice.ToLower().Trim();
                choice = v;

                var savingsAccountBalance = 0;
                var checkingAccountBalance = 0;
                var savingsTransactions = transactions.Where(transaction => transaction.Account == "savings");
                var checkingTransactions = transactions.Where(transaction => transaction.Account == "checking");
                foreach (var savingsTransaction in savingsTransactions)
                {
                    if (savingsTransaction.Type == "deposit")
                    {
                        savingsAccountBalance = savingsAccountBalance + savingsTransaction.Amount;
                    }
                    else
                    {
                        savingsAccountBalance = savingsAccountBalance - savingsTransaction.Amount;
                    }
                }
                foreach (var checkingTransaction in checkingTransactions)
                {
                    if (checkingTransaction.Type == "deposit")
                    {
                        checkingAccountBalance = checkingAccountBalance + checkingTransaction.Amount;
                    }
                    else
                    {
                        checkingAccountBalance = checkingAccountBalance - checkingTransaction.Amount;
                    }
                }


                if (choice == "deposit")
                {
                    Console.WriteLine("Deposit into Savings or Checking? ");
                    var newAccount = Console.ReadLine().ToLower().Trim();
                    Console.WriteLine("How much would you like to Deposit? ");
                    var newAmount = int.Parse(Console.ReadLine());

                    var newtransaction = new Transaction()
                    {
                        Account = newAccount,
                        Amount = newAmount,
                        Type = "deposit",
                    };
                    transactions.Add(newtransaction);
                }
                else if (choice == "withdrawal")
                {

                    Console.WriteLine("Withdraw from Savings or Checking? ");
                    var newAccount = Console.ReadLine().ToLower().Trim();
                    Console.WriteLine("How much would you like to Withdraw? ");
                    var newAmount = int.Parse(Console.ReadLine());
                    if (newAccount == "checking" && newAmount < checkingAccountBalance)
                    {
                        var newtransaction = new Transaction()
                        {
                            Account = newAccount,
                            Amount = newAmount,
                            Type = "withdrawal",
                        };
                        transactions.Add(newtransaction);
                    }
                    else if (newAccount == "savings" && newAmount < savingsAccountBalance)
                    {
                        var newtransaction = new Transaction()
                        {
                            Account = newAccount,
                            Amount = newAmount,
                            Type = "withdrawal",
                        };
                        transactions.Add(newtransaction);
                    }
                    else
                    {
                        Console.WriteLine("Insufficient Funds");

                    }
                }
                else if (choice == "balance")
                {

                    Console.WriteLine($"The balances of all of your checking is {checkingAccountBalance} and savings is {savingsAccountBalance} ");
                }


                // write transaction to file
            }
        }
    }
}









// switch (choice)
// {

// If (choice == “DEPOSIT”
// case “Deposit” (if (userChoice==Deposit) ADD))
// {
// Ask the user "Do you want to deposit into Savings or Checking?"
// Console.Write(“Do you want to deposit into Savings or Checking?” );
// Console.Write(“Ask the user what they would like to choose? “);
// var newAccount = Console.ReadLine(); (This Should store what they choose)

// Ask $"How much they want to input into {answer}" 
// Console.Write($"How much they want to input into {newAccount}? “}
// var newAmount = int.Parse(Console.ReadLine()); (This will store what their amount is. The int.Parse is changing the string to an int) 

// *Time to create a new instance(object) of Transaction*

// var newtransaction= new Transaction()
//       - Amount = amountOfDeposit ( newtransaction.Amount=newAmount)
//       - KindOfTransaction = "Deposit" ( newtransaction.Type=”Deposit” (deposit or withdraw))
//       - TimeStamp ( fill in with the current time = DateTime.Now)
//       - WhereGoing = whereDepositIsGoing (newtransaction.Account=newAccount)

// transaction.Add(newtransaction)

//     *Write all the transactions to the file (the four lines of code for the fileWriter)
//     Break; “” *

// case “Withdraw”:
// 	Ask the user if they would like to choose Savings or Checking?

// If (Savings)
// Find.Savings 
// inside Where savings variable-- Where.Deposit and Where.Withdraw 
// Sum of the totals of the Deposit amount and then the Sum of the totals of the Withdraw   amount
// Subtract Withdraw Amount from the Deposit Amount (Store in variable) **We will Use this variable**
// Ask how much they want to withdraw from savings?
// Store Console.ReadLine in variable
// If (Star variable<Asking Variable)
// {
// 	Console.WriteLine (NO FUNDS!)
// }

// If(Star variable>Asking Variable)
// { 
// var newtransaction= new Transaction()
//       - Amount = amountOfWithdraw( newtransaction.Amount=newAmount)
//       - KindOfTransaction = "Withdraw" ( newtransaction.Type=”Withdraw” (deposit or withdraw))
//       - TimeStamp ( fill in with the current time = DateTime.Now)
//       - WhereGoing = whereWithdrawIsGoing (newtransaction.Account=newAccount)

// transaction.Add(newtransaction)
// }


// 	If (Checking)
// Where.Checking
// inside where checking variable-- Where.Deposit and Where.Withdraw 
// Sum of the totals of the Deposit amount and then the Sum of the totals of the Withdraw   amount
// Subtract Withdraw Amount from the Deposit Amount (Store in variable) **We will Use this variable**
// Ask how much they want to withdraw from checking?
// Store Console.ReadLine in variable
// If (Star variable<Asking Variable)
// {
// 	Console.WriteLine (NO FUNDS!)
// }

// If(Star variable>Asking Variable)
// { 
// var newtransaction= new Transaction()
//       - Amount = amountOfWithdraw( newtransaction.Amount=newAmount)
//       - KindOfTransaction = "Withdraw" ( newtransaction.Type=”Withdraw” (deposit or withdraw))
//       - TimeStamp ( fill in with the current time = DateTime.Now)
//       - WhereGoing = whereWithdrawIsGoing (newtransaction.Account=newAccount)

// transaction.Add(newtransaction)
// }


// If (Transaction History)
// 	Ask the user if they would like to choose Savings or Checking?
// 	If (Savings)
// 	Use Where function to filter out the Account by Savings 
// 	Foreach (var save in savings)
// 	{
// 	Print out: Your Transaction History for Savings
// 	}
// 	If (Checking)
// 	Use Where function to filter out the Account by Checking
// 	Foreach (var check in checking)
// 	{
// 	Print out: Your Transaction History for Checking
// 	}

// If (Balance)
// 	Ask the user if they would like to choose Savings or Checking?
// If (Savings) 
// Where is Savings 
// Use where you have savings variable-- Where.Deposit and Where.Withdraw 
// Sum of the totals of the Deposit amount and then the Sum of the totals of the Withdraw   amount
// Subtract Withdraw Amount from the Deposit Amount (Store in variable)
// Console WriteLine the Variable amount stated above
// If (Checking)
// Where  is Checking 
// use Where you have checking variable-- Where.Deposit and Where.Withdraw 
// Sum of the totals of the Deposit amount and then the Sum of the totals of the Withdraw   amount
// Subtract Withdraw Amount from the Deposit Amount (Store in variable)
// Console WriteLine the Variable amount stated above

// If (Quit)
// 	Bool is True

// 11. Say Goodbye
