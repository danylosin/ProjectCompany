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
    console.log(this.form.controls.datePeriod["controls"]);
    this.service.getEmployees().subscribe(data => this.employees = data as Employee[]);
  }

  onSubmit() {
    this.onSubmitFormEvent.emit(this.form);;
  }

  isFormControlInvalid(control): boolean {
    const currentControl = this.form.controls[control];
    return currentControl.invalid && 
        (currentControl.touched || currentControl.dirty);
  }

  getFormControlErrors(control) {
    return this.form.controls[control].errors;
  }

  isDateControlInvalid(control): boolean {
    const currentControl = this.form.controls.datePeriod["controls"][control];
    return currentControl.invalid && 
        (currentControl.touched || currentControl.dirty)
  }

  getDateControlErrors(control) {
    return this.form.controls.datePeriod["controls"][control]["errors"];
  }

  private buildForm() {
    this.form = this.fb.group({
      title: ['', Validators.required],
      datePeriod: this.fb.group({
          from: ['', Validators.required],
          to: ['', Validators.required]
        }),
      employeeId: ['', Validators.required]
    })
  }
}
