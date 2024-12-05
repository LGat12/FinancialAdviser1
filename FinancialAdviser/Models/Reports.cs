namespace FinancialAdviser.Models
{
    public class Report
    {
        public int ReportId { get; set; }                // Unique identifier for each report
        public string ReportType { get; set; }           // Type of report (e.g., income, expenses, savings)
        public string ReportPeriod { get; set; }         // Period for the report (e.g., monthly, yearly)
        public decimal TotalIncome { get; set; }         // Total income during the report period
        public decimal TotalExpenses { get; set; }       // Total expenses during the report period
        public decimal SavingsAmount { get; set; }       // Total savings amount during the report period
        public DateTime CreatedAt { get; set; }          // Timestamp when the report was created
        public DateTime UpdatedAt { get; set; }          // Timestamp when the report was last updated
    }

}
