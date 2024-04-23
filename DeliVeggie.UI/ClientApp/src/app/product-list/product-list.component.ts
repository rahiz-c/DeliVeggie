import { Component } from '@angular/core';
import { IProduct } from '../interfaces/IProduct';
import { ProductService } from '../product.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrl: './product-list.component.scss',
})
export class ProductListComponent {
  productList: IProduct[] = [];

  constructor(private productService: ProductService) {}

  ngOnInit(): void {
    this.productService.getItems(0, 10).subscribe(
      (products) => {
        this.productList = products;
      },
      (error) => {
        console.error('Failed to load products', error);
      }
    );
  }
}
