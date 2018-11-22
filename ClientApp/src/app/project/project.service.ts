import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Project } from './project-model';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  private url = "api/project";

  constructor(private http: HttpClient) { }

  public getProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(this.url);
  }

  public getProjectById(id: number): Observable<Project> {
    return this.http.get<Project>(this.url + `/${id}`);
  }
}
