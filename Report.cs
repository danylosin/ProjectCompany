using ProjectCompany.Activity;
using ProjectCompany.Person;
using System;

namespace ProjectCompany
{
    public class Report
    {
        
        public Report()
        {

        }

        public void Generate(Employee employee)
        {
            Console.WriteLine(employee.GetName());
            foreach (Contribution contribution in employee.GetContributions()) {
                Console.WriteLine(contribution.GetTitle() + " in project " + contribution.GetProject().GetTitle());
            }
        }
    }
}