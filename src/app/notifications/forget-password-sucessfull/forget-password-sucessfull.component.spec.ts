import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ForgetPasswordSucessfullComponent } from './forget-password-sucessfull.component';

describe('ForgetPasswordSucessfullComponent', () => {
  let component: ForgetPasswordSucessfullComponent;
  let fixture: ComponentFixture<ForgetPasswordSucessfullComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ForgetPasswordSucessfullComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ForgetPasswordSucessfullComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
