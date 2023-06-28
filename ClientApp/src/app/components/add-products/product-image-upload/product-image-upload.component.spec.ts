import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductImageUploadComponent } from './product-image-upload.component';

describe('ProductImageUploadComponent', () => {
  let component: ProductImageUploadComponent;
  let fixture: ComponentFixture<ProductImageUploadComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProductImageUploadComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ProductImageUploadComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
