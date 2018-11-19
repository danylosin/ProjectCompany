using ProjectCompany.Models;

namespace ProjectCompany.Services.Recruting
{
    public struct ProjectCandidate
    {
        public Employee Employee { get; private set; }
        public float Score { get; private set; } 

        public ProjectCandidate(Employee employee, float score)
        {
            this.Employee = employee;
            this.Score = score;
        }
    }
}