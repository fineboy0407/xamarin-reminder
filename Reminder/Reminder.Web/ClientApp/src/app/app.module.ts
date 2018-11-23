import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { HeaderComponent } from './header/header.component';
import { NotesListComponent } from './notes-list/notes-list.component';
import { NotesService } from './notes.service';
import { CreateNoteComponent } from './create-note/create-note.component';
import { NoteDetailsComponent } from './note-details/note-details.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';
import { SigninComponent } from './auth/signin/signin.component';
import { SignupComponent } from './auth/signup/signup.component';
import { AuthService } from './auth/auth.service';
import { HomeComponent } from './home/home.component';
import { DropdownDirective } from './dropdown.directive';
import { NotesComponent } from './notes/notes.component';
import { NoteItemComponent } from './note-item/note-item.component';
import { AuthGuardService } from './auth/auth.guard.service';
import { NoteStartComponent } from './note-start/note-start.component';
import { NoteEditComponent } from './note-edit/note-edit.component';
import { AuthInterceptor } from './shared/auth.interceptor';
import { AuthCallbackComponent } from './auth/auth-callback/auth-callback.component';
import { LogoutCallbackComponent } from './auth/logout-callback/logout-callback.component';

@NgModule({
  declarations: [
    DropdownDirective,
    AppComponent,
    HeaderComponent,
    NotesListComponent,
    CreateNoteComponent,
    PageNotFoundComponent,
    SigninComponent,
    SignupComponent,
    HomeComponent,
    NotesComponent,
    NoteItemComponent,
    NoteStartComponent,
    NoteEditComponent,
    AuthCallbackComponent,
    LogoutCallbackComponent,
    NoteDetailsComponent
  ],
  imports: [
    BrowserModule,
    ReactiveFormsModule,
    AppRoutingModule,
    HttpClientModule
  ],
  exports: [
    DropdownDirective
  ],
  providers: [
    NotesService,
    AuthService,
    AuthGuardService,
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
