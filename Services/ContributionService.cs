using System.Linq;
using ProjectCompany.Activity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;
using System.Collections.Generic;

namespace ProjectCompany.Services
{
    public class ContributionService
    {
        protected AppContext appContext;
        public ContributionService(AppContext appContext)
        {
            this.appContext = appContext;
        }

        public Contribution GetContributionById(int id)
        {
            return appContext.contributions
                    .Include(c => c.Project)
                    .Include(c => c.Employee)
                    .Include(c => c.ContributionSkills)
                    .ThenInclude(cs => cs.Skill)
                    .Where(c => c.Id == id)
                    .First();
        }

        public void AddContributon(Contribution contribution)
        {
            this.appContext.contributions.Add(contribution);
            this.appContext.SaveChanges();
        }

        public void UpdateContribution(Contribution contribution)
        {
            this.appContext.Update(contribution);
            this.appContext.SaveChanges();
        }

        public void RemoveContribution(Contribution contribution)
        {
            this.appContext.contributions.Remove(contribution);
            this.appContext.SaveChanges();
        }
    }
}