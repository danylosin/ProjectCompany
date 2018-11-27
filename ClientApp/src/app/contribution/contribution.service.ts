import { Injectable } from '@angular/core';
import { Contribution } from './contribution.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ContributionService {
  constructor(private http: HttpClient) { }

  public newContribution(contribution: Contribution, projectId: number): Observable<Contribution> {
    return this.http.post<Contribution>(`api/project/${projectId}/contribution`, contribution);
  }

  public editContribution(contribution: Contribution, selectedContributionId: number): Observable<Contribution> {
    console.log(contribution);
    return this.http.put<Contribution>(`api/contribution/${selectedContributionId}`, contribution);
  }

  public deleteContribution(contribution: Contribution) {
    return this.http.delete(`api/contribution/${contribution.id}`);
  }
}
