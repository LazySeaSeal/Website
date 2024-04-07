import { Component, Input } from '@angular/core';
import { BasketService } from 'app/basket/basket.service';
import { Product } from 'app/shared/models/product';

@Component({
  selector: 'app-product-item',
  templateUrl: './product-item.component.html',
  styleUrls: ['./product-item.component.scss']
})
export class ProductItemComponent {

  @Input() product?: Product;

  constructor(private basketService: BasketService) {}
  addItemToBasket() {
    this.product && this.basketService.addItemToBasket(this.product);
  }


}
