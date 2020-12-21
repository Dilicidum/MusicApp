import { Injectable } from '@angular/core';

@Injectable({'providedIn':'root'})
export class BlobGenerator{
  constructor(){

  }

  getBlobUrl(base64String:string,typeOfFile:string):string{
    let Blob = this.generateBlob(base64String,typeOfFile);
    let BlobUrl = URL.createObjectURL(Blob);
    return BlobUrl;
  }

  private generateBlob(base64String:string,typeOfFile:string):Blob{
    var raw = window.atob(base64String);
    var rawLength = raw.length;
    var array = new Uint8Array(new ArrayBuffer(rawLength));
    for(let i = 0; i < rawLength; i++) {
      array[i] = raw.charCodeAt(i);
    }
    const blob=new Blob([array], {type : typeOfFile});
    return blob;
}
}
