import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormGroup } from '@angular/forms';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
  private url = 'api/employee';
  constructor(private http: HttpClient) { }

  getEmployees() {
    return this.http.get(this.url);
  }

  getEmployeeById(id: number) {
    return this.http.get(`${this.url}/${id}`);
  }

  addEmployee(form: FormGroup) {
    return this.http.post(this.url, form.value, { observe: 'response' });
  }
}
