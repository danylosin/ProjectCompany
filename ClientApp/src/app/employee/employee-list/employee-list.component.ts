import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import Employee from '../employee.model';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {
  public employees: Employee[];
  public selectedEmployee: Employee;

  constructor(private employeeService: EmployeeService) { }

  ngOnInit() {
    this.onGetEmployees();
  }

  onGetEmployees() {
    this.employeeService.getEmployees().subscribe(data => this.employees = data as Employee[]);
  }

  onSelectEmployee(employee: Employee) {
    this.selectedEmployee = employee;
  }
}
