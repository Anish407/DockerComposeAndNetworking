using APi2.Core.Entities;

namespace API2.Core.Repository;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAllEmployeesAsync();
}