import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { error } from 'console';
import { songUploadModel } from '../models/songUploadModel';
import { genre } from '../models/genre';

@Injectable({
  providedIn: 'root'
})

export class UploadSongService {
  baseUrl:string = 'http://localhost:64010/api/';
  constructor(private http:HttpClient) { }

  headers={
    headers: new HttpHeaders({
        'Content-Type': 'application/json'
    })
  }

  uploadSong(songName,artistName,year,genres:genre[],imageFile:File,songFile:File){
    const songUploadModel:songUploadModel = {};
    const formData:FormData = new FormData();

    //console.log('genre = ',JSON.stringify(genres));

    let genresString = [];



    formData.append('cover',imageFile,imageFile.name);
    formData.append('song',songFile,songFile.name);
    formData.append('songName',(songName));
    formData.append('artist',JSON.stringify(artistName));
    formData.append('year',JSON.stringify(year));
    for(let i=0;i<genres.length;i++){
      formData.append('genres[' + i + '].name', genres[i].name);
    }



    return this.http.post(this.baseUrl+'Songs',formData ).pipe(
      map(res=>{
        console.log('res = ',res);
        return res;
      },
      error=>{
        console.log('error = ',error);
      })
    )
  }

}
