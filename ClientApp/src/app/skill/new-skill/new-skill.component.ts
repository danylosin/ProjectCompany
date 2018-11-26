import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { SkillService } from '../skill.service';
import { FormBuilder, Form, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-new-skill',
  templateUrl: './new-skill.component.html',
  styleUrls: ['./new-skill.component.scss']
})
export class NewSkillComponent implements OnInit {
  form: FormGroup;
  @Output() onSubmitFormEvent = new EventEmitter<FormGroup>();

  constructor(private service: SkillService, private fb: FormBuilder) { }

  ngOnInit() {
    this.buildForm();
  }

  onSubmit() {
    this.onSubmitFormEvent.emit(this.form);
  }

  isFormControlInvalid(control): boolean {
    const currentControl = this.form.controls[control];
    return currentControl.invalid && 
        (currentControl.touched || currentControl.dirty);
  }

  getFormControlErrors(control) {
    return this.form.controls[control].errors;
  }
  
  private buildForm() {
    this.form = this.fb.group({
      title: ['', Validators.required]
    })
  }
}
