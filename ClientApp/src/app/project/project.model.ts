import { DatePeriod } from "../app-date-period.model";

export interface Project {
    readonly id?: number;
    title: string;
    readonly contributions?: [];
    datePeriod: DatePeriod;
}
