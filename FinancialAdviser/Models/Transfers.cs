namespace FinancialAdviser.Models
{
    public class Transfers
    {
        public int transfersId { get; set; }            // main key 
        public int categoryId { get; set; }            // Foreign key referring to the category
        public string incomeOrExpense { get; set; }  // Enum property to define income or expense
        public DateTime createdAt { get; set; }

        public DateTime updatedAt { get; set; }


    }
}
