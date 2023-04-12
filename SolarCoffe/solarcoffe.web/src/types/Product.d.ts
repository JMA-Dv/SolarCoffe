export interface IProduct {
    id: number;
    dateCreated: Date;
    dateUpdated: Date;
    name: string;
    description: string;
    price: number;
    isTaxable: boolean;
    isArchived: boolean;
}
export interface IProductInventory {
    id: number;
    product: IProduct;
    quantityOnHand: number;
    idealQuantity: number;

}