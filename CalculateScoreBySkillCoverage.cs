namespace ProjectCompany
{
    public class CalculateScoreBySkillCoverage : CalculatingScoreStrategy
    {
        public float calculateScore()
        {
            int quanitityOfMatchedSkills = 0;
            foreach (Skill skill in this.skills) {
                if (employee.Skills.Contains(skill)) {
                    quanitityOfMatchedSkills++;
                }
            }
            
            return (float)quanitityOfMatchedSkills / skills.Count;
        }
    }
}