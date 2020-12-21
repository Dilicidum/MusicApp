import { Component, OnInit, Inject, ElementRef, ViewChild } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import {MatDialogRef,MAT_DIALOG_DATA} from '@angular/material/dialog';
import { UploadAvatarService } from 'src/app/services/upload-avatar.service';
import { AvatarService } from 'src/app/services/avatar.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-profile-avatar-upload-popup',
  templateUrl: './profile-avatar-upload-popup.component.html',
  styleUrls: ['./profile-avatar-upload-popup.component.css']
})
export class ProfileAvatarUploadPopupComponent implements OnInit {
  uploadAvatarForm:FormGroup;
  constructor(private dialogRef: MatDialogRef<ProfileAvatarUploadPopupComponent>,
    @Inject(MAT_DIALOG_DATA) data,private uploadAvatarService:UploadAvatarService,
    private avatarService:AvatarService,private activatedRoute:ActivatedRoute,private router:Router) { }
    @ViewChild('uploadAvatar')elementRef:ElementRef;
  ngOnInit(): void {
    this.uploadAvatarForm = new FormGroup({
      'avatar':new FormControl('',[Validators.required])
    })
  }

  fileToUpload:File = null;

  close(){
    this.dialogRef.close();
  }

  uploadPhoto(){

    this.elementRef.nativeElement.click();

  }

  onSubmitUploadPhoto(files:FileList){
    let file = files.item(0);
    this.uploadAvatarService.uploadAvatar(file).subscribe(data=>{
      this.router.navigateByUrl('',{skipLocationChange:true}).then(()=>{
        this.router.navigate(['Profile'])
      })
      this.dialogRef.close();
    },error=>{

    })

  }

  deleteCurrentAvatar(){

    this.avatarService.deleteLastAvatar().subscribe(data=>{
      this.router.navigateByUrl('',{skipLocationChange:true}).then(()=>{
        this.router.navigate(['Profile'])
      })
      this.dialogRef.close();
    });
  }

}
