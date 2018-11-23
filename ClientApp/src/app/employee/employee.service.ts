import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private url = 'api/employee';

  constructor(private http: HttpClient) { }

  getEmployees() {
    return this.http.get(this.url);
  }
}
