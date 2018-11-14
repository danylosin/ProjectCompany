using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectCompany.Person
{
    public class EmployeeSkill
    {
        [Column("employee_id")]
        public int EmployeeId { get; set; }

        public Employee Employee {get; set;}

        [Column("skill_id")]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}