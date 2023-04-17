import { IProduct } from "@/types/Product";
import { HTTP } from "./http-common";

/**
 * 
 */

export class ProductService {

    async archive(productId: number) {
        let result = await HTTP.patch(`/product/${productId}`);

        return result.data;
    }

    async saveProduct(product: IProduct) {
        let result = await HTTP.post('/product', product);
        return result.data;
    }
}