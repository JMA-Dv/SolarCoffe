export interface IInventoryTimeline {
    productInventorySnapshots: ISnaphot[];
    timeline: Date[];
}

export interface ISnaphot {
    productId: number;
    quantityOnHand: number[]
}