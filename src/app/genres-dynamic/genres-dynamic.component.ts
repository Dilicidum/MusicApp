import { Component, OnInit, Input, Output, EventEmitter, ComponentRef } from '@angular/core';
import { genre } from '../models/genre';

@Component({
  selector: 'app-genres-dynamic',
  templateUrl: './genres-dynamic.component.html',
  styleUrls: ['./genres-dynamic.component.css']
})
export class GenresDynamicComponent implements OnInit {
  @Input()genre:genre;
  @Input('genreComponent')currentComponent:ComponentRef<GenresDynamicComponent>;
  @Output() closeGenre = new EventEmitter();
  @Input('genres')genres:genre[];
  @Input()genresToRegistrate:genre[];
  constructor() { }

  ngOnInit(): void {

  }

  close(){
    let genreToDeleteId = this.genres.findIndex(c=>c.name==this.genre.name);
    this.genres.splice(genreToDeleteId,1);
    this.genres.push(this.genre);
    console.log('genrs = ',this.genres);
    this.currentComponent.destroy();
  }

}
