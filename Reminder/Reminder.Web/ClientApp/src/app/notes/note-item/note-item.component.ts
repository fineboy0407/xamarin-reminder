import { Component, Input, OnInit } from '@angular/core';
import { Note } from '../note';

@Component({
  selector: 'app-note-item',
  templateUrl: './note-item.component.html',
  styleUrls: ['./note-item.component.css']
})
export class NoteItemComponent implements OnInit {
  @Input() note: Note;
  @Input() index: number;

  constructor() { }

  ngOnInit() {
  }
}
