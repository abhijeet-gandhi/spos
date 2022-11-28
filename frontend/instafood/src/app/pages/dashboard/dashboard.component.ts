import { Component, OnDestroy, OnInit } from '@angular/core';
import { NbThemeService } from '@nebular/theme';
import { takeWhile } from 'rxjs/operators';
import { OrderModel } from '../order/order.model';
import { OrderService } from '../order/order.service';

interface CardSettings {
  title: string;
  iconClass: string;
  type: string;
}

@Component({
  selector: 'ngx-dashboard',
  styleUrls: ['./dashboard.component.scss'],
  templateUrl: './dashboard.component.html',
})
export class DashboardComponent implements OnDestroy, OnInit {
  orders: OrderModel[];
  private alive = true;

  qty: number = 0;
  revenue: number = 0;

  constructor(private orderService: OrderService) {
  }

  ngOnInit(): void {
    this.orderService.getOrders()
      .subscribe((data: OrderModel[]) => {
        this.orders = [];
        data.forEach(item => {
          let model = new OrderModel();
          model.user = item.user;
          model.createdDate = item.createdDate;
          model.qty = item.qty;
          model.amount = item.amount;
          this.orders.push(model);
        });
        this.qty = this.orders.length;
        this.revenue = this.orders.reduce((accumulator, current) => {
          return accumulator + current.amount;
        }, 0);
      });
  }

  ngOnDestroy() {
    this.alive = false;
  }
}
