import { Component, OnInit, Input, OnChanges, SimpleChanges } from '@angular/core';
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
  @Input() contributions: Contribution[];

  constructor() { }

  ngOnInit() {
  }

}
