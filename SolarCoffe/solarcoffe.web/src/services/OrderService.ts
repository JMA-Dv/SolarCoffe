import { ISalesOrder } from "@/types/SalesOrder";
import { IServiceResponse } from "@/types/ServiceResponse";
import { HTTP } from "./http-common";


/**
 * Order service
 * Provides HTTP services for the Order entity related
 * 
 */
export class OrderService {
    public async GetOrders(): Promise<ISalesOrder[]> {
        let response = await HTTP.get("/order");
        return response.data;
    }

    /**
     * 
     * @param id - The id from the order to mark as completed 
     * @returns The response of the completed operation
     */
    public async MarkAsCompleted(id: number): Promise<IServiceResponse<boolean>> {
        let response = await HTTP.patch(`/order/${id}`);
        return response.data;
    }
}