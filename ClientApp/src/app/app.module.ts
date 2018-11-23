import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from "@angular/router";
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { routes } from './app.routes';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { ProjectListComponent } from './project/project-list/project-list.component';
import { NavBarComponent } from './layout/nav-bar/nav-bar.component';
import { ProjectDetailComponent } from './project/project-detail/project-detail.component';
import { ContributionListComponent } from './contribution/contribution-list/contribution-list.component';
import { NewProjectComponent } from './project/new-project/new-project.component';
import { NewContributionComponent } from './contribution/new-contribution/new-contribution.component';
import { EmployeeListComponent } from './employee/employee-list/employee-list.component';

@NgModule({
  declarations: [
    AppComponent,
    ProjectListComponent,
    NavBarComponent,
    ProjectDetailComponent,
    ContributionListComponent,
    NewProjectComponent,
    NewContributionComponent,
    EmployeeListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(routes),
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
