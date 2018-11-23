import { DatePeriod } from "../app-date-period.model";
import { Contribution } from "../contribution/contribution.model";

export interface Project {
    readonly id?: number;
    title: string;
    readonly contributions?: Contribution[];
    datePeriod: DatePeriod;
}
