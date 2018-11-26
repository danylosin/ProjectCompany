import { Component, OnInit, Input } from '@angular/core';
import { ProjectService } from '../project.service';
import { Project } from '../project.model';
import { ActivatedRoute } from '@angular/router';
import { Contribution } from 'src/app/contribution/contribution.model';
import { ContributionService } from 'src/app/contribution/contribution.service';

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
    private projectService: ProjectService,
    private contributionService: ContributionService,
    private route: ActivatedRoute
    ) { }

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.projectService.getProjectById(id).subscribe(data => {
      this.project = data,
      this.contributions = data.contributions;
      this.isLoaded = true
    });
  }

  createContribution($event) {
    this.contributionService.newContribution($event, this.project.id)
          .subscribe(data => this.contributions.push(data as Contribution));
  }

  public deleteContribution(contribution: Contribution) {
    this.contributionService.deleteContribution(contribution)
        .subscribe(() => this.contributions.splice(this.contributions.indexOf(contribution) ,1))
  }
}
