using ProjectCompany.Person;
using System.Collections.Generic;
using System;

namespace ProjectCompany
{
    public class CalculateScoreBySkillCoverage : CalculatingScoreStrategy
    {
        protected List<Skill> skills;

        public CalculateScoreBySkillCoverage(List<Skill> skills)
        {
            this.skills = skills;
        }


        public float calculateScore(Employee employee)
        {
            int quanitityOfMatchedSkills = 0;

            foreach (Skill skill in this.skills) {
                foreach (EmployeeSkill employeeSkill in employee.EmployeeSkills) {
                    if (object.ReferenceEquals(employeeSkill.Skill, skill)) {
                        quanitityOfMatchedSkills++;
                    }
                }
            }   
            return (float)quanitityOfMatchedSkills / skills.Count;
        }

        public void OutputNeededSkills()
        {
            Console.WriteLine("Needed skills: ");
            foreach (Skill skill in this.skills) {
                Console.WriteLine(skill.Title + " ");
            }
        }
    }
}
