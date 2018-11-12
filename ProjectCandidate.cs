using ProjectCompany.Person;

namespace ProjectCompany
{
    public struct ProjectCandidate
    {
        public Employee Employee { get; private set; }
        public float Score { get; private set; } //score

        public ProjectCandidate(Employee employee, float Score)
        {
            this.Employee = employee;
            this.Score = Score;
        }
    }
}