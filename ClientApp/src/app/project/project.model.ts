import { DatePeriod } from "../app-date-period.model";
import { Contributon } from "../contribution/contribution.model";

export interface Project {
    readonly id?: number;
    title: string;
    readonly contributions?: Contributon[];
    datePeriod: DatePeriod;
}
