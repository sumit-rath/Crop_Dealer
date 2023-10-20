import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCropComponent } from './add-crop.component';

describe('AddCropComponent', () => {
  let component: AddCropComponent;
  let fixture: ComponentFixture<AddCropComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [AddCropComponent]
    });
    fixture = TestBed.createComponent(AddCropComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
