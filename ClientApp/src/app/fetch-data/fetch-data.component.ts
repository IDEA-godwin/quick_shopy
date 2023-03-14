import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {

  public products: Product[] = [];


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    console.log(baseUrl)
    http.get<Product[]>(baseUrl + 'api/products').subscribe(result => {
      this.products = result;
    }, error => console.error(error));
  }
}

interface Product {
  name: string;
  price: string;
  description: string;
  itemCode: string;
  quantityInStock: number
}
