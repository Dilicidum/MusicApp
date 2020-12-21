import { genre } from './genre';

export interface songUploadModel{
  files?:FormData;
  songName?:string;
  artist?:string;
  year?:number;
  genres?:genre[];
  cover?:FormData;
  song?:FormData;
}
