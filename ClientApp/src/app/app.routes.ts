import { Routes } from "@angular/router";
import { ProjectListComponent } from "./project/project-list/project-list.component";
import { ProjectDetailComponent } from "./project/project-detail/project-detail.component";
import { NewProjectComponent } from "./project/new-project/new-project.component";

export const routes: Routes = [
    { path: '', component: ProjectListComponent },
    { path: 'project/new', component: NewProjectComponent, pathMatch: 'full' },
    { path: 'project/:id', component: ProjectDetailComponent }
  ];
