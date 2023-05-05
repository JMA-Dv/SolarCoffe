import { IBaseInterface } from "./BaseInterface";
import { IProduct } from "./Product";

export interface IInvoice extends IBaseInterface {
    customerId: number
    lineItems: ILineItem[];
}

export interface ILineItem {
    quantity: number;
    product: IProduct
}
