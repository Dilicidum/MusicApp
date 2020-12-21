import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SongControlPanelComponent } from './song-control-panel.component';

describe('SongControlPanelComponent', () => {
  let component: SongControlPanelComponent;
  let fixture: ComponentFixture<SongControlPanelComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SongControlPanelComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SongControlPanelComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
