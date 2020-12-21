///  <reference types="@types/spotify-web-playback-sdk"/>
import { HttpClient } from '@angular/common/http';
import { AfterViewInit, Component, DoCheck, ElementRef, Input, KeyValueDiffers, OnInit, ViewChild } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { DomSanitizer } from '@angular/platform-browser';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { BlobGenerator } from 'src/app/helpers/Blob.Generator';
import { currentTrack } from 'src/app/models/currentTrack';
import { song } from 'src/app/models/song';
import { ApiService } from 'src/app/services/api.service';
import { DataService } from 'src/app/services/data.service';
import { SpotifyService } from 'src/app/services/spotify.service';


@Component({
  selector: 'app-song-control-panel',
  templateUrl: './song-control-panel.component.html',
  styleUrls: ['./song-control-panel.component.css']
})
export class SongControlPanelComponent implements OnInit,AfterViewInit,DoCheck {
  durationS:number=0;
  optionsPlayer:Spotify.PlayerInit={
    volume : 0.1,
    name:'fe',
    getOAuthToken:cb=>{cb(this.token)}
  }

  get token():string{
    return localStorage.getItem('SDK_Token');
  }

  set token(value:string){
    localStorage.setItem('SDK_Token',value);
  }

  get device_Id():string{
    return localStorage.getItem('device_Id');
  }

  set device_Id(value:string){
    localStorage.setItem('device_Id',value);
  }

  spotifyPlayer:Spotify.SpotifyPlayer;
  currentTrack?:currentTrack={
    isPlaying:false
  };

  @ViewChild('rangeElement')rangeElement:ElementRef;
  rangeForm:FormGroup;
  constructor(private BlobUrlGenerator:BlobGenerator,private sanitazer:DomSanitizer,
    private apiService:ApiService,private differs:KeyValueDiffers,private http:HttpClient,private dataService:DataService,
    private router:Router,private route:ActivatedRoute,private spotifyService:SpotifyService) {}
  artistsName:string='';
  amountOfSpotifyPlayers = 0;
  ngAfterViewInit(){
  //this.rangeElement.nativeElement.value = 0;
  //this.rangeElement.nativeElement.step = 1;
  if(this.currentTrack){
    if(this.currentTrack.track != undefined){
      this.rangeElement.nativeElement.max = this.currentTrack.player.duration;
    }
  }
  }

  isSDKTokenExpired():boolean{
    let tokenExpiredDate = new Date(localStorage.getItem('SDK_Token_TimeExpired'));
    let currentDate = new Date();
    if(currentDate > tokenExpiredDate){
      return true;
    }else{
      return false;
    }
  }

  millisToMinutesAndSecondsView(millis):string{
    let minutes = Math.floor(millis / 60000);
    let seconds = ((millis % 60000) / 1000).toFixed(0);
    let secondsInt = 0;
    parseInt(seconds,secondsInt);
    return minutes + ":" + (secondsInt < 10 ? '0' : '') + seconds;
  }

  millissToSeconds(millis):number{
    //let minutes = Math.floor(millis / 60000);
    console.log('input = ',millis);
    let seconds = (millis / 1000).toFixed(0);
    console.log('seconds = ',seconds);
    let secondsInt = 0;
    secondsInt = parseInt(seconds,secondsInt);;

    console.log('secondsInt = ',secondsInt);
    return secondsInt;
  }

  ngOnInit(): void {

    this.rangeForm = new FormGroup({
      'range':new FormControl('')
    });

    if(this.device_Id == undefined){
      console.log('get DEvice id');
      this.getDeviceId();
    }

    this.dataService.data.subscribe(
      (currentTrack)=>{
      this.currentTrack = currentTrack;
      if(this.currentTrack.track){
        console.log('currentTrack = ',this.currentTrack);
        console.log('COVER = ',this.currentTrack.track.album.images[0].url);
        console.log('amount = ',this.amountOfSpotifyPlayers);
        this.durationS  = this.millissToSeconds(currentTrack.track.durationMs)
        console.log('duration S = ',this.durationS);
        if(this.amountOfSpotifyPlayers == 0){
          this.initSpotifyPlayer();
          this.amountOfSpotifyPlayers++;
        }
        if(this.device_Id)
        {
          this.playSong();
        }

      }
    });

  }

