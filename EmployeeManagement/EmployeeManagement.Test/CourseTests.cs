using EmployeeManagement.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test
{
    public class CourseTests
    {
        [Fact]
        public void CourseConstructor_ConstructCourse_IsNewMustBeTrue()
        {
            var course = new Course("Disaster Management 101");
            Assert.True(course.IsNew);
        }
    }
}
