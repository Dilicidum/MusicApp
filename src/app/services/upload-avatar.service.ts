import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UploadAvatarService {
  baseURL:string='http://localhost:64010/api/';
  constructor(private http:HttpClient) { }

  uploadAvatar(file:File){
    let currentRequestURL = this.baseURL+'Mine/Avatars';
    const formData:FormData = new FormData();
    formData.append('file',file,file.name);
    return this.http.post(currentRequestURL,formData);
  }

}
