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
        public List<string> SelectedSkills { get; set; }
        [Required(ErrorMessage = "Pls")]
        public string Name {get; set; }
        public List<SelectListItem> Skills { get; set;}
        
        public EmployeeViewModel(){}
        public EmployeeViewModel(List<Skill> skills)
        {
            this.Skills = skills.Select(this.GetSelectListItem).ToList();
        }

        private SelectListItem GetSelectListItem(Skill skill)
        {
            return new SelectListItem() { Value = skill.Id.ToString(), Text = skill.Title };
        }
    }
}
