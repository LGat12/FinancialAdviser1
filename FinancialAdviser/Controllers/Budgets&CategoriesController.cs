using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using FinancialAdviser.Services; // Replace with your service namespace
using FinancialAdviser.Models;  // Replace with your models namespace

namespace FinancialAdviser.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BudgetsController : ControllerBase
    {
        private readonly DatabaseService _databaseService; // Assuming a service for database operations

        public BudgetsController(DatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        [HttpGet("GetUserBudgets/{userId}")]
        public IActionResult GetUserBudgets(int userId)
        {
            try
            {
                // Query to get budgets and categories for the user
                var budgets = _databaseService.GetBudgetsByUserId(userId);

                if (budgets == null || !budgets.Any())
                    return NotFound(new { Message = "No budgets found for the specified user." });

                return Ok(budgets);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "An error occurred while retrieving data.", Error = ex.Message });
            }
        }
    }
}
