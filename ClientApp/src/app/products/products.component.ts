import { Component, OnInit } from '@angular/core';
import { Iproduct } from '../shared/iproduct';
import { ProductsService } from '../shared/products.service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  products: Iproduct[];
  errorMessage: string;

  constructor(private productsService: ProductsService) { }

  ngOnInit(): void {
    this.productsService.getProducts().subscribe({
      next: products =>
      {
          this.products = products;
      },
      error: err => this.errorMessage = err
    })
  }

}
