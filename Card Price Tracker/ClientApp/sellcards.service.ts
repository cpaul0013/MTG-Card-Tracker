import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
}
)
export class SellcardsService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }
  DisplaySellCards(): any {

    return this.http.get(this.baseUrl + `api/SellCards/allSellCards`);
  }

  GetById(): any {
    return this.http.get(this.baseUrl + `api/SellCards/cardById`);
  }

  AddSellCards(cardId: string, price: number): any {
    return this.http.post(this.baseUrl + `api/SellCards/addSellCards`, {});
  }

  RemoveSellCards(cardId: string): any {
    return this.http.delete(this.baseUrl + `api/SellCards/removeFromSellCards`, {});
  }

  UpdateSellPrice(cardId: string, price: number): any {
    return this.http.patch(this.baseUrl + `api/SellCards/updateSellPrice`, {});
  }

  GetCardId(cardId: string): any {
    return this.http.get('https://api.scryfall.com/cards/${cardId}')
  }


}
