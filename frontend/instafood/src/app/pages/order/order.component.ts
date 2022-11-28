import { Component, OnInit } from '@angular/core';
import { NbMenuService, NbThemeService } from '@nebular/theme';
import { ToastService } from '../../@core/helpers/toast.service';
import { MenuModel } from '../menu/menu.model';
import { CartItem, CartModel } from './cart.model';
import { OrderService } from './order.service';

@Component({
  selector: 'ngx-order',
  templateUrl: './order.component.html',
  styleUrls: ['./order.component.scss']
})
export class OrderComponent implements OnInit {
  order: CartModel;
  finalOrder: CartModel;
  totalQty: number;
  total: number = 1;
  stepperIndex: number;
  tip: number = 0;
  theme: any;
  loading = false;
  constructor(private orderService: OrderService,
    private toastService: ToastService,
    private themeService: NbThemeService,
    private router: NbMenuService) {
    this.themeService.getJsTheme()
      .subscribe(config => {
        this.theme = config.variables.temperature;
      });
    this.onReset();
  }

  onReset() {
    this.order = new CartModel();
    this.finalOrder = new CartModel();
    this.stepperIndex = 0;
  }

  ngOnInit(): void {
    this.orderService.getMenu()
      .subscribe((data: MenuModel[]) => {
        this.order.items = [];
        data.forEach(item => {
          let model = new CartItem();
          model.name = item.name;
          model.price = item.price;
          model.qty = 0;
          model.tax = item.tax;
          model.picturePath = item.picturePath;
          this.order.items.push(model);
        });
      });
  }

  onAddItem(item: CartItem) {
    this.order.addItem(item);
    this.totalQty = this.order.totalQty;
    this.total = this.order.totalPrice;
    this.toastService.showSuccess('Added item to cart', `${item.name} is added to the cart`);
  }

  reduceQty(item: CartItem) {
    this.order.removeItem(item);
    this.totalQty = this.order.totalQty;
    this.total = this.order.totalPrice;
    this.toastService.showError('Removed item from cart', `Removed item - ${item.name} from cart`);
  }

  onOrderSubmit() {
    if (this.order.totalQty < 1) return;
    this.stepperIndex = 1;
    this.populareFinalOrder();
  }

  filterOrders(item: CartItem): any {
    return item.qty > 0;
  }

  populareFinalOrder() {
    this.finalOrder.items = new Array();
    this.order.items.forEach(i => {
      this.finalOrder.addItem(i);
    })
  }
  onConfirmSubmit() {
    if (this.order.totalQty >= 1)
      this.stepperIndex = 2;
  }

  backOnConfirm() {
    this.stepperIndex = 0;
  }

  backOnCheckout() {
    this.stepperIndex = 2;
  }

  onCheckoutSubmit() {
    this.stepperIndex = 3;
  }

  onTipChange() {
    this.finalOrder.addTipValue(this.tip);
  }

  backOnPayment() {
    this.stepperIndex = 3;
  }

  onPaymentSubmit() {
    this.loading = true;
    setTimeout(() => {
      this.loading = false;
      const value = Math.round((this.finalOrder.totalWithTip + Number.EPSILON) * 100) / 100;
      console.log(JSON.stringify(this.finalOrder.getOrderModel()))
      this.orderService.placeNewOrder(this.finalOrder.getOrderModel()).subscribe(
        success => {
          this.toastService.showSuccess('Payment Success', `Payment of $${value} processed successfully`);
          this.router.navigateHome();
        },
        error => {
          this.toastService.showError('Payment failed', 'Failed to process the payment, error - ' + error.message);
        });
    }, 1000);
  }

  addTipClicked(tipInPerc: number) {
    this.finalOrder.addTipInPerc(tipInPerc);
    this.tip = this.finalOrder.tip;
  }
}
