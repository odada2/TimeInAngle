using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using TimeInAngle.Services;
using TimeInAngle.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add configuration
var configuration = builder.Configuration;

// Add logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();

// Register services
builder.Services.AddScoped<ClockAngleService>();

// Add controllers
builder.Services.AddControllers();

// Build the application
var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/error"); // Global error handler for production
}

// Use global exception handling middleware
app.UseMiddleware<ExceptionMiddleware>();

// Enable routing
app.UseRouting();

// Map controllers
app.MapControllers();

// Access configuration values
var appName = configuration["AppSettings:AppName"];
var maxRetries = configuration.GetValue<int>("AppSettings:MaxClockAngleCalculationRetries");

// Log configuration values
var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation($"App Name: {appName}");
logger.LogInformation($"Max Retries: {maxRetries}");

// Run the application
app.Run();