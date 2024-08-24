using APi2.Core.Entities;
using API2.Core.Repository;
using API2.Infra.Repository.Context;
using Microsoft.EntityFrameworkCore;

namespace API2.Infra.Repository;

public class EmployeeRepository(EmployeeContext context) : IEmployeeRepository
{
    public async Task<IEnumerable<Employee>> GetAllEmployeesAsync()
    {
        return await context.Employees.ToListAsync();
    }
}