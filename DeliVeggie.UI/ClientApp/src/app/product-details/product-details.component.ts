import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ProductService } from '../product.service';
import { IProduct } from '../interfaces/IProduct';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrl: './product-details.component.scss',
})
export class ProductDetailsComponent {
  constructor(
    private route: ActivatedRoute,
    private productService: ProductService
  ) {}

  product: IProduct = {} as IProduct;

  ngOnInit(): void {
    const routeParams = this.route.snapshot.paramMap;
    const productIdFromRoute = String(routeParams.get('productId'));

    this.productService.getItemById(productIdFromRoute).subscribe(
      (response) =>
        (this.product = {
          id: response.id,
          name: response.name,
          entryDate: response.entryDate,
          price: response.price,
        }),
      (error) => {
        console.error('Failed to load products', error);
      }
    );
  }
}
