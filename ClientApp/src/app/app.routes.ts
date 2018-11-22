import { Routes } from "@angular/router";
import { ProjectListComponent } from "./project/project-list/project-list.component";
import { ProjectDetailComponent } from "./project/project-detail/project-detail.component";

export const routes: Routes = [
    { path: '', component: ProjectListComponent },
    { path: 'project/:id', component: ProjectDetailComponent }
  ];
