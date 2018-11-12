using ProjectCompany.Person;

namespace ProjectCompany
{
    public struct ProjectCandidate
    {
        public Employee employee;
        public float skillCoverage;

        public ProjectCandidate(Employee employee, float skillCoverage)
        {
            this.employee = employee;
            this.skillCoverage = skillCoverage;
        }
    }
}