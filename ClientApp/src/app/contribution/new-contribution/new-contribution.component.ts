import { Component, OnInit, Output, EventEmitter, Input } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
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
  @Input() errors
  @Output() onSubmitFormEvent = new EventEmitter<FormGroup>();

  constructor(private fb: FormBuilder,
              private service: EmployeeService
              ) { }

  ngOnInit() {
    this.buildForm();
    this.service.getEmployees().subscribe(data => this.employees = data as Employee[]);
  }

  onSubmit() {
    this.onSubmitFormEvent.emit(this.form.value);
  }

  get title() {
    return this.form.get('title');
  }

  get fromDate() {
    return this.form.get('datePeriod').get('from');
  }

  get toDate() {
    return this.form.get('datePeriod').get('to');
  }

  get employeeId() {
    return this.form.get('employeeId');
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
