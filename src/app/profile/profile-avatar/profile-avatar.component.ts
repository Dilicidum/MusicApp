import { Component, OnInit, Sanitizer } from '@angular/core';
import { ProfileAvatarUploadPopupComponent } from './profile-avatar-upload-popup/profile-avatar-upload-popup.component';
import {MatDialog} from '@angular/material/dialog';
import {} from '@angular/material/form-field';
import { AvatarService } from 'src/app/services/avatar.service';
import { avatar } from 'src/app/models/avatar';
import { DomSanitizer } from '@angular/platform-browser';
import { mergeMap } from 'rxjs/operators';
import { MineService } from 'src/app/services/mine.service';
import { Router, NavigationEnd } from '@angular/router';
import { BlobGenerator } from 'src/app/helpers/Blob.Generator';

@Component({
  selector: 'app-profile-avatar',
  templateUrl: './profile-avatar.component.html',
  styleUrls: ['./profile-avatar.component.css']
})
export class ProfileAvatarComponent implements OnInit {
  navigationSubscription;

  constructor(private dialog:MatDialog,private avatarService:AvatarService,
    private sanitazer:DomSanitizer,private mineService:MineService,private router:Router,private AvatarGenerator:BlobGenerator)
    {this.showDefaultIcon = false; }
  showDefaultIcon:boolean;
  avatar:avatar={

  };



  ngOnInit(): void {
    this.mineService.hasAvatars().pipe(mergeMap( res =>{
      if(res==false){
        this.showDefaultIcon=true;
      }
      else{
        this.showDefaultIcon = false;
      }
      return this.mineService.getLastAvatar();
    })).subscribe(data=>{
        this.avatar = data;
        console.log('avatar = ',data);
    })
  }

  openDialog(){
    this.dialog.open(ProfileAvatarUploadPopupComponent,{width:'300px',height:'300px',});
  }

  getImgContent(){
    //let x =  this.sanitazer.bypassSecurityTrustUrl(this.avatar.imageBlobURL);
    //console.log('byte = ',this.avatar.image.imageSerialized);

  }

}
