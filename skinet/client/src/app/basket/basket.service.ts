import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Basket } from 'app/shared/models/basket';
import { environment } from 'environments/environment';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  baseUrl= environment.apiUrl;
  private basketSource = new BehaviorSubject<Basket | null>(null);
  basketSource$ = this.basketSource.asObservable();

  constructor(private http:HttpClient) { }
  getBasket(id:string){
    return this.http.get<Basket>(this.baseUrl+'basket?id='+id).subscribe({
      next: basket =>this.basketSource.next(basket)
    })
  }
  setBasket(basket: Basket){
    return this.http.post<Basket>(this.baseUrl + 'basket',basket).subscribe({
      next: basket =>this.basketSource.next(basket)
    })
  }
  getCurrentBaskettValue() {
    return this.basketSource.value;
  }


}
