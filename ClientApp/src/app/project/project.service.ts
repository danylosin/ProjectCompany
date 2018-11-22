import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  private url = "api/project";

  constructor(private http: HttpClient) { }

  public getProjects() {
    return this.http.get(this.url);
  }
}
