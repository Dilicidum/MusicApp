import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { LoginService } from '../services/login.service';
import { forgetPasswordModel } from '../models/forgetPasswordModel';
import { Router } from '@angular/router';

@Component({
  selector: 'app-forgot-password',
  templateUrl: './forgot-password.component.html',
  styleUrls: ['./forgot-password.component.css']
})
export class ForgotPasswordComponent implements OnInit {
  passwordResetForm:FormGroup;
  constructor(private loginService:LoginService,private router:Router) { }

  ngOnInit(): void {
    this.passwordResetForm = new FormGroup(
      {
        'email':new FormControl('',[Validators.required,Validators.email])
      }
    )
  }

  get email():string{
    console.log('')
    return this.passwordResetForm.get('email').value;
  }

  forgetPasswordModel:forgetPasswordModel={};

  onSubmit(){
    this.forgetPasswordModel.email = this.email;

    this.loginService.forgetPassword(this.forgetPasswordModel).subscribe(data=>{
      if(data.resultOfSendingEmail == true){
        console.log('wefw');
      }
      else{
        this.passwordResetForm.reset();
      }
    },error=>{
      console.log('error = ',error);
    })
  }

}
