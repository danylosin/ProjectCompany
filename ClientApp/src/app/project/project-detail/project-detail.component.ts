import { Component, OnInit, Input } from '@angular/core';
import { ProjectService } from '../project.service';
import { Project } from '../project.model';
import { ActivatedRoute } from '@angular/router';
import { Contribution } from 'src/app/contribution/contribution.model';
import { ContributionService } from 'src/app/contribution/contribution.service';
import Employee from 'src/app/employee/employee.model';
import { EmployeeService } from 'src/app/employee/employee.service';

@Component({
  selector: 'app-project-detail',
  templateUrl: './project-detail.component.html',
  styleUrls: ['./project-detail.component.scss']
})
export class ProjectDetailComponent implements OnInit {
  public isLoaded = false;
  
  public project: Project;
  public contributions: Contribution[];
  public employeesForForm: Employee[];
  public editingContribution: Contribution;

  constructor(
    private projectService: ProjectService,
    private contributionService: ContributionService,
    private employeeService: EmployeeService,
    private route: ActivatedRoute
    ) { 
      this.editingContribution = {
        title: null,
        datePeriod: {
          from: null,
          to: null,
        },
        employeeId: 0
      };
    }

  ngOnInit() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.projectService.getProjectById(id).subscribe(data => {
      this.project = data,
      this.contributions = data.contributions;
      this.isLoaded = true
    });

    this.employeeService.getEmployees().subscribe(data => {
      this.employeesForForm = data as Employee[]
    })
  }

  public createContribution($event) {
    if (this.editingContribution.title !== null) {
      this.contributionService.editContribution($event, this.editingContribution.id)
          .subscribe(data => this.contributions.splice(this.contributions.indexOf($event), 1, data as Contribution))
    } else {
      this.contributionService.newContribution($event, this.project.id)
          .subscribe(data => this.contributions.push(data as Contribution));
    }
  }

  public editContribution($event) {
    this.editingContribution = $event;
  }

  public deleteContribution(contribution: Contribution) {
    this.contributionService.deleteContribution(contribution)
        .subscribe(() => this.contributions.splice(this.contributions.indexOf(contribution), 1))
  }
}
