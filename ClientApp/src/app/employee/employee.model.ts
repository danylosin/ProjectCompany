import { Contribution } from "../contribution/contribution.model";

export default interface Employee {
    readonly id: number;
    name: string;
    employeeSkills: any;
    skills: any;
    contributions: Contribution[]
}