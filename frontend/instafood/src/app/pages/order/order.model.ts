import { CartItem } from "./cart.model";

export class OrderModel {
    user: string;
    qty: number;
    amount: number;
    createdDate: Date;
    items: CartItem[];
}