namespace FinancialAdviser.Models
{
    public class Budgets
    {
        public int budgetId { get; set; }            // Unique identifier for the budget
        public int categoryId { get; set; }          // Category for the budget (e.g., Food, Transportation)
        public decimal limitAmount { get; set; }      // Limit amount for the budget
        public DateTime startDate { get; set; }       // Start date for the budget period
        public DateTime endDate { get; set; }         // End date for the budget period
        public DateTime createdAt { get; set; }       // Timestamp when the record was created
        public DateTime updatedAt { get; set; }       // Timestamp when the record was last updated
    }

}
