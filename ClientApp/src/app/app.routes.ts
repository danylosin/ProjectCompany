import { Routes } from "@angular/router";
import { ProjectListComponent } from "./project/project-list/project-list.component";
import { ProjectDetailComponent } from "./project/project-detail/project-detail.component";
import { NewProjectComponent } from "./project/new-project/new-project.component";
import { ContributionListComponent } from "./contribution/contribution-list/contribution-list.component";
import { NewContributionComponent } from "./contribution/new-contribution/new-contribution.component";
import { EmployeeListComponent } from "./employee/employee-list/employee-list.component";
import { EmployeeDetailComponent } from "./employee/employee-detail/employee-detail.component";
import { NewEmployeeComponent } from "./employee/new-employee/new-employee.component";
import { SkillListComponent } from "./skill/skill-list/skill-list.component";

export const routes: Routes = [
    { path: '', component: ProjectListComponent },
    { path: 'project/new', component: NewProjectComponent, pathMatch: 'full' },
    { path: 'project/:id/contribution/add', component: NewContributionComponent, pathMatch: 'full' },
    { path: 'project/:id/contribution', component: ContributionListComponent, pathMatch: 'full' },
    { path: 'project/:id', component: ProjectDetailComponent },
    { path: 'employee', component: EmployeeListComponent, pathMatch: 'full' },
    { path: 'employee/add', component: NewEmployeeComponent, pathMatch: 'full' },
    { path: 'employee/:id', component: EmployeeDetailComponent },
    { path: 'skill', component: SkillListComponent, pathMatch: 'full'}
  ];
