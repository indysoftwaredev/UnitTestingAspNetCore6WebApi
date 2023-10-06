using EmployeeManagement.DataAccess.Entities;
using EmployeeManagement.Test.Fixtures;
using EmployeeManagement.Test.TestData;
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

        [Theory]
        [InlineData("37e03ca7-c730-4351-834c-b66f280cdb01")]
        [InlineData("1fd115cf-f44c-4982-86bc-a8fe2e4ff83e")]
        public void CreateInternalEmployee_InternalEmployeeCreated_MustHaveAttendedObligatoryCourses(
            Guid courseId)
        {
            //Act
            var internalEmployee = 
                _employeeServiceFixture.EmployeeService.CreateInternalEmployee("Brooklyn", "Cannon");

            //Assert
            Assert.Contains(internalEmployee.AttendedCourses,
               c => c.Id == courseId);
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

        public static IEnumerable<object[]> ExampleTestDataForGiveRaise_WithProperty
        {
            get
            {
                return new List<object[]>
                {
                    new object[] {100, true},
                    new object[] {200, false},
                };
            }
        }

        public static IEnumerable<object[]> ExampleTestDataForGiveRaiseWithMethod(
            int testDataInstancesToProvide)
        {
            var testData = new List<object[]>
                {
                    new object[] {100, true},
                    new object[] {200, false},
                };
            return testData.Take(testDataInstancesToProvide);
        }

        [Theory]
        [MemberData(nameof(ExampleTestDataForGiveRaise_WithProperty))]
        [MemberData(nameof(ExampleTestDataForGiveRaiseWithMethod), 2)]
        public async Task GiveRaise_RaiseGiven_EmployeeMinimumRaiseGivenMatchesValue_MemberData(
            int raiseGiven, bool expectedValueForMinimumRaisegiven)
        {
            // Arrange  
            var internalEmployee = new InternalEmployee(
                "Brooklyn", "Cannon", 5, 3000, false, 1);

            await _employeeServiceFixture.EmployeeService
                .GiveRaiseAsync(internalEmployee, raiseGiven);

            Assert.Equal(expectedValueForMinimumRaisegiven, internalEmployee.MinimumRaiseGiven);

        }

        [Theory]
        [ClassData(typeof(EmployeeServiceTestData))]
        public async Task GiveRaise_RaiseGiven_EmployeeMinimumRaiseGivenMatchesValue_ClassData(
            int raiseGiven, bool expectedValueForMinimumRaisegiven)
        {
            // Arrange  
            var internalEmployee = new InternalEmployee(
                "Brooklyn", "Cannon", 5, 3000, false, 1);

            await _employeeServiceFixture.EmployeeService
                .GiveRaiseAsync(internalEmployee, raiseGiven);

            Assert.Equal(expectedValueForMinimumRaisegiven, internalEmployee.MinimumRaiseGiven);

        }
    }
}
