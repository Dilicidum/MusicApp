import { Component, OnInit } from '@angular/core';
import { CookieService } from 'ngx-cookie-service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { LoginService } from '../services/login.service';
import { resetPasswordModel } from '../models/resetPasswordModel';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-password-reset',
  templateUrl: './password-reset.component.html',
  styleUrls: ['./password-reset.component.css']
})
export class PasswordResetComponent implements OnInit {
  resetPasswordForm:FormGroup;
  constructor(private cookieService:CookieService,private loginService:LoginService,private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.resetPasswordForm = new FormGroup({
      'password':new FormControl('',[Validators.required]),
      'passwordConfirmed':new FormControl('',[Validators.required]),
    })
  }

  resetPasswordModel:resetPasswordModel={};
  showMessage:boolean=false;
  onSubmit(){
    this.resetPasswordModel.password = this.resetPasswordForm.get('password').value;
    this.resetPasswordModel.passwordConfirmed = this.resetPasswordForm.get('passwordConfirmed').value;

    this.route.queryParams.subscribe(data=>{
      this.resetPasswordModel.email = data["email"];
      this.resetPasswordModel.token = data["token"];
    })
    console.log('token = ',this.resetPasswordModel.token);
    return this.loginService.resetPassword(this.resetPasswordModel).subscribe(data=>{
      console.log('data = ',data);

    })
  }



}
