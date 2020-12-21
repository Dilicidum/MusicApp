import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { JwtInterceptor } from './helpers/jwt.interceptor';
import { SpotifyTokenInterceptor } from './helpers/spotifyToken.interceptor';

export const httpInterceptors = [
    {provide:HTTP_INTERCEPTORS, useClass:JwtInterceptor,multi:true},
    //{provide:HTTP_INTERCEPTORS,useClass:SpotifyTokenInterceptor,multi:true}
]