  getDeviceId(){
  }

  initSpotifyPlayer(){
    if(!this.isSDKTokenExpired()){
      this.token = localStorage.getItem('SDK_Token');
    }
    else{
      this.spotifyService.getToken().subscribe(token=>{
        localStorage.setItem('SDK_Token',token.token);
        let dateTimeString = token.timeExpired.toString();
        localStorage.setItem('SDK_Token_TimeExpired',dateTimeString);
        this.token = token.token;
      });
    }

    const token = this.token;

    this.spotifyPlayer = new Spotify.Player({
      name: 'Web Playback SDK Quick Start Player',
      getOAuthToken: cb => { cb(token); }

    });

    this.spotifyPlayer.addListener('initialization_error', ({ message }) => { console.error(message); });
      this.spotifyPlayer.addListener('authentication_error', ({ message }) => { console.error(message); });
      this.spotifyPlayer.addListener('account_error', ({ message }) => { console.error(message); });
      this.spotifyPlayer.addListener('playback_error', ({ message }) => { console.error(message); });

      this.spotifyPlayer.addListener('player_state_changed', state => { console.log(state); });

      this.spotifyPlayer.addListener('ready', ({ device_id }) => {
        localStorage.setItem('device_Id',device_id);
        console.log('Ready with Device ID', device_id);
      });

      this.spotifyPlayer.addListener('not_ready', ({ device_id }) => {
        console.log('Device ID has gone offline', device_id);
      });

      this.spotifyPlayer.connect();

  }

  ngDoCheck(){

  }

  playSong(){
    let date = new Date(localStorage.getItem('SDK_Token_TimeExpired'))
    let currentDate = new Date();
    if(currentDate >= date)
    {
      console.log('has to be removed');
      localStorage.removeItem('SDK_Token')
      localStorage.removeItem('SDK_Token_TimeExpired');
      this.spotifyService.getToken().subscribe(token=>{
        localStorage.setItem('SDK_Token',token.token);
          let dateTimeString = token.timeExpired.toString();
          localStorage.setItem('SDK_Token_TimeExpired',dateTimeString);
        console.log('token =',token);
      })
    }

    this.http.put('https://api.spotify.com/v1/me/player/play?device_id=' + this.device_Id,JSON.stringify({uris:[this.currentTrack.track.uri]}),{
        headers:{
          'Content-Type': 'application/json',
          'Authorization': `Bearer ${localStorage.getItem('SDK_Token')}`
        }
      }).subscribe(data=>{
        console.log('shoud play right now')

        this.currentTrack.isPlaying = true;
      })
  }

  moveTrack(event){
    event.source.value = event.source.value + 1000;
  }

  togglePlayer(pause){
    console.log('toggle player')
    this.currentTrack.isPlaying = !pause;
    if(pause){
      console.log('pause');
      console.log('THIS SPOTIFY PLAYER = ',this.spotifyPlayer);
      this.spotifyPlayer.pause().then(c=>console.log('paused'));
    }else{
      console.log('play');
      this.spotifyPlayer.resume().then(c=>console.log('paused'));
    }
  }

  changePosition(event){


      event.source.max = this.durationS;
      //this.rangeElement.nativeElement.max = this.currentTrack.track.durationMs;
      console.log('DUrationMs = ',this.currentTrack.track.durationMs);

    if(this.spotifyPlayer)
    {
      this.spotifyPlayer.seek(this.rangeForm.get('range').value*1000).then(()=>{
        console.log('we did it!!!')
        console.log('RANGE value = ',this.rangeForm.get('range').value);
      });
    }


  }

}
