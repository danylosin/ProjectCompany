import { Contributon } from "../contribution/contribution.model";

export default interface Employee {
    readonly id: number;
    name: string;
    employeeSkills: any;
    contributions: Contributon[]
}