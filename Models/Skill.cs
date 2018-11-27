using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectCompany.Models
{
    public class Skill
    {
        public int Id { get; set;}
        
        [Required]
        
        public string Title { get; set; }

        public List<EmployeeSkill> EmployeeSkills { get; set;}

        public List<ContributionSkill> ContributionSkills { get; set; }

        public Skill() {}
        public Skill(string title) 
        {
            this.Title = title;
        }
    }
}
