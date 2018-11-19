using ProjectCompany.Models;
using System.Collections.Generic;

namespace ProjectCompany.Services.Recruting
{
    public class CalculateScoreBySkillQuantity : CalculatingScoreStrategy
    {     

        public CalculateScoreBySkillQuantity(){}

        public float calculateScore(Employee employee)
        {
            return employee.EmployeeSkills.Count;
        }
    }
}
