import { Artist } from './artist';
import { image } from './image';

export interface album{
    albumGroup?:string;
    albumType?:string;
    artists?:Array<Artist>;
    availableMarkets?:Array<string>;
    externalUrls?:Map<string,string>;
    href?:string;
    id?:string;
    images?:Array<image>;
    name?:string;
    releaseDate?:string;
    releaseDatePrecision?:string;
    restrictions?:Map<string,string>;
    type?:string;
    uri?:string;
}
