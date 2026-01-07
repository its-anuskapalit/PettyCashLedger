using System;
using System.Collections.Generic;
using DigitalPettyCashLedger;
/// <summary>
/// Main Method for running the system
/// </summary>
class Program
{
    static void Main()
    {
        #region object creation
        //creating objects for income ledge
        Ledger<IncomeTransaction> IncomeLedger = new Ledger<IncomeTransaction>();
        IncomeLedger.AddEntry(new IncomeTransaction
        {
            Id = 1,
            Date = DateTime.Now,
            Amount = 500,
            Source = "Main Cash",
            Description = "Monthly Float Refill"
        });
        //creating objects for expense ledge
        Ledger<ExpenseTransaction> ExpenseLedger = new Ledger<ExpenseTransaction>();
        ExpenseLedger.AddEntry(new ExpenseTransaction
        {
            Id = 2,
            Date = DateTime.Now,
            Amount = 20,
            Category = "Stationery",
            Description = "Pens and Files"
        });
        ExpenseLedger.AddEntry(new ExpenseTransaction
        {
            Id = 3,
            Date = DateTime.Now,
            Amount = 15,
            Category = "Food",
            Description = "Team Snacks"
        });
        #endregion
        #region Method calling
        //calling method for calculating the total
        decimal TotalIncome = IncomeLedger.CalculateTotal();
        decimal TotalExpense = ExpenseLedger.CalculateTotal();
        decimal NetBalance = TotalIncome - TotalExpense;
        #endregion
        #region Display calculations
        //display details
        Console.WriteLine("===== PETTY CASH SUMMARY =====");
        Console.WriteLine($"Total Income : Rs{TotalIncome}");
        Console.WriteLine($"Total Expense: Rs{TotalExpense}");
        Console.WriteLine($"Net Balance  : Rs{NetBalance}");
        #endregion
        #region TRANSACTION DETAILS
        List<Transaction> allTransactions = new List<Transaction>();
        allTransactions.AddRange(IncomeLedger.GetAll());
        allTransactions.AddRange(ExpenseLedger.GetAll());

        Console.WriteLine("\n===== TRANSACTION DETAILS =====");
        foreach (Transaction t in allTransactions)
        {
            Console.WriteLine(t.GetSummary());
        }
        #endregion
    }
}
