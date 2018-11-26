import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const errorsRoutes: Routes = [
    { path: '**', component: PageNotFoundComponent }
];

@NgModule({
    imports: [
        RouterModule.forChild(errorsRoutes)
    ],
    exports: [RouterModule]
})
export class ErrorsRoutingModule {
}
