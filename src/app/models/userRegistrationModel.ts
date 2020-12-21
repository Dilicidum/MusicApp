import { genre } from './genre';

export interface userRegistrationModel {
  firstName?:string;
  lastName?:string;
  userName?:string;
  email?:string;
  password?:string;
  confirmedPassword?:string;
  genres?:genre[];
  dateOfBirth?:Date;
}
