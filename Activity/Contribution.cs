using System.Collections.Generic;
using ProjectCompany.Person;
using ProjectCompany;

namespace ProjectCompany.Activity
{
    public class Contribution
    {
        protected Project project;
        protected string title;
        protected List<Skill> skills;
        protected Employee employee;

        public Contribution(string title, Project project)
        {
            this.title = title;
            this.project = project;
        }

        public Project GetProject()
        {
            return this.project;
        }

        public string GetTitle()
        {
            return this.title;
        }

        public void SetEmployee(Employee employee)
        {
            this.employee = employee;
        }
    }
}
