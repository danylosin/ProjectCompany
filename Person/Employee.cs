using System.Collections.Generic;
using ProjectCompany.Activity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCompany.Person
{
    public class Employee
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public List<EmployeeSkill> EmployeeSkills {get; set;} 

        public List<Contribution> Contributions { get; private set; }

        public Employee(string name)
        {
            this.Name = name;
            this.Contributions = new List<Contribution>();
            this.EmployeeSkills = new List<EmployeeSkill>();
        }

        public void AddContribution(Contribution contribution)
        {
            if (!this.Contributions.Contains(contribution)) {
                this.Contributions.Add(contribution);
            }
        }
    }
}
