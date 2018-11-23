import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ContributionService } from '../contribution.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-new-contribution',
  templateUrl: './new-contribution.component.html',
  styleUrls: ['./new-contribution.component.scss']
})
export class NewContributionComponent implements OnInit {
  form: FormGroup;
  constructor(private fb: FormBuilder,
              private service: ContributionService,
              private route: ActivatedRoute) { }

  ngOnInit() {
    this.buildForm();
  }

  onSubmit() {
    const projectId = +this.route.snapshot.paramMap.get('id');
    this.service.newContribution(this.form.value, projectId).subscribe(data => console.log(data));
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
