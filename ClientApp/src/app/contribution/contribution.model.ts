import { DatePeriod } from "../app-date-period.model";
import { Project } from "../project/project.model";
import Employee from "../employee/employee.model";

export interface Contribution {
    readonly id?: number;
    title: string;
    datePeriod: DatePeriod;
    readonly project?: Project;
    readonly projectId?: number;
    readonly employee?: any;
    employeeId: number;
}
