using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Test.Fixtures;
using Xunit;

namespace EmployeeManagement.Test
{
    [Collection("EmployeeServiceCollection")]
    public class DataDrivenEmployeeServiceTests //: IClassFixture<EmployeeServiceFixture>
    {
        private readonly EmployeeServiceFixture _employeeServiceFixture;

        public DataDrivenEmployeeServiceTests(
            EmployeeServiceFixture employeeServiceFixture)
        {
            _employeeServiceFixture = employeeServiceFixture;
        }

        [Fact]
        public async Task GiveRaise_MinimumRaiseGiven_EmployeeMinimumRaiseGivenMustBeTrue()
        {
            // Arrange  
            var internalEmployee = new InternalEmployee(
                "Brooklyn", "Cannon", 5, 3000, false, 1);

            // Act
            await _employeeServiceFixture
                .EmployeeService.GiveRaiseAsync(internalEmployee, 100);

            // Assert
            Assert.True(internalEmployee.MinimumRaiseGiven);
        }


        [Fact]
        public async Task GiveRaise_MoreThanMinimumRaiseGiven_EmployeeMinimumRaiseGivenMustBeFalse()
        {
            // Arrange  
            var internalEmployee = new InternalEmployee(
                "Brooklyn", "Cannon", 5, 3000, false, 1);

            // Act 
            await _employeeServiceFixture.EmployeeService
                .GiveRaiseAsync(internalEmployee, 200);

            // Assert
            Assert.False(internalEmployee.MinimumRaiseGiven);
        }
    }
}
