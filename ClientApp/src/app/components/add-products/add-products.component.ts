import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { IProduct, Product } from 'src/app/models/products';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-add-products',
  templateUrl: './add-products.component.html',
  styleUrls: ['./add-products.component.css']
})
export class AddProductsComponent implements OnInit {

  search: FormControl;
  productForm: FormGroup;

  savingProduct = false;
  formErr = false;
  products: Product[] = [];
  loadingProducts = true;

  constructor(
    private productService: ProductsService,
    private fb: FormBuilder
  ) {
    this.search = new FormControl('');

    this.productForm = fb.group({
      name: ["", Validators.required],
      description: ["", Validators.maxLength(100)],
      price: ["", Validators.required],
      itemCode: ["", Validators.required],
      quantityInStock: [1]
    });
  }

  ngOnInit(): void {
    this.getProducts();
  }

  getProducts() {
    this.productService.getProducts().subscribe(
      result => {
        this.products = result;
        this.loadingProducts = false;
      },
      error => {
        this.loadingProducts = false;
      }
    );
  }

  addNewProduct() {
    this.savingProduct = true;
    if (!this.productForm.valid) {
      this.formErr = true;
    }
    this.productService.addProduct(this.buildProductPayload())
      .subscribe(result => {
        this.productForm.reset();
        this.savingProduct = false;
        console.log(result);
      });
  }

  buildProductPayload(): IProduct {
    return this.productForm.getRawValue();
  }

}
