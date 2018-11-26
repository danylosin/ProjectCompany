import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Skill } from './skill-model';

@Injectable({
  providedIn: 'root'
})
export class SkillService {
  private url = 'api/skill';
  
  constructor(private http: HttpClient) { }

  public getSkills() {
    return this.http.get(this.url);
  }

  public createSkill(skill: Skill) {
    return this.http.post(this.url, skill);
  }
}
