using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Extensions;
using ProjectCompany.Person;
using ProjectCompany.Activity;
using MySql.Data.EntityFrameworkCore.Extensions;

namespace ProjectCompany
{
    public class AppContext : DbContext
    {
        //public DbSet<Employee> employees {get; set;} 
        public DbSet<Skill> skills {get; set;}
        public DbSet<Contribution> contributions {get; set;}
        public DbSet<Project> projects {get; set;}

        public AppContext()
        {
            
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;UserId=root;Password=386991aA;database=ProjectCompany;");
        }
    }
}
