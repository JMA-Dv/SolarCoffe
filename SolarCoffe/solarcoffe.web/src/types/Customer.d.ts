import { IBaseInterface } from "./BaseInterface";

/**
 * 
 */
export interface ICustomer extends IBaseInterface {
    firstName: string;
    lastName: string;
    customerAddress: CustomerAddress
}

export interface CustomerAddress {
    id: number;
    addressLine: string;
    city: string;
    state: string;
    postalCode: string;
    country: string;
}


