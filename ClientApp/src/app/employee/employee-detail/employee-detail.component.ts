import { Component, OnInit, Input } from '@angular/core';
import { EmployeeService } from '../employee.service';
import { ActivatedRoute } from '@angular/router';
import Employee from '../employee.model';

@Component({
  selector: 'app-employee-detail',
  templateUrl: './employee-detail.component.html',
  styleUrls: ['./employee-detail.component.scss']
})
export class EmployeeDetailComponent implements OnInit {
  @Input() employee: Employee;

  constructor(private service: EmployeeService, private route: ActivatedRoute) { }

  ngOnInit() {
  }
}
