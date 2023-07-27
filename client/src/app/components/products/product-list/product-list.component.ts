import { Component, OnInit } from '@angular/core';
import { IProduct } from 'src/app/models/product';
import { ProductsService } from 'src/app/services/products.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {

  products: IProduct[] = [];

  constructor(private productService: ProductsService) { }

  ngOnInit(): void {
    this.productService.GetProducts().subscribe(
      (data: IProduct[]) => {
        this.products = data;
        console.log(this.products);
      },
      (error) => {
        console.error('Ocorreu um erro:', error);
      },
      () => {
        console.log('Consulta de produtos concluída.');
      }
    );
  }
}