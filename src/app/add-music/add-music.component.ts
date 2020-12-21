import { Component, OnInit, ComponentRef, ComponentFactoryResolver, ViewChild, ViewContainerRef } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { UploadSongService } from '../services/upload-song.service';
import { GenresDynamicComponent } from '../genres-dynamic/genres-dynamic.component';
import { GenreService } from '../services/genre.service';
import { genre } from '../models/genre';
import { FILE } from 'dns';

@Component({
  selector: 'app-add-music',
  templateUrl: './add-music.component.html',
  styleUrls: ['./add-music.component.css']
})
export class AddMusicComponent implements OnInit {
  componentRef:ComponentRef<GenresDynamicComponent>;
  uploadSongForm:FormGroup;
  genresCanBeChoosen:genre[]=[];
  genreLastToChoosen:string;
  genresToRegistrate:genre[]=[];

  @ViewChild('genreDynamic',{read:ViewContainerRef})elem:ViewContainerRef;

  constructor(private uploadSongService:UploadSongService,private genreService:GenreService,
    private resolver:ComponentFactoryResolver) { }

  ngOnInit(): void {
    this.genreService.getGenres().subscribe(data=>{
      this.genresCanBeChoosen = data;
    })
    this.initiateForm();
  }

  addDynamicGenre(event:Event){

    console.log('name f= ',this.genre.name);
    if(this.genre.name != '' && this.genre.name!= this.genreLastToChoosen){
      const element = this.resolver.resolveComponentFactory(GenresDynamicComponent);
      this.componentRef =  this.elem.createComponent(element);

      this.genresToRegistrate.push(this.genre);

      let genreToDeleteId = this.genresCanBeChoosen.findIndex(c=>c.name==this.genre.name);
      this.genresCanBeChoosen.splice(genreToDeleteId,1);
      console.log('this genre = ',this.genre);
      this.componentRef.instance.genre = this.genre;
      this.componentRef.instance.genres = this.genresCanBeChoosen;
      this.componentRef.instance.currentComponent = this.componentRef;
      this.genre.name = '';
      this.genreLastToChoosen = this.genre.name;
    }
    console.log('genresRegistratte = ',this.genresToRegistrate);
  }

  get songName(){
    return this.uploadSongForm.get('songName').value;
  }

  get artist(){
    return this.uploadSongForm.get('artist').value;
  }

  get year(){
    return this.uploadSongForm.get('year').value;
  }

  get genre():genre{

    let res : genre = {name:this.uploadSongForm.get('genres').value}
    console.log('res = ',res);
      return  res;
  }

  song:File=null;
  cover:File=null;


  handleImageFile(files:FileList){
    this.cover = files.item(0);
  }

  handleSongFile(files:FileList){
    console.log('files = ',files);
    console.log('file (0) = ',files.item(0));
    this.song = files.item(0);
    console.log('song = ',this.song);
  }

  initiateForm(){
    this.uploadSongForm = new FormGroup({
      'songName':new FormControl('', [Validators.required] ),
      'artist':new FormControl('',   [Validators.required] ),
      'year':new FormControl('',     [Validators.required] ),
      'genres':new FormControl('',    [Validators.required] ),
      'imageFile':new FormControl('',    [Validators.required] ),
      'songFile':new FormControl('',     [Validators.required] ),
    })
  }

  onSubmit(){
    console.log('song on Submit = ',this.song);
    this.uploadSongService.uploadSong(this.songName,this.artist,this.year,this.genresToRegistrate,this.cover,this.song).subscribe(data=>{
      console.log('data response upload = ',data);
    },
    error=>{
      console.log('err = ',error);
    })
  }

}
