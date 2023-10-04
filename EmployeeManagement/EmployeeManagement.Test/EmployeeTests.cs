using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class EmployeeTests
    {
        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstAndLastName_FullNameIsDoncatenated()
        {
            var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);
            employee.FirstName = "Lucia";
            employee.LastName = "SHELTON";
            Assert.Equal("Lucia Shelton", employee.FullName, ignoreCase: true);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstAndLastName_StartsWithFirstName()
        {
            var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);
            employee.FirstName = "Lucia";
            employee.LastName = "Shelton";
            Assert.StartsWith(employee.FirstName, employee.FullName);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstAndLastName_EndsWithLastName()
        {
            var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);
            employee.FirstName = "Lucia";
            employee.LastName = "Shelton";
            Assert.EndsWith(employee.LastName, employee.FullName);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstAndLastName_ContainsPartOfConcatenation()
        {
            var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);
            employee.FirstName = "Lucia";
            employee.LastName = "Shelton";
            Assert.Contains("ia Sh", employee.FullName);
        }

        [Fact]
        public void EmployeeFullNamePropertyGetter_InputFirstAndLastName_SoundsLikeConcatenation()
        {
            var employee = new InternalEmployee("Kevin", "Dockx", 0, 2500, false, 1);
            employee.FirstName = "Lucia";
            employee.LastName = "Shelton";

            Assert.Matches("Lu(c|s|z)ia Shel(t|d)on", employee.FullName);
        }
    }
}
