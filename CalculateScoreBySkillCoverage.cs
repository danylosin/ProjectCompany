using ProjectCompany.Person;
using System.Collections.Generic;
namespace ProjectCompany
{
    public class CalculateScoreBySkillCoverage : CalculatingScoreStrategy
    {
        protected List<Skill> skills;
        protected Employee employee;

        public CalculateScoreBySkillCoverage(Employee employee, List<Skill> skills)
        {
            this.employee = employee;
            this.skills = skills;
        }

        public float calculateScore(Employee employee)
        {
            int quanitityOfMatchedSkills = 0;
            foreach (Skill skill in this.skills) {
                if (employee.Skills.Contains(skill)) {
                    quanitityOfMatchedSkills++;
                }
            }            
            return (float)quanitityOfMatchedSkills / skills.Count;
        }
    }
}
