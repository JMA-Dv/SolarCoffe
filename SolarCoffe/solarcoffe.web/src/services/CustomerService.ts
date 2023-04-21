import { ICustomer } from "@/types/Customer";
import { IServiceResponse } from "@/types/ServiceResponse";
import { HTTP } from "./http-common";

/**
 * Provides UI endpoints to hit to backend api
 */

export class CustomerService {

    async saveCustomer(customer: ICustomer): Promise<IServiceResponse<ICustomer>> {
        let result: IServiceResponse<ICustomer> = await HTTP.post('/customer/', customer);
        return result;
    }

    async GetCustomers(): Promise<ICustomer[]> {
        let result = await HTTP.get('/customer');
        return result.data;
    }


    async deleteCustomer(customerId: number): Promise<boolean> {
        let result: Promise<boolean> = HTTP.delete(`customer/${customerId}`);
        return result;
    }

}