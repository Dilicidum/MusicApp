import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthenticationService } from '../services/authentication.service';
import { SearchService } from '../services/search.service';

@Component({
  selector: 'app-navigation-menu',
  templateUrl: './navigation-menu.component.html',
  styleUrls: ['./navigation-menu.component.css']
})
export class NavigationMenuComponent implements OnInit {
  searchForm:FormGroup;
  constructor(private authService:AuthenticationService,private searchService:SearchService,
    private router:Router) { }

  ngOnInit(): void {
    this.searchForm = new FormGroup({
      'searchQuery':new FormControl(''),
    });
  }

  isLoggedIn():boolean{
    if(this.authService.isLoggedIn()){
      return true;
    }
    else{
      return false;
    }
  }

  SearchTrack(){
    let searchQuery = this.searchForm.get('searchQuery').value;

    this.router.navigate(['/Search'],{queryParams:{q:searchQuery}})
    this.searchService.seacrhTrack(searchQuery).subscribe(tracks=>{
      this.searchService.changeSearch(tracks);
    })

  }

}
