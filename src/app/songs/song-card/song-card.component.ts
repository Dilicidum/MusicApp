import { Component, OnInit, Input, ViewChild, ComponentFactoryResolver, ComponentFactory, ViewContainerRef, ComponentRef, OnChanges, SimpleChanges, ɵSWITCH_RENDERER2_FACTORY__POST_R3__, DoCheck, KeyValueDiffers } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DomSanitizer, SafeUrl } from '@angular/platform-browser';
import { BlobGenerator } from 'src/app/helpers/Blob.Generator';
import { song } from 'src/app/models/song';
import { SongService } from 'src/app/services/song.service';
import { SongControlPanelComponent } from '../song-control-panel/song-control-panel.component';
import {Howl} from 'howler';
import { Track } from 'ngx-audio-player';
import { DataService } from 'src/app/services/data.service';
@Component({
  selector: 'app-song-card',
  templateUrl: './song-card.component.html',
  styleUrls: ['./song-card.component.css']
})
export class SongCardComponent implements OnInit,DoCheck {
  @Input('song')song:song;
  @ViewChild('songControlPanel',{read:ViewContainerRef})container:ViewContainerRef;
  songContolPanelElement:ComponentRef<SongControlPanelComponent>
  dynamicComponent : ComponentRef<SongControlPanelComponent>;
  player:Howl;
  activeTrack:Track ={
    link:'',
    title:'',
  };
  isPlaying = false;

  constructor(private sanitazer:DomSanitizer,private blobUrlGenerator:BlobGenerator
    ,private vf:ViewContainerRef,private resolver : ComponentFactoryResolver,private songService:SongService,
    private differs:KeyValueDiffers,private data:DataService)
  { }

  ngOnInit(): void {
    this.songService.getSongFileById(15).subscribe(data=>{

      this.song.url = data.url;
      this.song.track = new Track;
      this.song.track.link = this.song.url;
      this.song.track.title = this.song.name;
      console.log('song = ',this.song)
    })

  }

  ngDoCheck(){
    let changes = this.differs.find(this.song);
    if(changes && this.song.id!==undefined && this.song.url == null){
      console.log('changes detected');

    }

  }

  currentTrack:Track;

  playSong(track:Track){

    //let resolver = this.resolver.resolveComponentFactory(SongControlPanelComponent);
    //this.container.clear();
    //this.songContolPanelElement = this.container.createComponent(resolver);
    if(this.player){
      console.log('player stop');
      this.player.stop();
    }
    console.log('define new player');

    this.player = new Howl({
      src:[track.link],
      format:['mp3'],
      onplay:()=>{
        this.isPlaying = true;
        this.activeTrack = track;
      },
      onend:()=>{

      }
    })
    this.isPlaying = true;
    this.player.play();

    // this.songContolPanelElement.instance.song = this.song;
    // this.songContolPanelElement.instance.player = this.player;
    // this.songContolPanelElement.instance.isPlaying = this.isPlaying;
  }



}
