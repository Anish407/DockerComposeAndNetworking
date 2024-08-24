using API2.Core.Repository;
using API2.Infra.Repository;
using API2.Infra.Repository.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddDbContext<EmployeeContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/api/GetEmployees", async (IEmployeeRepository _employeeRepository) =>
{
    var employees = await _employeeRepository.GetAllEmployeesAsync();
    return employees;
}).WithOpenApi().WithName("GetEmployees");



app.Run();
