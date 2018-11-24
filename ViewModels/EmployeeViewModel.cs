using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using ProjectCompany.Models;
using System.Linq;
using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectCompany.ViewModels
{
    public class EmployeeViewModel 
    {
        [Required(ErrorMessage = "Pls")]
        public string Name {get; set; }
        public List<Skill> Skills { get; set;}
        
        public EmployeeViewModel(){}
    }
}
