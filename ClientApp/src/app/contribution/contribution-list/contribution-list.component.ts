import { Component, OnInit, Input } from '@angular/core';
import { Contribution } from '../contribution.model';

@Component({
  selector: 'app-contribution-list',
  templateUrl: './contribution-list.component.html',
  styleUrls: ['./contribution-list.component.scss']
})
export class ContributionListComponent implements OnInit {
  @Input() contributions: Contribution[];

  constructor() { }

  ngOnInit() {
  }

}
