using System.Collections.Generic;

namespace ProjectCompany.Models.DTO
{
    public class EmployeeDetailDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Skill> Skills { get; set; }
        public List<Contribution> Contributions { get; set; }

        public EmployeeDetailDTO(){}
    }
}
