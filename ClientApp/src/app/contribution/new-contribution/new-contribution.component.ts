import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ContributionService } from '../contribution.service';
import { ActivatedRoute } from '@angular/router';
import { Contribution } from '../contribution.model';

@Component({
  selector: 'app-new-contribution',
  templateUrl: './new-contribution.component.html',
  styleUrls: ['./new-contribution.component.scss']
})
export class NewContributionComponent implements OnInit {
  form: FormGroup;
  @Output() newContributionEvent = new EventEmitter<Contribution>();
  @Output() onSubmitFormEvent = new EventEmitter<FormGroup>();

  constructor(private fb: FormBuilder,
              private service: ContributionService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.buildForm();
  }

  onSubmit() {
    this.onSubmitFormEvent.emit(this.form);
    //const projectId = +this.route.snapshot.paramMap.get('id');
    //this.service.newContribution(this.form.value, projectId)
      //    .subscribe(data => this.newContributionEvent.emit(data as Contribution));
  }

  private buildForm() {
    this.form = this.fb.group({
      title: ['', Validators.required],
      datePeriod: this.fb.group({
          from: '',
          to: ''
        })
    })
  }
}
