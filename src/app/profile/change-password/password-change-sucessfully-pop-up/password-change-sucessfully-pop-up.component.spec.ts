import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PasswordChangeSucessfullyPopUpComponent } from './password-change-sucessfully-pop-up.component';

describe('PasswordChangeSucessfullyPopUpComponent', () => {
  let component: PasswordChangeSucessfullyPopUpComponent;
  let fixture: ComponentFixture<PasswordChangeSucessfullyPopUpComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PasswordChangeSucessfullyPopUpComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PasswordChangeSucessfullyPopUpComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
