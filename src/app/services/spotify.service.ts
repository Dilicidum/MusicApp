import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { token } from '../models/token';

@Injectable({
  providedIn: 'root'
})

export class SpotifyService {
  baseURL:string='http://localhost:64010/api/Spotify/Token';
  constructor(private http:HttpClient) { }

  getToken():Observable<token>{
    return this.http.get<token>(this.baseURL).pipe(
      map(token=>{

        return token;
      })
    )
  }
}
