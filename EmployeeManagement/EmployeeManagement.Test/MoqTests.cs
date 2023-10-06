using EmployeeManagement.Business;
using EmployeeManagement.Services.Test;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class MoqTests
    {
        [Fact]
        public void FetchInternalEmployee_EmployeeFetched_SuggestedBonusMustBeCalculated()
        {
            //Arrange
            var employeeManagementTestDataRepository =
                new EmployeeManagementTestDataRepository();
            //var employeeFactory = new EmployeeFactory();
            var employeeFactoryMock = new Mock<EmployeeFactory>();
            var employeeService = new EmployeeService(
                employeeManagementTestDataRepository, employeeFactoryMock.Object);

            //Act
            var employee = employeeService.FetchInternalEmployee(
                Guid.Parse("72f2f5fe-e50c-4966-8420-d50258aefdcb"));

            //Assert
            Assert.Equal(400, employee.SuggestedBonus);

            //FetchInternalEmployee does not use the mock object.  It is used in the constructor
            //as a dummy object.
        }

        [Fact]
        public void CreateInternalEmployee_InternalEmployeeCreated_SuggestedBonusMustBeCalculated()
        {
            var employeeManagementTestDataRepository =
                new EmployeeManagementTestDataRepository();
            var employeeFactoryMock = new Mock<EmployeeFactory>();
            var employeeService = new EmployeeService(
                employeeManagementTestDataRepository, employeeFactoryMock.Object);

            decimal suggestedBonus = 200;

            //Act
            var employee = employeeService.CreateInternalEmployee("Kevin", "Dockx");

            //Assert
            Assert.Equal(suggestedBonus, employee.SuggestedBonus);

        }
    }
}
