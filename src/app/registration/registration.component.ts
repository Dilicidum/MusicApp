import { Component, OnInit, OnDestroy, ComponentFactoryResolver, ViewChild, ViewContainerRef, ComponentRef } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { AuthenticationService } from '../services/authentication.service';
import { Router } from '@angular/router';
import { userRegistrationModel } from '../models/userRegistrationModel';
import { RegistrationService } from '../services/registration.service';
import { Subscription } from 'rxjs';
import { passwordValidator } from '../validators/password.validator';
import { EmailAsyncValidator } from '../validators/email.validator';
import { CheckService } from '../services/check.service';
import { UserNameUniqueAsyncValidator } from '../validators/username.validator';
import { GenreService } from '../services/genre.service';
import { genre } from '../models/genre';
import { GenresDynamicComponent } from '../genres-dynamic/genres-dynamic.component';


@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.css']
})
export class RegistrationComponent implements OnInit,OnDestroy {
  userRegisterModel:userRegistrationModel={};
  registrationForm:FormGroup;
  @ViewChild('genreDynamic',{read:ViewContainerRef})elem:ViewContainerRef;

  constructor(private registrationService:RegistrationService,private authService:AuthenticationService,
    private router:Router,private checkService:CheckService,private genreService:GenreService,
    private resolver:ComponentFactoryResolver) { }

  genres:genre[]=[];
  genresToRegistrate:genre[]=[];
  ngOnInit(): void {
    this.registrationForm = new FormGroup({
      'firstName':new FormControl('',Validators.required),
      'lastName':new FormControl('',Validators.required),
      'userName':new FormControl('',{
        validators:[Validators.required],
        asyncValidators: UserNameUniqueAsyncValidator.userNameUniqueValidator(this.checkService),
        updateOn:'blur'
      }),
      'email':new FormControl(null,{
        validators:[Validators.required,Validators.email],
        asyncValidators:[EmailAsyncValidator.emailValidator(this.checkService)],
        updateOn:'blur',
      }),
      'dateOfBirth':new FormControl('',Validators.required),
      'passwords':new FormGroup({
        'password':new FormControl('',Validators.required),
        'passwordConfirmed':new FormControl('',[Validators.required]),
      },[Validators.required,passwordValidator()]),
      'genres':new FormControl('')
    })
    this.getGenres();
  }

  get password(){
    if(this.registrationForm !== undefined)
    return this.registrationForm.get('password').value;
  }

  get genre():genre{
      let res : genre ={name:this.registrationForm.get('genres').value}
      return  res;
  }

  Response:Subscription;

  destroyComponent(event){
    console.log('destory');
    this.componentRef.destroy();
  }

  onSubmit(){
    this.userRegisterModel.firstName = this.registrationForm.get('firstName').value;
    this.userRegisterModel.lastName = this.registrationForm.get('lastName').value;
    this.userRegisterModel.userName = this.registrationForm.get('userName').value;
    this.userRegisterModel.email = this.registrationForm.get('email').value;
    this.userRegisterModel.password = this.registrationForm.get('passwords').get('password').value;
    this.userRegisterModel.confirmedPassword = this.registrationForm.get('passwords').get('passwordConfirmed').value;
    this.userRegisterModel.genres =this.genresToRegistrate;
    this.userRegisterModel.dateOfBirth = this.registrationForm.get('dateOfBirth').value;
    console.log('this user = ',this.userRegisterModel.genres);
    this.Response = this.registrationService.register(this.userRegisterModel).subscribe(data=>{
      console.log('data =',data);
      this.router.navigateByUrl('');
    })
  }



  componentRef:ComponentRef<GenresDynamicComponent>;

  lastGenrePicked:string;

  addDynamicGenre(event:Event){
    console.log('name f= ',this.genre.name);
    if(this.genre.name != '' && this.genre.name!= this.lastGenrePicked){
      const element = this.resolver.resolveComponentFactory(GenresDynamicComponent);
      this.componentRef =  this.elem.createComponent(element);

      this.genresToRegistrate.push(this.genre);

      let genreToDeleteId = this.genres.findIndex(c=>c.name==this.genre.name);
      this.genres.splice(genreToDeleteId,1);
      console.log('this genre = ',this.genre);
      this.componentRef.instance.genre = this.genre;
      this.componentRef.instance.genres = this.genres;
      this.componentRef.instance.currentComponent = this.componentRef;
      this.genre.name = '';
      this.lastGenrePicked = this.genre.name;
    }

  }

  getGenres(){
    this.genreService.getGenres().subscribe(genres=>{
      console.log('genre = ',genres);
      this.genres = genres;
    });
  }

  ngOnDestroy(){

  }

}
