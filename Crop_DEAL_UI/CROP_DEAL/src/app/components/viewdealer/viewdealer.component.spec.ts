import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewdealerComponent } from './viewdealer.component';

describe('ViewdealerComponent', () => {
  let component: ViewdealerComponent;
  let fixture: ComponentFixture<ViewdealerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ViewdealerComponent]
    });
    fixture = TestBed.createComponent(ViewdealerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
