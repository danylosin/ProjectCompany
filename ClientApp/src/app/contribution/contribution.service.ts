import { Injectable } from '@angular/core';
import { Contributon } from './contribution.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ContributionService {
  constructor(private http: HttpClient) { }

  public newContribution(contribution: Contributon, projectId: number) {
    return this.http.post(`api/project/${projectId}/contribution`, contribution);
  }
}
