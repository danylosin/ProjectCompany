import { DatePeriod } from "../app-date-period.model";
import { Project } from "../project/project.model";

export interface Contributon {
    readonly id?: number;
    title: string;
    employee: any;
    datePeriod: DatePeriod;
    projectId?: number;
    project?: Project;
}
