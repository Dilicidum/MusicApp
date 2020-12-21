import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { apiSetting } from '../models/apiSetting';

@Injectable({
  providedIn: 'root'
})
export class ApiService {
  baseUrl:string='http://localhost:64010/api/';
  constructor(private http:HttpClient) { }

  getToken(apiName:string):Observable<apiSetting>{
    return this.http.get<apiSetting>(this.baseUrl+'Songs/ApiSettings?apiName='+apiName);
  }

  hasSpotifyToken(){
    let token = localStorage.getItem('spotifyToken');
    if(token){
      return true;
    }
    else{
      return false;
    }
  }
}
