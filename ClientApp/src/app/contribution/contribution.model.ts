import { DatePeriod } from "../app-date-period.model";

export interface Contributon {
    readonly id?: number;
    title: string;
    employee: any;
    datePeriod: DatePeriod;
}
