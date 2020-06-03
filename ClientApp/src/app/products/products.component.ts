import { Component, OnInit } from '@angular/core';
import { Iproduct } from '../shared/iproduct';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent implements OnInit {
  products: Iproduct[];
  constructor() { }

  ngOnInit() {
  }

}
