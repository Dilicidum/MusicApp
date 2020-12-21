import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { user } from 'src/app/models/user';
import { genders } from 'src/app/models/gender';
import { UserNameUniqueAsyncValidator } from 'src/app/validators/username.validator';
import { CheckService } from 'src/app/services/check.service';
import { EmailAsyncValidator } from 'src/app/validators/email.validator';
import { UserService } from 'src/app/services/user.service';
import { MineService } from 'src/app/services/mine.service';

@Component({
  selector: 'app-profile-settings',
  templateUrl: './profile-settings.component.html',
  styleUrls: ['./profile-settings.component.css']
})
export class ProfileSettingsComponent implements OnInit {
  user:user={};
  profileForm:FormGroup;

  constructor(private checkService:CheckService,private userService:UserService,private currentUserService:MineService) { }

  ngOnInit(): void {
    this.currentUserService.getCurrentUserInfo().subscribe(data=>{
      this.user = data;
    })

    this.profileForm = new FormGroup({
      'firstName':new FormControl(this.user.firstName,[]),
      'lastName':new FormControl(this.user.lastName),
      'userName':new FormControl(this.user.userName,{
        validators:[],
        asyncValidators:UserNameUniqueAsyncValidator.userNameUniqueValidator(this.checkService),
        updateOn:'blur'}),
      'email':new FormControl(this.user.email,{
        validators:[Validators.email],
        asyncValidators:EmailAsyncValidator.emailValidator(this.checkService),
        updateOn:'blur',}),
    })
  }

  formIsInvalid:boolean=true;

  isValid(){
    this.profileForm.valueChanges.subscribe(data=>{
      if(data.firstName == '' && data.lastName == '' && data.userName == '' && data.email == ''){
        this.formIsInvalid = true;
      }
      else{
        this.formIsInvalid = false;
      }
    })
    return this.formIsInvalid;
  }

  onChange(){
    this.user.firstName = this.profileForm.get('firstName').value;
    this.user.lastName = this.profileForm.get('lastName').value;
    this.user.email = this.profileForm.get('email').value;
    this.user.userName = this.profileForm.get('userName').value;
    return this.currentUserService.changeUserInfo(this.user).subscribe(data=>{
      console.log('data = ',data);
    })
  }

}
