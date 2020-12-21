import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { forkJoin } from 'rxjs';
import { song } from '../models/song';
import { SearchService } from '../services/search.service';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {
  searchQuery:string;
  tracks:song[]=[];
  constructor(private searchService:SearchService,private route:ActivatedRoute) { }

  ngOnInit(): void {

    this.route.queryParams.subscribe(params=>{
      this.searchQuery = params.q;

    });

    if(this.searchQuery!=null){



        this.searchService.tracks.subscribe(tracks=>{
          this.tracks = tracks;
        });

    }

  }

}
