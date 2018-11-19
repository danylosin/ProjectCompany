using System.Collections.Generic;
using System.Linq;
using ProjectCompany.Models;

namespace ProjectCompany.Services
{
    public class SkillService
    {
        protected AppContext appContext;
        public SkillService(AppContext appContext)
        {
            this.appContext = appContext;
        }

        public List<Skill> GetAllSkills()
        {
            return appContext.skills.ToList();
        }

        public void AddSkill(Skill skill)
        {
            this.appContext.skills.Add(skill);
            this.appContext.SaveChanges();
        }
    }
}