import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from './services/authentication.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'SPA';

  constructor(private router:Router,private authService:AuthenticationService){}



  ngOnInit(){
    if(this.authService.isLoggedIn()){
      this.router.navigateByUrl('/home');
    }
  }
}
