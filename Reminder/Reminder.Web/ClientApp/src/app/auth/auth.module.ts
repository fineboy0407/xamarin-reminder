import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SigninComponent } from './signin/signin.component';
import { SignupComponent } from './signup/signup.component';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';
import { LogoutCallbackComponent } from './logout-callback/logout-callback.component';
import { FormsModule, ReactiveFormsModule, FormGroup } from '@angular/forms';
import { AuthRoutingModule } from './auth.routing.module';

@NgModule({
    declarations: [
        SigninComponent,
        SignupComponent,
        AuthCallbackComponent,
        LogoutCallbackComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        AuthRoutingModule
    ]
})
export class AuthModule {
}