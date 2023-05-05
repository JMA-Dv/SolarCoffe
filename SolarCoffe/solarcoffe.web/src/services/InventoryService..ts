import { IProductInventory } from '@/types/Product';
import { IShipment } from '@/types/Shipment';
import { HTTP } from './http-common';
/**
 * Inventory Service
 * Provides UI Buisness login associated with product inventory
 */
export class InventoryService {
    // API_URL = process.env.VUE_APP_API_URL;

    public async GetInventory(): Promise<IProductInventory[]> {
        let result = await HTTP.get(`/inventory`);
        return result.data;
    }

    public async UpdateInventoryQuantity(Shipment: IShipment): Promise<IShipment> {
        let result = await HTTP.patch('/inventory', Shipment);
        return result.data;
    }



}