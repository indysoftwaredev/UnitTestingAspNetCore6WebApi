using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class EmployeeFactoryTests
    {
        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500()
        {
            var employeeFactory = new EmployeeFactory();
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("Kevin", "Dockx");
            Assert.Equal(2500, employee.Salary);
        }

        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500()
        {
            var employeeFactory = new EmployeeFactory();
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("Kevin", "Dockx");
            Assert.True(employee.Salary >= 2500 && employee.Salary <= 3500, "Salary not in acceptable range.");
        }

        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_Alternative()
        {
            var employeeFactory = new EmployeeFactory();
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("Kevin", "Dockx");
            Assert.True(employee.Salary >= 2500, "Salary not in acceptable range.");
            Assert.True(employee.Salary <= 3500, "Salary not in acceptable range.");
        }

        [Fact]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_AlternativeWithinRange()
        {
            var employeeFactory = new EmployeeFactory();
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("Kevin", "Dockx");
            Assert.InRange(employee.Salary, 2500, 3500);
        }
    }
}
