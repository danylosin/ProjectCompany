using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;
using System.Collections.Generic;
using ProjectCompany.Models;

namespace ProjectCompany.Services
{
    public class ContributionService
    {
        protected ApplicationContext appContext;
        public ContributionService(ApplicationContext appContext)
        {
            this.appContext = appContext;
        }

        public Contribution GetContributionById(int id)
        {
            return appContext.contributions
                    .Include(c => c.Project)
                    .Include(c => c.Employee)
                    .SingleOrDefault(c => c.Id == id);
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