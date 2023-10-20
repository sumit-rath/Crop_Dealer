import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewfarmerComponent } from './viewfarmer.component';

describe('ViewfarmerComponent', () => {
  let component: ViewfarmerComponent;
  let fixture: ComponentFixture<ViewfarmerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewfarmerComponent]
    });
    fixture = TestBed.createComponent(ViewfarmerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
