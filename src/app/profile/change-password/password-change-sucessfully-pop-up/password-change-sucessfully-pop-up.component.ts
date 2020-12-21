import { Component, OnInit } from '@angular/core';
import {MatDialogRef,MAT_DIALOG_DATA} from '@angular/material/dialog';
@Component({
  selector: 'app-password-change-sucessfully-pop-up',
  templateUrl: './password-change-sucessfully-pop-up.component.html',
  styleUrls: ['./password-change-sucessfully-pop-up.component.css']
})
export class PasswordChangeSucessfullyPopUpComponent implements OnInit {

  constructor(private dialogRef: MatDialogRef<PasswordChangeSucessfullyPopUpComponent>) { }

  ngOnInit(): void {
  }

  close(){
    this.dialogRef.close();
  }



}
