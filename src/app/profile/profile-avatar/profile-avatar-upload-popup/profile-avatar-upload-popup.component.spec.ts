import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProfileAvatarUploadPopupComponent } from './profile-avatar-upload-popup.component';

describe('ProfileAvatarUploadPopupComponent', () => {
  let component: ProfileAvatarUploadPopupComponent;
  let fixture: ComponentFixture<ProfileAvatarUploadPopupComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProfileAvatarUploadPopupComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProfileAvatarUploadPopupComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
