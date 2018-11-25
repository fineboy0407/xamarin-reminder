import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { Note } from './note';
import {Subject} from 'rxjs/Subject';
import {AuthService} from '../auth/auth.service';

@Injectable()
export class NotesService {
  private headers: HttpHeaders;
  private url = 'http://localhost:49790/api/notes';

  private notes: Note[] = [];
  notesChanged = new Subject<Note[]>();

  constructor(private http: HttpClient, private authService: AuthService) {
    this.headers = new HttpHeaders({'Content-Type': 'application/json; charset=utf-8'});
  }

  getNotes() {
    this.http.get(this.url, {headers: this.headers})
      .subscribe((data: Note[]) => {
        if (data != null) {
          this.notes = data;
          this.notesChanged.next(this.notes.slice());
        }
      }, error => {
        console.log(error);
      });
    return this.notes.slice();
  }

  // Get in reverse order since all notes ordered by id descending
  getNoteById(id: number) {
    this.http.get(this.url + '/' + (this.notes.length - id), {headers: this.headers})
      .subscribe((result: Note) => {
        this.notes[this.notes.length - result.id] = result;
      }, error => {
        console.log(error);
      });
    return this.notes[id];
  }

  // In case of create new note retrieve all notes again and invoke event
  createNote(note: Note) {
    this.http.post(this.url, note, {headers: this.headers})
      .subscribe((result: Note) => {
        this.notes.push(note);
        this.notesChanged.next(this.notes.slice());
      }, error => {
        console.log(error);
      });
  }

  updateNote(note: Note) {
    return this.http.put(this.url + '/' + note.id, note, {headers: this.headers});
  }

  deleteNote(id: number) {
    return this.http.delete(this.url + '/' + id, {headers: this.headers});
  }
}
