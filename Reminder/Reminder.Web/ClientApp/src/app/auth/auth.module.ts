import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SigninComponent } from './signin/signin.component';
import { SignupComponent } from './signup/signup.component';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';
import { LogoutCallbackComponent } from './logout-callback/logout-callback.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AuthRoutingModule } from './auth.routing.module';
import { CoreModule } from '../core/core.module';

@NgModule({
    declarations: [
        SigninComponent,
        SignupComponent,
        AuthCallbackComponent,
        LogoutCallbackComponent
    ],
    imports: [
        CoreModule,
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        AuthRoutingModule
    ]
})
export class AuthModule {
}
