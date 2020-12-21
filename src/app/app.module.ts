import {BrowserModule} from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {RouterModule} from '@angular/router';
import { AppComponent } from './app.component';
import {ReactiveFormsModule} from '@angular/forms';
import { LoginComponent } from './login/login.component';
import {routes} from '../app/routes';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import { NavigationMenuComponent } from './navigation-menu/navigation-menu.component';
import { HomeComponent } from './home/home.component';
import { AddMusicComponent } from './add-music/add-music.component';
import { PlaylistsComponent } from './playlists/playlists.component';
import { RegistrationComponent } from './registration/registration.component';
import { DeepSearchComponent } from './deep-search/deep-search.component';
import { ProfileComponent } from './profile/profile.component';
import {BlueColorOnClickInputDirective} from '../app/directives/blue-color-on-click-input.directive';
import {CookieService} from 'ngx-cookie-service';
import { ProfileSettingsComponent } from './profile/profile-settings/profile-settings.component';
import { ProfileNavMenuComponent } from './profile/profile-nav-menu/profile-nav-menu.component';
import { ProfileAvatarComponent } from './profile/profile-avatar/profile-avatar.component';
import { ProfileAvatarUploadPopupComponent } from './profile/profile-avatar/profile-avatar-upload-popup/profile-avatar-upload-popup.component'
import {MatDialogModule,} from '@angular/material/dialog';
import {MatButtonModule} from '@angular/material/button'
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import { JwtModule, JwtHelperService } from '@auth0/angular-jwt';
import { ChangePasswordComponent } from './profile/change-password/change-password.component';
import { httpInterceptors } from './interceptors';
import { ValidateHelperComponent } from './validate-helper/validate-helper.component';
import { PasswordChangeSucessfullyPopUpComponent } from './profile/change-password/password-change-sucessfully-pop-up/password-change-sucessfully-pop-up.component';
import { GenresDynamicComponent } from './genres-dynamic/genres-dynamic.component';
import { LocationStrategy, HashLocationStrategy, APP_BASE_HREF } from '@angular/common';
import { SongCardComponent } from './songs/song-card/song-card.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { PasswordResetComponent } from './password-reset/password-reset.component';
import { ForgetPasswordSucessfullComponent } from './notifications/forget-password-sucessfull/forget-password-sucessfull.component';
import { BlobGenerator } from './helpers/Blob.Generator';
import { SongControlPanelComponent } from './songs/song-control-panel/song-control-panel.component';
import {NgxAudioPlayerModule} from 'ngx-audio-player';
import { Howl, Howler } from 'howler';
import { SearchComponent } from './search/search.component';
import { ShortViewTrackComponent } from './short-view-track/short-view-track.component';
import { MatSliderModule } from '@angular/material/slider';
import {MatCardModule} from '@angular/material/card';
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    NavigationMenuComponent,
    HomeComponent,
    AddMusicComponent,
    PlaylistsComponent,
    RegistrationComponent,
    DeepSearchComponent,
    ProfileComponent,
    BlueColorOnClickInputDirective,
    ProfileSettingsComponent,
    ProfileNavMenuComponent,
    ProfileAvatarComponent,
    ProfileAvatarUploadPopupComponent,
    ChangePasswordComponent,
    ValidateHelperComponent,
    PasswordChangeSucessfullyPopUpComponent,
    GenresDynamicComponent,
    SongCardComponent,
    ForgotPasswordComponent,
    PasswordResetComponent,
    ForgetPasswordSucessfullComponent,
    SongControlPanelComponent,
    SearchComponent,
    ShortViewTrackComponent,

  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes,{
      onSameUrlNavigation:'reload'
    }),
    ReactiveFormsModule,
    MatCardModule,
    HttpClientModule,
    MatDialogModule,
    NgxAudioPlayerModule,
    MatButtonModule,
    BrowserAnimationsModule,
    MatSliderModule,
    JwtModule.forRoot({

      config:{
        tokenGetter:()=>{
          return localStorage.getItem('token');
        },
        allowedDomains:['localhost'],
      }
    })
  ],
  providers: [
    JwtHelperService,
    CookieService,
    httpInterceptors,
    BlobGenerator,

  ],
  entryComponents:[
    ProfileAvatarUploadPopupComponent,
    Howl,

  ],

  bootstrap: [AppComponent]
})
export class AppModule { }
