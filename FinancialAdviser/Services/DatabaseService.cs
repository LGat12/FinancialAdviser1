using MySql.Data.MySqlClient;

namespace FinancialAdviser.Services
{
    // Service class for database operations related to budgets
    public class DatabaseService
    {
        private readonly string _connectionString; // Stores the connection string to the database

        // Constructor that initializes the connection string from the configuration
        public DatabaseService(IConfiguration configuration)
        {
            // Retrieve the connection string from the configuration
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        // Method to retrieve the budgets for a specific user by their UserId
        public IEnumerable<object> GetBudgetsByUserId(int userId)
        {
            var budgets = new List<object>(); // List to store the retrieved budgets

            // Create a new connection to the MySQL database using the connection string
            using (var connection = new MySqlConnection(_connectionString))
            {
                // Open the database connection
                connection.Open();

                // Define the SQL query to get the budget details, join with categories and users tables
                string query = @"
                SELECT 
                    b.BudgetId,
                    b.LimitAmount,
                    b.StartDate,
                    b.EndDate,
                    b.CreatedAt,
                    b.UpdatedAt,
                    c.CategoryName,
                    b.EntityId
                FROM budgets b
                INNER JOIN categories c ON b.CategoryId = c.CategoryId
                INNER JOIN users u ON u.UserID = b.EntityId
                WHERE u.UserID = @UserId"; // Only fetch budgets for the specified user

                // Create a MySQL command object with the query and connection
                using (var command = new MySqlCommand(query, connection))
                {
                    // Add the UserId parameter to the query to prevent SQL injection
                    command.Parameters.AddWithValue("@UserId", userId);

                    // Execute the query and get a data reader
                    using (var reader = command.ExecuteReader())
                    {
                        // Iterate through the rows in the result set
                        while (reader.Read())
                        {
                            // Add each row to the 'budgets' list as an anonymous object
                            budgets.Add(new
                            {
                                BudgetId = reader["BudgetId"], // Budget ID
                                LimitAmount = reader["LimitAmount"], // Budget limit
                                StartDate = reader["StartDate"], // Start date of the budget
                                EndDate = reader["EndDate"], // End date of the budget
                                CreatedAt = reader["CreatedAt"], // Timestamp of when the budget was created
                                UpdatedAt = reader["UpdatedAt"], // Timestamp of the last update to the budget
                                CategoryName = reader["CategoryName"], // Name of the category associated with the budget
                                EntityId = reader["EntityId"] // Entity (user) ID associated with the budget
                            });
                        }
                    }
                }
            }

            // Return the list of budgets
            return budgets;
        }

        // Helper method to get a connection to the database
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(_connectionString); // Return a new connection using the connection string
        }
    }
}
