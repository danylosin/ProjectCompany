using ProjectCompany.Activity;
using ProjectCompany.Person;
using System.Collections.Generic;
using System;

namespace ProjectCompany
{
    public class ProjectRecruting
    {
        protected Project project;
        protected List<Skill> skills;
        
        public ProjectRecruting(Project project, List<Skill> skills)
        {
            this.project = project;
            this.skills = skills;
        }

        public void Generate()
        {
            Console.WriteLine(this.project.GetTitle() + " needs next skills: ");
            foreach (Skill skill in this.skills) {
                Console.WriteLine(skill.GetTitle());
            }
        }
    }
}