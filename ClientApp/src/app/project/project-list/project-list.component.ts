import { Component, OnInit } from '@angular/core';
import { ProjectService } from '../project.service';
import { Project } from '../project.model';

@Component({
  selector: 'app-project-list',
  templateUrl: './project-list.component.html',
  styleUrls: ['./project-list.component.scss']
})
export class ProjectListComponent implements OnInit {
  public projects: Project[];

  constructor(private service: ProjectService) { }

  ngOnInit() {
    this.service.getProjects().subscribe((data: []) => this.projects = data)
  }

}
