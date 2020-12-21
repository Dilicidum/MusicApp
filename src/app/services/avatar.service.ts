import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { retry, mergeMap, map } from 'rxjs/operators';
import { Observable, of, from } from 'rxjs';
import { error } from 'protractor';
import { avatar } from '../models/avatar';
import { RSA_NO_PADDING } from 'constants';

@Injectable({
  providedIn: 'root'
})
export class AvatarService {
  baseUrl:string  = 'http://localhost:64010/api/Avatars/';
  constructor(private http:HttpClient) { }

  checkIfUserHasAvatars():Observable<boolean> {
    return this.http.get<boolean>(this.baseUrl).pipe(
      retry(2)
    )
  }

  getLastAvatar():Observable<avatar>{
    return this.http.get<any>(this.baseUrl+'Last').pipe(
      retry(2),
      map(res=>{
        return {
          image:res.imageDTO,
          timeOfUploading:res.timeOfUploading
        } as avatar;
      })
    )
  }

  deleteLastAvatar(){
    return this.http.delete(this.baseUrl+'Last').pipe(
      retry(2),
      map(res=>{
        console.log('res = ',res);
        return res;
      })
    )
  }
}
