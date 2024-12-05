namespace FinancialAdviser.Models
{
    public class SavingGoal
    {
        public int GoalId { get; set; }                  // Unique identifier for each saving goal
        public string GoalName { get; set; }             // Name of the saving goal (e.g., vacation, car)
        public decimal TargetAmount { get; set; }        // Target amount to save for the goal
        public decimal CurrentAmount { get; set; }       // Current amount saved towards the goal
        public DateTime DueDate { get; set; }            // Deadline for achieving the saving goal
        public DateTime CreatedAt { get; set; }          // Timestamp when the record was created
        public DateTime UpdatedAt { get; set; }          // Timestamp when the record was last updated
    }

}
