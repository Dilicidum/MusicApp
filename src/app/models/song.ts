import { Track } from 'ngx-audio-player';
import { album } from './album';
import { Artist } from './artist';
import { image } from './image';
import { user } from './user';
import { userShortModel } from './userShortModel';

export interface song{
  name?:string;
  views?:number;
  url?:string;
  coverUrl?:string;
  cover?:image;
  track?:Track;
  likes?:number;
  user?:userShortModel;
  SongId?:string;
  //public AlbumDTO Album { get; set; }
  href?:string;
  type?:string;
  trackNumber?:number;
  previewUrl?:string;
  popularity?:number;
  restrictions?:Map<string,string>;
  //public LinkedTrack LinkedFrom { get; set; }
  isPlayable?:boolean;
  uri?:string;
  id?:string;
  externalUrls?:Map<string,string>;
  externalIds?:Map<string,string>
  explicit?:boolean;
  durationMs?:number;
  discNumber?:number;
  artists?:Array<Artist>
  availableMarkets?:Array<string>;
  //public List<SimpleArtist> Artists { get; set; }
  album?:album;
  IsLocal?:boolean;
}
