using System;
using System.Collections.Generic;

namespace Mock_BestBuy_API
{
    public interface IEmployeeRepository
    {
        public IEnumerable<Employee> GetEmployees();
        public Employee GetEmployee(int id);
        public void InsertEmployee(Employee employee);
        public void UpdateEmployee(Employee employee);
        //public void DeleteEmployee(Employee employee);
        public void DeleteEmployee(Employee employeeToDelete);
    }
}
