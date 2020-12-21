import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';
import { Injectable } from '@angular/core';


@Injectable({'providedIn':'root'})
export class AuthGuard implements CanActivate{

  constructor(
    private router:Router,
    private authenticationService:AuthenticationService
  ){}


  canActivate(router:ActivatedRouteSnapshot,state:RouterStateSnapshot){
    if(this.authenticationService.isLoggedIn()){
      console.log('what?')
      return true;
    }
    else{
      this.router.navigateByUrl('/Login');
      return false;
    }
  }
}
