import { HttpInterceptor, HttpRequest, HttpHandler } from '@angular/common/http';
import { AuthenticationService } from '../services/authentication.service';
import { Injectable } from '@angular/core';
import { ApiService } from '../services/api.service';

@Injectable()
export class SpotifyTokenInterceptor implements HttpInterceptor{
  constructor(private authService:AuthenticationService,
    private apiService:ApiService){}

  intercept(req:HttpRequest<any>,next:HttpHandler){

    if(this.apiService.hasSpotifyToken()){
      let token = localStorage.getItem('spotifyToken');
      if(req.url.includes('https://api.spotify.com'))
      {
        req = req.clone({
          setHeaders:{
            Authorization:`Bearer ${token}`
          }
        })
      }
    }
    return next.handle(req);
  }
}
