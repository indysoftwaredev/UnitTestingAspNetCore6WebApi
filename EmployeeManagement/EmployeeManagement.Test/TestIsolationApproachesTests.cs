using EmployeeManagement.Business;
using EmployeeManagement.DataAccess.DbContexts;
using EmployeeManagement.DataAccess.Services;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Sdk;

namespace EmployeeManagement.Test
{
    public class TestIsolationApproachesTests
    {
        [Fact] public async Task 
            AttendCourseAsync_CourseAttended_SuggestedBonusMustCorrectlyBeRecalculated()
        {
            //Arrange

            //create the database
            var connection = new SqliteConnection("Datasource=:memory:");
            connection.Open();

            //build a context for the repository to use
            var optionsBuilder = new DbContextOptionsBuilder<EmployeeDbContext>()
                .UseSqlite(connection);

            var dbContext = new EmployeeDbContext(optionsBuilder.Options);
            dbContext.Database.Migrate();

            //create the object containing the method under test
            var employeeManagementDataRepository =
                new EmployeeManagementRepository(dbContext);

            var employeeService = new EmployeeService(
                employeeManagementDataRepository, 
                new EmployeeFactory());

            //get course from database - Dealing with Customers 101
            var courseToAttend = await employeeManagementDataRepository
                .GetCourseAsync(Guid.Parse("844E14CE-C055-49E9-9610-855669C9859B"));

            //get existing employee - "Megan Jones"
            var internalEmployee = await employeeManagementDataRepository
                .GetInternalEmployeeAsync(Guid.Parse("72F2F5FE-E50C-4966-8420-D50258AEFDCB"));

            if(courseToAttend == null || internalEmployee == null)
            {
                throw new XunitException("Arranging the test failed.");
            }

            var expectedSuggestedBonus = internalEmployee.YearsInService
                * (internalEmployee.AttendedCourses.Count + 1) * 100;

            //Act
            await employeeService.AttendCourseAsync(internalEmployee, courseToAttend);

            //Assert
            Assert.Equal(expectedSuggestedBonus, internalEmployee.SuggestedBonus);
        }
    }
}
