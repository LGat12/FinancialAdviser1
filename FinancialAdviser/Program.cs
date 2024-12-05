using FinancialAdviser.Services;

namespace FinancialAdviser
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<DatabaseService>(); // Register DatabaseService
            builder.Services.AddScoped<UserService>(); // Register UserService
            builder.Services.AddScoped<IUserService, UserService>(); // Ensure IUserService is registered

            builder.Services.AddControllers();

            // Swagger/OpenAPI configuration
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddHttpClient("API", client =>
            {
                client.BaseAddress = new Uri("http://localhost:5003"); // Set the base address
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}
