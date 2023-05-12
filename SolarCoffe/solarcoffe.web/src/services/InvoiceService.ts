import { IInvoice } from "@/types/IInvoice";
import { HTTP } from "./http-common";


/**
 * Invoice service 
 */
export default class InvoiceService {
    async makeNewInvoice(invoice: IInvoice): Promise<boolean> {
        let now = new Date();
        invoice.dateCreated = now;
        invoice.dateUpdated = now;
        let result = await HTTP.post('/order/invoice', invoice);
        return result.data;
    }
}