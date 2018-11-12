using ProjectCompany.Person;

namespace ProjectCompany
{
    public interface CalculatingScoreStrategy
    {
        float calculateScore(Employee employee);
    }
}