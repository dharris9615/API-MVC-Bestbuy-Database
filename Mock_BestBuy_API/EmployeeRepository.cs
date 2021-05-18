using System;
using System.Collections.Generic;
using System.Data;
using Dapper;

namespace Mock_BestBuy_API
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly IDbConnection _connection;

        public EmployeeRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return _connection.Query<Employee>("SELECT * FROM bestbuy.employees;");
        }

        public Employee GetEmployee(int id)
        {
            return _connection.QuerySingleOrDefault<Employee>("SELECT * FROM bestbuy.employees WHERE employeeID = @id;", new { id = id });
        }

        public void InsertEmployee(Employee emp)
        {
            _connection.Execute("INSERT INTO bestbuy.employees (FirstName, MiddleInitial, LastName, EmailAddress, PhoneNumber, Title, DateOfBirth)" +
                                " VALUES ( @FirstName, @MiddleInitial, @LastName, @EmailAddress, @PhoneNumber, @Title, @DateOfBirth);",
            new { firstname = emp.FirstName, middleinitial = emp.MiddleInitial, lastname = emp.LastName, emailaddress = emp.EmailAddress, phonenumber = emp.PhoneNumber, title = emp.Title, dateofbirth = emp.DateOfBirth });
        }

        public void UpdateEmployee(Employee emp)
        {
            _connection.Execute("UPDATE EMPLOYEEs set firstname = @firstname, middleinitial = @middleinitial, Lastname = @lastname, emailaddress = @emailaddress, phonenumber = @phonenumber, title = @title, Dateofbirth = @dateofbirth \n" +
                                "WHERE EMPLOYEEID = @employeeID;",
            new { firstname = emp.FirstName, middleinitial = emp.MiddleInitial, lastname = emp.LastName, emailaddress = emp.EmailAddress, phonenumber = emp.PhoneNumber, title = emp.Title, dateofbirth = emp.DateOfBirth, employeeID = emp.EmployeeID });
        }

        //public void DeleteEmployee(Employee emp)
        //{
        //    _connection.Execute("DELETE from bestbuy.employees WHERE EmployeeID = @id", new { id = emp.EmployeeID });
        //    _connection.Execute("DELETE from bestbuy.sales WHERE EmployeeID = @id", new { id = emp.EmployeeID });
           

        //}

        public void DeleteEmployee(Employee employeeToDelete)
        {
            _connection.Execute("DELETE from bestbuy.employees WHERE EmployeeID = @id", new { id = employeeToDelete.EmployeeID });
            _connection.Execute("DELETE from bestbuy.sales WHERE EmployeeID = @id", new { id = employeeToDelete.EmployeeID });
        }
    }
}
