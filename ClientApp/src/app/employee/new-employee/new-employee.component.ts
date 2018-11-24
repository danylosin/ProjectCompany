import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { SkillService } from 'src/app/skill/skill.service';
import { EmployeeService } from '../employee.service';
import { Skill } from 'src/app/skill/skill-model';

@Component({
  selector: 'app-new-employee',
  templateUrl: './new-employee.component.html',
  styleUrls: ['./new-employee.component.scss']
})
export class NewEmployeeComponent implements OnInit {
  form: FormGroup
  skills: Skill[]

  constructor(private fb: FormBuilder, 
              private skillService: SkillService,
              private employeeService: EmployeeService ) { }

  ngOnInit() {
    this.skillService.getSkills().subscribe(data => this.skills = data as Skill[]);
    this.buildForm();
  }

  private buildForm() {
    this.form = this.fb.group({
      name: ['', Validators.required],
      skills: ''
    })
  }

  onSubmit() {
    console.log(this.form.value);
    this.employeeService.addEmployee(this.form).subscribe();
  }
}
