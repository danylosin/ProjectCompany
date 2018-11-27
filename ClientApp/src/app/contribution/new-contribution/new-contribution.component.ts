import { Component, OnInit, Output, EventEmitter, Input, OnChanges } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import Employee from 'src/app/employee/employee.model';
import { Contribution } from '../contribution.model';

@Component({
  selector: 'app-new-contribution',
  templateUrl: './new-contribution.component.html',
  styleUrls: ['./new-contribution.component.scss']
})
export class NewContributionComponent implements OnInit, OnChanges {
  form: FormGroup;
  @Input() employees: Employee[];
  @Input() currentContribution: Contribution;

  @Output() onSubmitFormEvent = new EventEmitter<FormGroup>();

  constructor(private fb: FormBuilder) { }

  ngOnInit() {
    this.buildForm();
  }
  
  ngOnChanges() {
    this.buildForm();
  }

  onSubmit() {
    this.onSubmitFormEvent.emit(this.form.value);
  }

  private buildForm() {
    let datePeriodFrom = this.currentContribution.datePeriod.from;
    let datePeriodTo = this.currentContribution.datePeriod.to;

    if (datePeriodFrom || datePeriodTo) {
      datePeriodFrom = datePeriodFrom.split('T')[0];
      datePeriodTo = datePeriodTo.split('T')[0];
    }

    this.form = this.fb.group({
      title: [this.currentContribution.title, Validators.required],
      datePeriod: this.fb.group({
          from: [datePeriodFrom, Validators.required],
          to: [datePeriodTo, Validators.required]
        }),
      employeeId: [this.currentContribution.employeeId, Validators.required]
    })
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
}
