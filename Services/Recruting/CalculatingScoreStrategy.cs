using ProjectCompany.Models;

namespace ProjectCompany.Services.Recruting
{
    public interface CalculatingScoreStrategy
    {
        float calculateScore(Employee employee);
    }
}