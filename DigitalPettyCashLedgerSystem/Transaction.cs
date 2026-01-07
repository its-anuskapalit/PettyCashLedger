namespace DigitalPettyCashLedger
{
    #region
    /// <summary>
    /// Represents the base entity for all financial transactions.
    /// <para>
    /// This abstract class defines the common properties such as Id, Date, Amount and Description which are shared by both income and expense transactions.
    /// It enforces implementation of the GetSummary method to guarantee reporting
    /// It has a GetSummary method for displaying the report
    /// consistency across derived transaction types.
    /// </para>
    /// <returns>
    /// Returns a formatted transaction summary when implemented by derived classes.
    /// </returns>
    /// </summary>
    public abstract class Transaction : IReportable
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }

        public abstract string GetSummary();
    }
    #endregion
}
