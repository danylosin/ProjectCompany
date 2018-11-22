import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router";
import { AppComponent } from './app.component';
import { ProjectListComponent } from './project/project-list/project-list.component';
import { routes } from './app.routes';
import { NavBarComponent } from './layout/nav-bar/nav-bar.component';
import { HttpClientModule } from '@angular/common/http';
import { ProjectDetailComponent } from './project/project-detail/project-detail.component';
import { ContributionListComponent } from './contribution/contribution-list/contribution-list.component';

@NgModule({
  declarations: [
    AppComponent,
    ProjectListComponent,
    NavBarComponent,
    ProjectDetailComponent,
    ContributionListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot(routes)
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
