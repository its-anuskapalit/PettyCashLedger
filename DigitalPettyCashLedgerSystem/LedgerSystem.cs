using System;
using System.Collections.Generic;
using System.Transactions;
namespace DigitalPettyCashLedger
{
    #region interface
    /// <summary>
    /// To define the method for all ledger entities
    /// <returns>
    /// Returns a string containing the ledge details.
    /// </returns>
    /// </summary>
    public interface IReportable
    {
        string GetSummary();
    }

    #endregion
    #region Transaction class
    #endregion
    #region Chid class IncomeTransaction
    /// <summary>
    /// Represents an income entry added into the digital petty cash ledger.
    /// </summary>
    /// <para>
    /// Stores the source of income along with inherited transaction properties and
    /// generates a detailed income report string.
    /// </para>
    /// <returns>
    /// Returns a formatted string representing the income transaction details.
    /// </returns>
    public class IncomeTransaction : Transaction
    {
        public string Source { get; set; }
        //override method 
        public override string GetSummary()
        {
            return $"Id: {Id}, Date: {Date}, Income: Rs{Amount}, Source: {Source}, Description: {Description}";
        }
    }
    #endregion
    #region Child class ExpenseTransaction
    /// <summary>
    /// Represents an expense entry recorded in the digital petty cash ledger.
    /// </summary>
    /// <para>
    /// Captures the expense category along with transaction metadata and provides
    /// a complete expense summary.
    /// </para>
    /// <returns>
    /// Returns a formatted string representing the expense transaction details.
    /// </returns>
    public class ExpenseTransaction : Transaction
    {
        public string Category { get; set; }
        //override method
        public override string GetSummary()
        {
            return $"Id: {Id}, Date: {Date}, Expense: Rs{Amount}, Category: {Category}, Description: {Description}";
        }
    }
    #endregion
    #region Generic Ledge
    /// <summary>
    /// Generic ledger engine responsible for storing and managing financial transactions.
    /// </summary>
    /// <para>
    /// This class supports adding, filtering, retrieving and computing totals for
    /// all transaction types derived from the Transaction base class.
    /// </para>
    /// <para>
    /// It works for both income and expense ledgers using C# generics.
    /// </para>
    /// <returns>
    /// Returns transaction collections or computed monetary totals based on the operation.
    /// </returns>
    public class Ledger<T> where T : Transaction
    {
        private List<T> transactions = new List<T>();
        public void AddEntry(T entry)
        {
            try
            {
                if (entry == null)
                    throw new ArgumentNullException("Transaction cannot be null.");

                if (entry.Amount <= 0)
                    throw new Exception("Amount must be greater than zero.");

                transactions.Add(entry);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while adding transaction: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("AddEntry operation completed.");
            }
        }
        //method to add transactions by the date
        public List<T> GetTransactionsByDate(DateTime date)
        {
            List<T> Result = new List<T>();
            foreach (T t in transactions)
            {
                if (t.Date.Date == date.Date)
                {
                    Result.Add(t);
                }
            }
            return Result;
        }
        // method to calculate the total amount
        public decimal CalculateTotal()
        {
            try
            {
                List<Transaction> Results = new List<Transaction>();

                foreach (T t in transactions)
                {
                    Results.Add(t);
                }
                //calling the helper method
                return TransactionCalculator.CalculateTotal(Results);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while calculating total: " + ex.Message);
                return 0;
            }
            finally
            {
                Console.WriteLine("CalculateTotal executed.");
            }
        }
        //method returning the transactions
        public List<T> GetAll()
        {
            return new List<T>(transactions);
        }
    }
    #endregion
}
