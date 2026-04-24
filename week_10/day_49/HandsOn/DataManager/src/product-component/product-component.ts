import { Component } from '@angular/core';
import { Product } from '../models/Product';
import { DataManager } from '../Services/service';
import { getFirstElement } from '../generic/genericFunction';

@Component({
  selector: 'app-product-component',
  imports: [],
  templateUrl: './product-component.html',
  styleUrl: './product-component.css',
})
export class ProductComponent {
  private ProductManager = new DataManager<Product>();

  ngOnInit(): void {
    this.ProductManager.add({ id: 101, title: 'Laptop' });
    this.ProductManager.add({ id: 102, title: 'Mobile' });

    const products = this.ProductManager.getAll();

    console.log('Products : ', products);
    console.log('First Product :', getFirstElement(products));
  }
}
