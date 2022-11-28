import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { ConstantService } from '../../@core/utils/constants.services';
import { MenuModel } from './menu.model';

@Injectable()
export class MenuService {
    constructor(private http: HttpClient,
        private constants: ConstantService) {

    }
    getOrders(): Observable<MenuModel[]> {
        return this.http.get<MenuModel[]>(this.constants.getMenuApiUrl());
    }

    newMenuItem(menuItem: MenuModel): Observable<any> {
        return this.http.post<any>(this.constants.getMenuApiUrl(), menuItem)
    }
}