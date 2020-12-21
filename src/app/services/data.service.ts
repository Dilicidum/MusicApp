import { Injectable } from '@angular/core';
import { BehaviorSubject,Subject} from 'rxjs';
import { song } from '../models/song';
import {Howl} from 'howler';
import { currentTrack } from '../models/currentTrack';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private currentTrack:currentTrack = {
    isPlaying : false,
  };
  private dataSubject = new BehaviorSubject(this.currentTrack);
  data = this.dataSubject.asObservable();
  constructor() { }

  changeData(currentTrack:currentTrack){
    this.dataSubject.next(currentTrack);
  }

}
