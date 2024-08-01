using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccessLayer.Model.Interfaces;
using DataAccessLayer.Model.Models;


namespace DataAccessLayer.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
	    private readonly IDbWrapper<Employee> _employeeDbWrapper;

	    public EmployeeRepository(IDbWrapper<Employee> employeeDbWrapper)
	    {
            _employeeDbWrapper = employeeDbWrapper;
        }

        public async Task<Employee> GetByCodeAsync(string employeeCode)
        {
            var employees = await _employeeDbWrapper.FindAsync(t => t.EmployeeCode.Equals(employeeCode));
            return employees.FirstOrDefault();
            
        }      
    }
}
