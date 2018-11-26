import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SignupComponent } from './signup/signup.component';
import { SigninComponent } from './signin/signin.component';
import { AuthCallbackComponent } from './auth-callback/auth-callback.component';
import { LogoutCallbackComponent } from './logout-callback/logout-callback.component';

const authRoutes: Routes = [
    { path: 'signup', component: SignupComponent },
    { path: 'signin', component: SigninComponent },
    { path: 'auth-callback', component: AuthCallbackComponent },
    { path: 'logout-callback', component: LogoutCallbackComponent }
];

@NgModule({
    imports: [
        RouterModule.forChild(authRoutes)
    ],
    exports: [RouterModule]
})
export class AuthRoutingModule {
}
