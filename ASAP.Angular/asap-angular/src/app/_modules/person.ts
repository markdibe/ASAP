import { Address } from "./address";

export interface Person{
    id:number;
    firstName:string;
    lastName:string;
    dateOfBirth:Date;
    biography:string;
    addresses:Address[];
    imageUrl:string;
    file:File;
}

