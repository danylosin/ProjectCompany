using System.Collections.Generic;
using System.Linq;
using ProjectCompany.Models;

namespace ProjectCompany.Services
{
    public class SkillService
    {
        protected ApplicationContext appContext;
        public SkillService(ApplicationContext appContext)
        {
            this.appContext = appContext;
        }

        public List<Skill> GetAllSkills()
        {
            return appContext.skills.ToList();
        }

        public Skill GetSkillById(int id) {
            return appContext.skills.SingleOrDefault(s => s.Id == id);
        }
        public bool AddSkill(Skill skill)
        {
            if (!this.isUniqueSkillTitle(skill)) {
                this.appContext.skills.Add(skill);
                this.appContext.SaveChanges();

                return true;
            }
            
            return false;
        }

        public void DeleteSkill(Skill skill) {
            this.appContext.Remove(skill);
            this.appContext.SaveChanges();
        }

        public bool isUniqueSkillTitle(Skill skill) {
            if (this.appContext.skills.SingleOrDefault(s => s.Title == skill.Title) != null) {
                return true;
            }
            return false;
        }
    }
}