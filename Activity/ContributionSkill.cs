using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ProjectCompany.Person;

namespace ProjectCompany.Activity
{
    public class ContributionSkill
    {
        [Column("contribution_id")]
        public int ContributionId { get; set; }

        public Contribution Contribution {get; set;} 

        [Column("skill_id")]
        public int SkillId { get; set; }

        public Skill Skill { get; set; }
    }
}