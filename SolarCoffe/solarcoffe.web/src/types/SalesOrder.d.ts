import { extname } from "path";
import { ICustomer } from "./Customer";
import { ILineItem } from "./IInvoice";

export interface ISalesOrder extends IBaseInterface {

    customer: ICustomer;
    isPaid: boolean;
    salesorderItems: ILineItem[];
}