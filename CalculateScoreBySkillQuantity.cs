using ProjectCompany.Person;
using System.Collections.Generic;
namespace ProjectCompany
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
