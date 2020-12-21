///  <reference types="@types/spotify-web-playback-sdk"/>
import { Component, DoCheck, Input, KeyValueDiffers, OnInit } from '@angular/core';
import { image } from '../models/image';
import { song } from '../models/song';
import { SearchService } from '../services/search.service';
import {Howl} from 'howler';
import { Track } from 'ngx-audio-player';
import { DataService } from '../services/data.service';
import { currentTrack } from '../models/currentTrack';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-short-view-track',
  templateUrl: './short-view-track.component.html',
  styleUrls: ['./short-view-track.component.css']
})

export class ShortViewTrackComponent implements OnInit,DoCheck {
  @Input('track')track:song;
  currentTrack:currentTrack={
    isPlaying:false,
  }
  isPlaying:boolean = false;
  spotifyPlayer:Spotify.SpotifyPlayer;
  optionsPlayer:Spotify.PlayerInit={
    volume : 0.1,
    name:'fe',
    getOAuthToken:cb=>{cb(this.token)}
  }

  playBackInstanceListener:Spotify.PlaybackInstanceListener=()=>{
    console.log('playback instance');
  }

  device_id:string='2898f24291badb63006be36c7c38c76a3b178b75';
  token:string='BQCn7wDPn514BSr9WihwEqORZDS4VRYQmxDVCvnJuq16zPRA4C8yqZNsSSh-29dSjCODh8FxDFAdvKf6lN6thdoZUDgqrKWvuwZh-lHj3UuixhhyqyugZNf24XT__AribSijRyCyjfdLSdKvpajrtuyar1O4_0Ae5YOPmQXOlOEnhQATd8W36Y8'
  artistsName:string='';
  image:image={};
  player:Howl;
  activeTrack:Track ={
    link:'',
    title:'',
  };
  constructor(private differs:KeyValueDiffers,private dataService:DataService,private http:HttpClient) { }

  ngOnInit(): void {

    if(this.track != undefined){
      this.track.url = this.track.href;
      this.track.track = new Track;
      this.track.track.link = this.track.href;
      this.track.track.title = this.track.name;
    }
    if(this.track!=undefined && this.track.artists != undefined) {
      this.track.artists.forEach(c=>{
        this.artistsName += c.name + ' ';
      });
    }
    if(this.track != undefined){
      this.image = this.track.album.images[0];
    }
  }

  ngDoCheck(){
    let changes = this.differs.find(this.track);
    if(changes){
    }
  }

  playSong(){



    this.currentTrack.player = this.player;
    this.currentTrack.track = this.track;


    //this.spotifyPlayer = new Spotify.Player(this.optionsPlayer);



    this.dataService.changeData(this.currentTrack);


    this.isPlaying = true;
    //this.player.play();




  }

}
