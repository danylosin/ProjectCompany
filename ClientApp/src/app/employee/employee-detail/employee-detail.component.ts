import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { ActivatedRoute } from '@angular/router';
import Employee from '../employee.model';

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.scss']
})
export class EmployeeDetailComponent implements OnInit {
  public employee: Employee;

  constructor(private service: EmployeeService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.onGetEmployee();
  }

  onGetEmployee() {
    const id = +this.route.snapshot.paramMap.get('id');
    this.service.getEmployeeById(id).subscribe(data => this.employee = data as Employee);
  }
}
