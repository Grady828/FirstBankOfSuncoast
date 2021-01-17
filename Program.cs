using System;
using FirstBankOfSuncoast.Models;
using System.Linq;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using System.Globalization;
using System.Transactions;

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
            var fileReader = new StreamReader("transactions.csv");
            var csvReader = new CsvReader(fileReader, CultureInfo.InvariantCulture);
            var transactions = csvReader.GetRecords<Transaction>().ToList();
            fileReader.Close();




            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Welcome to First Bank OF Suncoast");
            Console.WriteLine();

            var userHasNotChosenToQuit = false;
            while (userHasNotChosenToQuit == false)
            {

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
                        TimeStamp = DateTime.Now,
                    };
                    transactions.Add(newtransaction);
                    var fileWriter = new StreamWriter("transactions.csv");
                    var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
                    csvWriter.WriteRecords(transactions);
                    fileWriter.Close();
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
                            TimeStamp = DateTime.Now,
                        };
                        transactions.Add(newtransaction);
                        var fileWriter = new StreamWriter("transactions.csv");
                        var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
                        csvWriter.WriteRecords(transactions);
                        fileWriter.Close();
                    }
                    else if (newAccount == "savings" && newAmount < savingsAccountBalance)
                    {
                        var newtransaction = new Transaction()
                        {
                            Account = newAccount,
                            Amount = newAmount,
                            Type = "withdrawal",
                            TimeStamp = DateTime.Now,
                        };
                        transactions.Add(newtransaction);
                        var fileWriter = new StreamWriter("transactions.csv");
                        var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
                        csvWriter.WriteRecords(transactions);
                        fileWriter.Close();

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
                else if (choice == "transaction history")
                {
                    Console.WriteLine("Which accounts transaction history would you like? ");
                    var accountToView = Console.ReadLine().ToLower().Trim();
                    var transactionsToView = transactions.Where(transaction => transaction.Account == accountToView);
                    foreach (var transaction in transactionsToView)
                    {
                        Console.WriteLine($"This {accountToView} account transaction is a ${transaction.Amount} {transaction.Type} ");
                    }

                }
                else if (choice == "quit")
                {
                    userHasNotChosenToQuit = true;
                }

            }

        }
    }
}











