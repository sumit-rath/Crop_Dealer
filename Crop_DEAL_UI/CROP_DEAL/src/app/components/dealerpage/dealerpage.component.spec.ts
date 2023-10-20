import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DealerpageComponent } from './dealerpage.component';

describe('DealerpageComponent', () => {
  let component: DealerpageComponent;
  let fixture: ComponentFixture<DealerpageComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DealerpageComponent]
    });
    fixture = TestBed.createComponent(DealerpageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
