import { extname } from "path";
import { IBaseInterface } from "./BaseInterface";
import { ICustomer } from "./Customer";
import { ILineItem } from "./IInvoice";

export interface ISalesOrder extends IBaseInterface {

    customer: ICustomer;
    isPaid: boolean;
    salesOrderItems: ILineItem[];
}