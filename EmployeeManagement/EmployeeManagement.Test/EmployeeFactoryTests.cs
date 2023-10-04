﻿using EmployeeManagement.Business;
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
        public void CreateEmployee_ConstructInternalEMployee_SalaryMustBe2500()
        {
            var employeeFactory = new EmployeeFactory();
            var employee = (InternalEmployee)employeeFactory.CreateEmployee("Kevin", "Dockx");
            Assert.Equal(2500, employee.Salary);
        }

    }
}
