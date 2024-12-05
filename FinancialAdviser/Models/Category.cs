namespace FinancialAdviser.Models
{
    public class Category
    {
        public int CategoryId { get; set; }            // Unique identifier for each category
        public string CategoryName { get; set; }       // Name of the category
        public string Description { get; set; }         // Optional description of the category
        public DateTime CreatedAt { get; set; }         // Timestamp for when the category was created
        public DateTime UpdatedAt { get; set; }         // Timestamp for when the category was last updated
    }

}
