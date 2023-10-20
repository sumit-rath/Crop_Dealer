import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FamerpageComponent } from './famerpage.component';

describe('FamerpageComponent', () => {
  let component: FamerpageComponent;
  let fixture: ComponentFixture<FamerpageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FamerpageComponent]
    });
    fixture = TestBed.createComponent(FamerpageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
