import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { song } from '../models/song';

@Injectable({
  providedIn: 'root'
})
export class SearchService {
  baseUrl:string='http://localhost:64010/api/';
  songs:song[]=[];
  private tracksSubject = new BehaviorSubject(this.songs);
  tracks:Observable<song[]>;
  constructor(private http:HttpClient) {
    this.tracks = this.tracksSubject.asObservable()
   }

  seacrhTrack(query:string):Observable<song[]>{
    return this.http.get<song[]>(this.baseUrl+'Search?q='+query+'&types=track,artist,albums')
  }

  changeSearch(tracks:song[]){
    this.tracksSubject.next(tracks);
  }
}
