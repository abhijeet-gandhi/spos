import { NgModule } from '@angular/core';
import {
  NbActionsModule,
  NbButtonModule,
  NbCardModule,
  NbCheckboxModule,
  NbIconModule,
  NbInputModule,
  NbLayoutModule,
  NbListModule,
  NbMenuModule,
  NbSelectModule,
  NbSpinnerModule,
  NbStepperModule,
  NbToastrModule,
  NbToastrService
} from '@nebular/theme';

import { ThemeModule } from '../@theme/theme.module';
import { PagesComponent } from './pages.component';
import { PagesRoutingModule } from './pages-routing.module';
import { MenuComponent } from './menu/menu.component';
import { OrderComponent } from './order/order.component';
import { AuthModule } from './auth/auth.module';
import { OrderService } from './order/order.service';
import { MenuService } from './menu/menu.service';
import { ToastService } from '../@core/helpers/toast.service';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NotFoundComponent } from './not-found/not-found.component';
import { TipDraggerComponent } from './order/tip-dragger/tip-dragger.component';
import { DashboardComponent } from './dashboard/dashboard.component';

@NgModule({
  imports: [
    PagesRoutingModule,
    ThemeModule,
    NbInputModule,
    NbCardModule,
    NbButtonModule,
    NbActionsModule,
    NbIconModule,
    NbLayoutModule,
    NbStepperModule,
    NbToastrModule,
    NbMenuModule,
    NbSpinnerModule,
    NbSelectModule,
    NbListModule,
    FormsModule,
    ReactiveFormsModule,
    AuthModule,
  ],
  declarations: [
    DashboardComponent,
    NotFoundComponent,
    TipDraggerComponent,
    PagesComponent,
    MenuComponent,
    OrderComponent,
  ],
  providers: [
    ToastService,
    NbToastrService,
    MenuService,
    OrderService,
  ]
})
export class PagesModule {
}
