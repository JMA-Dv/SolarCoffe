import axios from 'axios';

/**
 * Inventory Service
 * Provides UI Buisness login associated with product inventory
 */
export class InventoryService {
    API_URL = process.env.VUE_APP_API_URL;

    public async GetInventory(): Promise<any> {
        let result: any = await axios.get(`${this.API_URL}/inventory`);
        console.log("🚀 ~ file: InventoryService..ts:13 ~ InventoryService ~ GetInventory ~ result:", result)
        return result.data;
    }
}