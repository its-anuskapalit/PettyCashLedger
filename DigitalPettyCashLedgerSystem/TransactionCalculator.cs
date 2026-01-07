using System;
namespace DigitalPettyCashLedger
{
    #region Helper class
    /// <summary>
    /// Helper class for the calculations 
    /// </summary>
     static class TransactionCalculator
    {
        public static decimal CalculateTotal(List<Transaction> transactions)
        { 
            decimal Total = 0;
            #region loop
            //looping over the list of transactions
            foreach (Transaction t in transactions)
            {
                Total += t.Amount;
            }
            return Total;
        }
        #endregion
    }
    #endregion
}
