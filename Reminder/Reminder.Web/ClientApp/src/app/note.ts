import { Photo } from './photo';

export class Note {
  constructor(public id?: number,
              public description?: string,
              public date?: Date,
              public photos?: Photo[]) { }
}
