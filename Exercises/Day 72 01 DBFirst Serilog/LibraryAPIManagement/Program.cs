
using LibraryAPIManagement.Data;
using LibraryAPIManagement.ExceptionsMiddleware;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System.Text.Json.Serialization;

namespace LibraryAPIManagement
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddDbContext<MyAppDbContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // 1.Configure Serilog
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information() // Log Info, Warning, and Error
                .WriteTo.Console()          // Also show logs in the debug console
                .WriteTo.File("logs/library-log.txt", rollingInterval: RollingInterval.Day) // Save to file
                .CreateLogger();

            // 2. Tell the Builder to use Serilog instead of the default logger
            builder.Host.UseSerilog();
            builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
    });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseAuthorization();

            // 3. Add Request Logging (Optional but highly recommended)
            // This logs every HTTP request (URL, Status Code, Time taken)
            app.UseSerilogRequestLogging();
            app.MapControllers();

            app.Run();
        }
    }
}
