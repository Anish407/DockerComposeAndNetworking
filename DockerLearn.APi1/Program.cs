using API1.Infra.HttpClients;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration) // Optional: Read configuration from appsettings.json
    .WriteTo.Console()
    .WriteTo.File("Logs/log-.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

// Replace the default logging with Serilog
builder.Logging.ClearProviders();
builder.Logging.AddSerilog();

builder.Services.AddHttpClient<Api2Client>();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.MapGet("/GetAllEmployees", async (Api2Client apiclient) => await apiclient.GetDataFromApi2()).WithOpenApi();

app.Run();