import {Routes} from '@angular/router';
import { LoginComponent } from './login/login.component';
import { HomeComponent } from './home/home.component';
import { AddMusicComponent } from './add-music/add-music.component';
import { PlaylistsComponent } from './playlists/playlists.component';
import { RegistrationComponent } from './registration/registration.component';
import { DeepSearchComponent } from './deep-search/deep-search.component';
import { ProfileComponent } from './profile/profile.component';
import { ProfileSettingsComponent } from './profile/profile-settings/profile-settings.component';
import { ChangePasswordComponent } from './profile/change-password/change-password.component';
import { AuthGuard } from './helpers/auth.guard';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { PasswordResetComponent } from './password-reset/password-reset.component';
import { SearchComponent } from './search/search.component';
export const routes:Routes = [
  {component:LoginComponent,path:'Login',children:[]},
  {path:'', component:HomeComponent},
  {path:'ForgetPassword',component:ForgotPasswordComponent},
  {path:'Registration',component:RegistrationComponent},
  {path:'ResetPassword',component:PasswordResetComponent},
  {path:'Deep-Search',component:DeepSearchComponent },
  {path:'Playlists',component:PlaylistsComponent,canActivate:[AuthGuard]},
  {path:'Profile',component:ProfileComponent,canActivate:[AuthGuard],children:[
    {path:'Settings',component:ProfileSettingsComponent},
    {path:'Song/Add',component:AddMusicComponent},
    {path:'Password/Change',component:ChangePasswordComponent},
  ]},
  {path:'Search',component:SearchComponent},
  {path:'**',redirectTo:''}
]
