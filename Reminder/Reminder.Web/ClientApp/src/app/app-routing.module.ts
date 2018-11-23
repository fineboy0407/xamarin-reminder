import {RouterModule, Routes} from '@angular/router';
import {NgModule} from '@angular/core';
import {CreateNoteComponent} from './create-note/create-note.component';
import {NoteDetailsComponent} from './note-details/note-details.component';
import {SignupComponent} from './auth/signup/signup.component';
import {SigninComponent} from './auth/signin/signin.component';
import {PageNotFoundComponent} from './page-not-found/page-not-found.component';
import {HomeComponent} from './home/home.component';
import {NotesComponent} from './notes/notes.component';
import {AuthGuardService} from './auth/auth.guard.service';
import {NoteStartComponent} from './note-start/note-start.component';
import {NoteEditComponent} from './note-edit/note-edit.component';
import { AuthCallbackComponent } from './auth/auth-callback/auth-callback.component';
import { LogoutCallbackComponent } from './auth/logout-callback/logout-callback.component';

const appRoutes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'signin', component: SigninComponent},
  {path: 'signup', component: SignupComponent},
  {path: 'auth-callback', component: AuthCallbackComponent},
  {path: 'logout-callback', component: LogoutCallbackComponent},
  {
    path: 'notes', component: NotesComponent, canActivate: [AuthGuardService], children: [
      {path: '', component: NoteStartComponent},
      {path: 'new', component: CreateNoteComponent},
      {path: ':id', component: NoteDetailsComponent},
      {path: ':id/edit', component: NoteEditComponent},
    ]
  },
  {path: '**', component: PageNotFoundComponent}
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      appRoutes)
  ],
  exports: [
    RouterModule]
})
export class AppRoutingModule {
}
