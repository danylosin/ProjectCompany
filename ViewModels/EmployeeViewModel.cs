using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using ProjectCompany.Models;
using System.Linq;
using System;

namespace ProjectCompany.ViewModels
{
    public class EmployeeViewModel
    {
        public string Skill { get; set; }
        public string Name {get; set; }
        public List<SelectListItem> Skills { get; private set;}
        
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
