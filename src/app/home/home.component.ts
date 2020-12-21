import { Component, OnInit } from '@angular/core';
import { DomSanitizer } from '@angular/platform-browser';
import { BlobGenerator } from '../helpers/Blob.Generator';
import { song } from '../models/song';
import { SongService } from '../services/song.service';
import {Track} from 'ngx-audio-player';
import { Howl,HowlOptions} from 'howler';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  song:song={
    cover : {},
    user:{}
  }

  constructor(private songService:SongService,private sanitazer:DomSanitizer,
    private BlobUrlGenerator:BlobGenerator) { }


  ngOnInit(): void {
    // if(this.song.coverUrl == null){
    //   this.songService.getSongCoverById(15).subscribe(data=>{
    //     console.log('DATA = ',data);
    //     this.song.coverUrl = data.url;
    //   })
    // }

    // if(this.song.name == null){
    //   this.songService.getSongInfoById(15).subscribe(data=>{
    //     console.log('data = ',data);
    //     this.song.name = data.name;
    //     this.song.views = data.views;
    //     this.song.id = data.id;
    //     this.song.user.id = data.user.id;
    //     this.song.user.userName = data.user.userName;

    //     this.song.likes = data.likes;
    //   })
    // }
  }


}
