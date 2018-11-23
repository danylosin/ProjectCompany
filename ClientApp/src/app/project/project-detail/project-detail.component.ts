import { Component, OnInit, Input } from '@angular/core';
import { ProjectService } from '../project.service';
import { Project } from '../project.model';
import { ActivatedRoute } from '@angular/router';
import { Contribution } from 'src/app/contribution/contribution.model';

@Component({
  selector: 'app-project-detail',
  templateUrl: './project-detail.component.html',
  styleUrls: ['./project-detail.component.scss']
})
export class ProjectDetailComponent implements OnInit {
  public isLoaded = false;
  public project: Project;
  public contributions: Contribution[];
  constructor(
    private service: ProjectService,
    private route: ActivatedRoute
    ) { }

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.service.getProjectById(id).subscribe(data => {
      this.project = data,
      this.contributions = data.contributions;
      this.isLoaded = true
    });
  }
}
