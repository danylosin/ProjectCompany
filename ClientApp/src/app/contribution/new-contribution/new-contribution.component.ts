import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ContributionService } from '../contribution.service';
import { ActivatedRoute } from '@angular/router';
import { Contribution } from '../contribution.model';
import { SkillService } from 'src/app/skill/skill.service';
import { Skill } from 'src/app/skill/skill-model';
import Employee from 'src/app/employee/employee.model';
import { EmployeeService } from 'src/app/employee/employee.service';

@Component({
  selector: 'app-new-contribution',
  templateUrl: './new-contribution.component.html',
  styleUrls: ['./new-contribution.component.scss']
})
export class NewContributionComponent implements OnInit {
  form: FormGroup;
  employees: Employee[];

  @Output() newContributionEvent = new EventEmitter<Contribution>();
  @Output() onSubmitFormEvent = new EventEmitter<FormGroup>();

  constructor(private fb: FormBuilder,
              private service: EmployeeService
              ) { }

  ngOnInit() {
    this.buildForm();
    this.service.getEmployees().subscribe(data => this.employees = data as Employee[]);
  }

  onSubmit() {
    console.log(this.form.value);
    this.onSubmitFormEvent.emit(this.form);;
  }

  private buildForm() {
    this.form = this.fb.group({
      title: ['', Validators.required],
      datePeriod: this.fb.group({
          from: '',
          to: ''
        }),
      employeeId: ''
    })
  }
}
