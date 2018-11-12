using ProjectCompany.Person;

namespace ProjectCompany
{
    public struct ProjectCandidate
    {
        public Employee Employee { get; private set; }
        public float SkillCoverage { get; private set; } //score

        public ProjectCandidate(Employee employee, float skillCoverage)
        {
            this.Employee = employee;
            this.SkillCoverage = skillCoverage;
        }
    }
}