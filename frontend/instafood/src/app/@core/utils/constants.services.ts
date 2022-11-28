import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';

@Injectable()
export class ConstantService {
    getOrderApiUrl(): string {
        return "https://localhost:8011/api/order";
    }
    getMenuApiUrl(): string {
        return "https://localhost:8011/api/menu";
    }
}