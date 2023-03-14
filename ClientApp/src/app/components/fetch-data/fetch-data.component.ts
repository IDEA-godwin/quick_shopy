import { Component, Inject } from '@angular/core';
import { Product } from 'src/app/models/products';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {

  public products: Product[] = [];


  constructor(
    private productService: ProductsService

  ) {
    productService.getProducts().subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }
}


