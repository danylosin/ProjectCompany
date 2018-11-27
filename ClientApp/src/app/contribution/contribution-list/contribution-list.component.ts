import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Contribution } from '../contribution.model';

@Component({
  selector: 'app-contribution-list',
  templateUrl: './contribution-list.component.html',
  styleUrls: ['./contribution-list.component.scss']
})

export class ContributionListComponent implements OnInit {
  @Input() contributions: Contribution[];

  @Output() onDeleteContributionEvent = new EventEmitter<Contribution>();
  @Output() onEditContributionEvent = new EventEmitter<Contribution>();

  constructor() { }

  ngOnInit() {
  }

  public onEditContribution(contribution: Contribution) {
    this.onEditContributionEvent.emit(contribution);
  }

  public onDeleteContribution(contribution: Contribution) {
    this.onDeleteContributionEvent.emit(contribution);
  }
}
