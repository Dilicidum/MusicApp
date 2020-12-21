import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { genre } from '../models/genre';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class GenreService {
  baseUrl:string='http://localhost:64010/api/';
  constructor(private http:HttpClient) { }

  getGenres():Observable<genre[]>{
    return this.http.get<genre[]>(this.baseUrl+'Genres').pipe(
      map(res=>{
        console.log('res = ',res);
        return res;
      })
    );
  }
}
