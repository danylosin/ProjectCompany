using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;
//using ProjectCompany.Person;
//using ProjectCompany.Activity;
using MySql.Data.EntityFrameworkCore.Extensions;
using ProjectCompany.Seeds;
using ProjectCompany.Models;

namespace ProjectCompany
{
    public class AppContext : DbContext
    {
        public DbSet<Employee> employees {get; set;} 
        public DbSet<Skill> skills { get; set; }
        public DbSet<Contribution> contributions { get; set; }
        public DbSet<Project> projects { get; set; }

        public DbSet<EmployeeSkill> employees_skills { get; set; }

        public AppContext(DbContextOptions<AppContext> options):base(options) {}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;UserId=root;Password=386991aA;database=ProjectCompany;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            this.OnContributionAndProjectModelCreating(modelBuilder);

            this.OnEmployeeSkillCreating(modelBuilder); 

            this.OnContributionSkillModelCreating(modelBuilder);  
        }

        protected void OnContributionAndProjectModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contribution>()
                .HasOne<Project>(c => c.Project)
                .WithMany(p => p.Contributions)
                .HasForeignKey(c => c.ProjectId);

            modelBuilder.Entity<Contribution>()
                .OwnsOne(
                    c => c.DatePeriod,
                    dp =>
                    {
                        dp.Property(p => p.From).HasColumnName("from_date");
                        dp.Property(p => p.To).HasColumnName("to_date");
                    }    
                );
            
            modelBuilder.Entity<Project>()
                .OwnsOne(
                    p => p.DatePeriod,
                    dp =>
                    {
                        dp.Property(p => p.From).HasColumnName("from_date");
                        dp.Property(p => p.To).HasColumnName("to_date");
                    }    
                );

            modelBuilder.Entity<Contribution>()
                .HasOne<Employee>(c => c.Employee)
                .WithMany(e => e.Contributions)
                .HasForeignKey(c => c.EmployeeId);    
        }

        protected void OnEmployeeSkillCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeSkill>()
                .HasKey(t => new { t.EmployeeId, t.SkillId});

            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(es => es.Employee)
                .WithMany(e => e.EmployeeSkills)
                .HasForeignKey(es => es.EmployeeId);  

            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(es => es.Skill)
                .WithMany(s => s.EmployeeSkills)
                .HasForeignKey(es => es.SkillId);
        }

        protected void OnContributionSkillModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContributionSkill>()
                .HasKey(t => new { t.ContributionId, t.SkillId});

            modelBuilder.Entity<ContributionSkill>()
                .HasOne(cs => cs.Contribution)
                .WithMany(c => c.ContributionSkills)
                .HasForeignKey(es => es.ContributionId);  

            modelBuilder.Entity<ContributionSkill>()
                .HasOne(es => es.Skill)
                .WithMany(s => s.ContributionSkills)
                .HasForeignKey(es => es.SkillId);
        }
    }
}
