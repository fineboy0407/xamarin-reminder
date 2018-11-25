import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { NotesComponent } from './notes.component';
import { CreateNoteComponent } from './create-note/create-note.component';
import { NoteStartComponent } from './note-start/note-start.component';
import { NoteEditComponent } from './note-edit/note-edit.component';
import { AuthGuardService } from '../auth/auth.guard.service';
import { NoteDetailsComponent } from './note-details/note-details.component';

const recipesRoutes: Routes = [
  {
    path: '', component: NotesComponent, canActivate: [AuthGuardService], children: [
      { path: '', component: NoteStartComponent },
      { path: 'new', component: CreateNoteComponent },
      { path: ':id', component: NoteDetailsComponent },
      { path: ':id/edit', component: NoteEditComponent },
    ]
  },
];

@NgModule({
  imports: [
    RouterModule.forChild(recipesRoutes)
  ],
  exports: [RouterModule],
  providers: [
    AuthGuardService
  ]
})
export class NotesRoutingModule {
}
