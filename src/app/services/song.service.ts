import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { image } from '../models/image';
import { song } from '../models/song';
import { songFile } from '../models/songFile';

@Injectable({
  providedIn: 'root'
})
export class SongService {
  baseUrl:string  = 'http://localhost:64010/api/Songs'
  constructor(private http:HttpClient) { }

  getSongCoverById(id:number):Observable<image>{
    return this.http.get<image>(this.baseUrl + '/SongCover?Id=' + id.toString()).pipe(
      map(res=>{
        return {
          url:res.url
        } as image;
      })
    );
  }

  getSongInfoById(id:number):Observable<song>{
    return this.http.get<song>(this.baseUrl+'/SongInfo?Id='+id.toString()).pipe(
      map(res=>{
        return res;
      })
    )
  }

  getSongFileById(id:number):Observable<song>{
    return this.http.get<song>(this.baseUrl+'/SongFile?Id='+id.toString()).pipe(
      map(res=>{
        return res;
      })
    )
  }
}
