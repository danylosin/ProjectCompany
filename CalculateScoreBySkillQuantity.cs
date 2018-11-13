using ProjectCompany.Person;
using System.Collections.Generic;
namespace ProjectCompany
{
    public class CalculateSkillQuantity : CalculatingScoreStrategy
    {     
        
        public float calculateScore(Employee employee)
        {
            return employee.Contributions.Count;
        }
    }
}