import { Component, OnInit } from '@angular/core';
import { Project } from '../project.model';
import { ProjectService } from '../project.service';

@Component({
  selector: 'app-new-project',
  templateUrl: './new-project.component.html',
  styleUrls: ['./new-project.component.scss']
})
export class NewProjectComponent implements OnInit {
  project: Project = {
    title: '',
    datePeriod: {
      from: new Date(),
      to: new Date()
    },
  };

  constructor(private service: ProjectService) { }

  ngOnInit() {
  }

  onSubmit(form) {
    this.service.newProject(form.value).subscribe(data => console.log(data));
  }

}
