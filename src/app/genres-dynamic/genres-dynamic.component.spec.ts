import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GenresDynamicComponent } from './genres-dynamic.component';

describe('GenresDynamicComponent', () => {
  let component: GenresDynamicComponent;
  let fixture: ComponentFixture<GenresDynamicComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GenresDynamicComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GenresDynamicComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
