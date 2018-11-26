using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;
using ProjectCompany;
using System.Linq;
using System.Collections.Generic;
using System;
using ProjectCompany.Models;

namespace ProjectCompany.Services
{
    public class ProjectService
    {
        protected ApplicationContext appContext;
        public ProjectService(ApplicationContext appContext)
        {
            this.appContext = appContext;
        }

        public Project GetProjectById(int id)
        {
            return appContext.projects
                    .Include(p => p.Contributions)
                    .ThenInclude(c => c.ContributionSkills)
                    .ThenInclude(cs => cs.Skill)
                    .Include(p => p.Contributions)
                    .ThenInclude(c => c.Employee)
                    .SingleOrDefault(p => p.Id == id);   
        }

        public List<Project> GetAllProjects()
        {
            return appContext.projects
                    .Include(p => p.Contributions)
                    .ThenInclude(c => c.ContributionSkills)
                    .ThenInclude(cs => cs.Skill)
                    .Include(p => p.Contributions)
                    .ThenInclude(c => c.Employee)  
                    .ToList();
        }

        public List<Project> GetProjectsByCountOfContributions(int limit)
        {
            return appContext.projects
                    .Include(p => p.Contributions)
                    .OrderByDescending(p => p.Contributions.Count)
                    .Take(limit)
                    .ToList();
        }

        public List<Contribution> GetProjectActivityByYear(Project project, DateTime dateTime)
        {
            int year = dateTime.Year;
            int id = project.Id;

            return appContext.contributions
                    .Include(c => c.Project)
                    .Include(c => c.Employee)
                    .Include(c => c.ContributionSkills)
                    .ThenInclude(cs => cs.Skill)
                    .Where(c => c.Project.Id == id && c.DatePeriod.From.Year == year && c.DatePeriod.To.Year == year )
                    .ToList();        
        }

        public List<Contribution> GetProjectActivyByDatePeriod(Project project, DatePeriod datePeriod)
        {
            int id = project.Id;
            return appContext.contributions
                    .Include(c => c.Project)
                    .Include(c => c.Employee)
                    .Include(c => c.ContributionSkills)
                    .ThenInclude(cs => cs.Skill)
                    .Where(c => c.Project.Id == id && c.DatePeriod.From >= datePeriod.From && c.DatePeriod.To <= datePeriod.To)
                    .ToList();
        }

        public void AddProject(Project project)
        {
            this.appContext.projects.Add(project);
            this.appContext.SaveChanges();
        }

        public void UpdateProject(Project project)
        {
            this.appContext.projects.Update(project);
            this.appContext.SaveChanges();
        }

        public void DeleteProject(Project project)
        {
            this.appContext.projects.Remove(project);
            this.appContext.SaveChanges();
        }
    }
}