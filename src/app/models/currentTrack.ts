import { Howl } from 'howler';
import { Track } from 'ngx-audio-player';
import { song } from './song';

export interface currentTrack{
  isPlaying:boolean;
  player?:Howl;
  track?:song;
}
