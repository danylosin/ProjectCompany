using ProjectCompany.Person;
using System.Collections.Generic;
namespace ProjectCompany
{
    public class CalculateSkillQuantity : CalculatingScoreStrategy
    {     
        protected List<Skill> skills;

        public CalculateSkillQuantity(List<Skill> skills)
        {
            this.skills = skills;
        }

        public float calculateScore(Employee employee)
        {
            return (float)(employee.Skills.Count / this.skills.Count);
        }
    }
}
