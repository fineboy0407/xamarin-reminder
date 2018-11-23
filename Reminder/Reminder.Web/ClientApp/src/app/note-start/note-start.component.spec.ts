import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { NoteStartComponent } from './note-start.component';

describe('NoteStartComponent', () => {
  let component: NoteStartComponent;
  let fixture: ComponentFixture<NoteStartComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ NoteStartComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(NoteStartComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
