import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ConstantService } from '../../@core/utils/constants.services';
import { OrderModel } from './order.model';
import { MenuModel } from '../menu/menu.model';


@Injectable()
export class OrderService {
    constructor(private http: HttpClient,
        private constants: ConstantService) {

    }

    getMenu(): Observable<MenuModel[]> {
        return this.http.get<MenuModel[]>(this.constants.getMenuApiUrl());
    }

    getOrders(): Observable<OrderModel[]> {
        return this.http.get<OrderModel[]>(this.constants.getOrderApiUrl());
    }

    placeNewOrder(item: OrderModel): Observable<OrderModel> {
        const headers = { 'Content-Type': 'application/json' };
        return this.http.post<OrderModel>(this.constants.getOrderApiUrl(), item, { headers: headers });
    }

    catchError(error): Observable<Response> {
        if (error && error.error && error.error.message) {
            alert(error.error.message);
        }
        else if (error && error.message) {
            alert(error.message);
        } else {
            alert(JSON.stringify(error));
        }
        return throwError(error);

    }
}