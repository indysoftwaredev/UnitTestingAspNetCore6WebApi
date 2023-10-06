using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Test.TestData
{
    public class StronglyTypedEmployeeTestDataFromFile : TheoryData<int, bool>
    {
        public StronglyTypedEmployeeTestDataFromFile()
        {
            var testDataLines = File.ReadAllLines("TestData/EmployeeServiceTestData.csv");

            foreach (var line in testDataLines)
            {
                var splitString = line.Split(',');

                if (int.TryParse(splitString[0], out int raise)
                    && bool.TryParse(splitString[1], out bool minimumRaiseGiven))
                {
                    Add(raise, minimumRaiseGiven);
                }
                    
            }
        }
    }
}
