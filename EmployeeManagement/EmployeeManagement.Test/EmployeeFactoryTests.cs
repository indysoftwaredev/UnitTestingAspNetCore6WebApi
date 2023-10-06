using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class EmployeeFactoryTests : IDisposable
    {
        private EmployeeFactory _employeeFactory;

        public EmployeeFactoryTests()
        {
            _employeeFactory = new EmployeeFactory();
        }

        public void Dispose()
        {
            //clean up setup code, if required
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_ReturnType")]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBe2500()
        {
            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("Kevin", "Dockx");
            Assert.Equal(2500, employee.Salary);
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_ReturnType")]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500()
        {
            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("Kevin", "Dockx");
            Assert.True(employee.Salary >= 2500 && employee.Salary <= 3500, "Salary not in acceptable range.");
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_ReturnType")]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_Alternative()
        {
            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("Kevin", "Dockx");
            Assert.True(employee.Salary >= 2500, "Salary not in acceptable range.");
            Assert.True(employee.Salary <= 3500, "Salary not in acceptable range.");
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_ReturnType")]
        public void CreateEmployee_ConstructInternalEmployee_SalaryMustBeBetween2500And3500_AlternativeWithinRange()
        {
            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("Kevin", "Dockx");
            Assert.InRange(employee.Salary, 2500, 3500);
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_Salary")]
        public void CreateEmployee_ConstructInternalEmployee_PrecisionExample()
        {
            var employee = (InternalEmployee)_employeeFactory.CreateEmployee("Kevin", "Dockx");
            employee.Salary = 2500.123m;
            Assert.Equal(2500, employee.Salary, 0);
        }

        [Fact]
        [Trait("Category", "EmployeeFactory_CreateEmployee_ReturnType")]
        public void CreateEmployee_IsExternalIsTrue_ReturnTypeMustBeExternalEmployee()
        {

            var employee = _employeeFactory.CreateEmployee("Kevin", "Dockx", "Marvin", true);

            Assert.IsType<ExternalEmployee>(employee);
            //Assert.IsAssignableFrom<Employee>(employee);
        }
    }
}
