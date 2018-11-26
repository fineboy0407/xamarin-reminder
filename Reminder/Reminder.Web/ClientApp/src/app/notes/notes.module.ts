import { NgModule } from '@angular/core';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { NotesRoutingModule } from './notes-routing.module';
import { SharedModule } from '../shared/shared.module';
import { CreateNoteComponent } from './create-note/create-note.component';
import { NoteDetailsComponent } from './note-details/note-details.component';
import { NoteEditComponent } from './note-edit/note-edit.component';
import { NoteItemComponent } from './note-item/note-item.component';
import { NoteStartComponent } from './note-start/note-start.component';
import { NotesListComponent } from './notes-list/notes-list.component';
import { NotesComponent } from './notes.component';

@NgModule({
    declarations: [
        CreateNoteComponent,
        NoteDetailsComponent,
        NoteEditComponent,
        NoteItemComponent,
        NoteStartComponent,
        NotesListComponent,
        NotesComponent
    ],
    imports: [
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        NotesRoutingModule,
        SharedModule
    ]
})
export class NotesModule {
}
