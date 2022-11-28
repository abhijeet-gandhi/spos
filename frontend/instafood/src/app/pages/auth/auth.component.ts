import { Location } from '@angular/common';
import { Component, OnDestroy } from '@angular/core';
import { Subject } from 'rxjs';
import { AuthService } from './services/auth.service';

@Component({
    selector: 'ngx-auth',
    template: `
<nb-layout>
      <nb-layout-column>
        <nb-card>
          <nb-card-header>
            <nav class="navigation">
              <a href="#" (click)="back()" class="link back-link" aria-label="Back">
                <nb-icon icon="arrow-back"></nb-icon>
              </a>
            </nav>
          </nb-card-header>
          <nb-card-body>
              <router-outlet></router-outlet>
          </nb-card-body>
        </nb-card>
      </nb-layout-column>
    </nb-layout>    `,
})
export class AuthComponent implements OnDestroy {
    private destroy$ = new Subject<void>();

    subscription: any;
    authenticated: boolean = false;
    token: string = '';

    contructor() {
    }

    back() {
        return false;
    }

    ngOnDestroy(): void {
        this.destroy$.next();
        this.destroy$.complete();
    }
}