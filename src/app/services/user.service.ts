import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { changePasswordModel } from '../models/changePasswordModel';
import { map, retry } from 'rxjs/operators';
import { user } from '../models/user';
import { avatar } from '../models/avatar';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  baseUrl:string  = 'http://localhost:64010/api/Users/';

  constructor(private http:HttpClient) { }

  getUsersAvatars():Observable<any>{
    return this.http.get('');
  }

  getUserLastAvatar(userName:string):Observable<avatar>{
    return this.http.get<avatar>(this.baseUrl)
  }

  getUserInfo():Observable<user>{
    return this.http.get<user>(this.baseUrl+localStorage.getItem('userId'))
  }

}
