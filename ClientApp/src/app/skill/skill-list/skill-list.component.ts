import { Component, OnInit } from '@angular/core';
import { Skill } from '../skill-model';
import { SkillService } from '../skill.service';

@Component({
  selector: 'app-skill-list',
  templateUrl: './skill-list.component.html',
  styleUrls: ['./skill-list.component.scss']
})
export class SkillListComponent implements OnInit {
  skills: Skill[];

  constructor(private service: SkillService) { }

  ngOnInit() {
    this.onGetSkills()
  }

  onGetSkills() {
    this.service.getSkills().subscribe(data => this.skills = data as Skill[]);
  }

  onCreateSkill($event) {
    this.service.createSkill($event.value)
          .subscribe(data => this.skills.push(data as Skill));
  }

  onDeleteSkill(skill: Skill) {
    this.service.deleteSkill(skill)
          .subscribe(data => this.skills.splice(this.skills.indexOf(skill) ,1));
  }
}
