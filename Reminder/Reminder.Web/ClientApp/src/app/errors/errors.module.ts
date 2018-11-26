import { NgModule } from '@angular/core';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { ErrorsRoutingModule } from './errors-routing.module';
@NgModule({
  declarations: [
    PageNotFoundComponent
  ],
  imports: [
    ErrorsRoutingModule
  ]
})
export class ErrorsModule {
}
