import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class SkillService {
  private url = 'api/skill';
  
  constructor(private http: HttpClient) { }

  public getSkills() {
    return this.http.get(this.url);
  }
}
