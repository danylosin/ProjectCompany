using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCompany.Models
{
    public class Employee
    {
        public int Id { get; private set; }

        [Required]
        public string Name { get; set; }
        public List<EmployeeSkill> EmployeeSkills {get; set;} 

        public List<Contribution> Contributions { get; private set; }
        
        public Employee() {}
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
