import { MenuModel } from "../menu/menu.model";
import { OrderModel } from "./order.model";

export class CartModel {
    constructor() {
        this.totalPrice = 0;
        this.totalQty = 0;
        this.totalWithTax = 1;
        this.totalTax = 0;
        this.items = new Array();
        this.tip = 0;
    }
    items: CartItem[];
    totalQty: number;
    totalPrice: number;
    totalWithTax: number = 1;
    totalTax: number;
    tip: number;
    totalWithTip: number;

    addItem(item: CartItem) {
        const index = this.items.findIndex(x => x.name == item.name);
        if (index === -1)
            this.items.push(item);
        else
            this.items[index].qty += 1;
        this.recalculateOrder();
    }

    removeItem(item: CartItem) {
        const index = this.items.findIndex(x => x.name == item.name);
        if (index === -1)
            return;
        if (this.items[index].qty <= 1)
            this.items[index].qty = 0;
        else
            this.items[index].qty -= 1;
        this.recalculateOrder();
    }

    recalculateOrder() {
        this.totalPrice = this.items.reduce((accumulator, item) => {
            return accumulator + (item.price * item.qty);
        }, 0)
        this.totalQty = this.items.reduce((accumulator, item) => {
            return accumulator + item.qty;
        }, 0)
        this.totalTax = this.items.reduce((accumulator, item) => {
            return accumulator + ((item.price * item.qty) * item.tax) / 100;
        }, 0)
        this.totalWithTax = this.totalPrice + this.totalTax;
        this.totalWithTip = this.totalWithTax + this.tip;
    }

    addTipInPerc(tipInPerc: number) {
        this.tip = this.totalWithTax * tipInPerc / 100;
        this.recalculateOrder();

    }
    addTipValue(tip: number) {
        this.tip = tip;
        this.recalculateOrder();
    }

    getOrderModel(): OrderModel {
        let model = new OrderModel();
        model.amount = this.totalWithTip;
        model.items = this.items;
        model.qty = this.totalQty;
        return model;
    }
}

export class CartItem extends MenuModel {
    constructor() {
        super();
    }
    qty: number;
}
