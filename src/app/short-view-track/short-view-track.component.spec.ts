import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ShortViewTrackComponent } from './short-view-track.component';

describe('ShortViewTrackComponent', () => {
  let component: ShortViewTrackComponent;
  let fixture: ComponentFixture<ShortViewTrackComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ShortViewTrackComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ShortViewTrackComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
