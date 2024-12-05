using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using FinancialAdviser.Services;
using FinancialAdviser.Models;
using System.Collections.Generic;

namespace FinancialAdviser.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DatabaseService _databaseService;

        public UsersController(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        // GET: api/Customers
        [HttpGet]
        public IActionResult GetUser()
        {
            var users = new List<Users>();

            using (MySqlConnection connection = _databaseService.GetConnection())
            {
                connection.Open();
                string query = "SELECT UserID, FirstName, LastName, Email FROM Users";
                MySqlCommand command = new MySqlCommand(query, connection);
                MySqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var user = new Users
                    {
                        UserId = reader.GetInt32(0),
                        FirstName = reader.GetString(1),
                        LastName = reader.GetString(2),
                        Email = reader.GetString(3)
                    };
                    users.Add(user);
                }

                reader.Close();
            }

            return Ok(users);
        }
    }
}
