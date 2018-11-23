import { Component, OnInit, Input } from '@angular/core';
import { ProjectService } from 'src/app/project/project.service';
import { ActivatedRoute } from '@angular/router';
import { Project } from 'src/app/project/project.model';
import { Contribution } from '../contribution.model';

@Component({
  selector: 'app-contribution-list',
  templateUrl: './contribution-list.component.html',
  styleUrls: ['./contribution-list.component.scss']
})
export class ContributionListComponent implements OnInit {
  public isLoaded = false;
  project: Project;
  contributions: Contribution[];
  @Input() newConribution: Contribution;

  constructor(
    private service: ProjectService,
    private route: ActivatedRoute
    ) { }

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.service.getProjectById(id).subscribe(data => { 
      this.project = data;
      this.contributions = data.contributions; 
      this.isLoaded = true;
    });
  }

  @Input() onNewContribution(newContribution: Contribution) {
    this.contributions.push(newContribution);
  }

}
