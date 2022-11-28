import { NgModule } from '@angular/core';
import { NbButtonModule, NbCardModule, NbCheckboxModule, NbIconModule, NbInputModule, NbLayoutModule } from '@nebular/theme';
import { ThemeModule } from '../../@theme/theme.module';
import { AuthRoutingModule } from './auth-routing.module';
import { AuthComponent } from './auth.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { FormsModule } from '@angular/forms';

@NgModule({
    imports: [
        AuthRoutingModule,
        NbCardModule,
        ThemeModule,
        NbInputModule,
        FormsModule,
        NbButtonModule,
        NbCheckboxModule,
        NbLayoutModule,
        NbIconModule,
    ],
    declarations: [
        AuthComponent,
        LoginComponent,
        RegisterComponent,
    ],
})
export class AuthModule { }