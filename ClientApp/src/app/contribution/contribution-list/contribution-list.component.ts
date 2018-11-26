import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { Contribution } from '../contribution.model';
import { ContributionService } from '../contribution.service';
@Component({
  selector: 'app-contribution-list',
  templateUrl: './contribution-list.component.html',
  styleUrls: ['./contribution-list.component.scss'],
  inputs: ['contributions']
})

export class ContributionListComponent implements OnInit {
  contributions: Contribution[];
  @Output() onDeleteContributionEvent = new EventEmitter<Contribution>();

  constructor(private service: ContributionService) { }

  ngOnInit() {
  }

  public onDeleteContribution(contribution: Contribution) {
    this.onDeleteContributionEvent.emit(contribution);
  }
}
