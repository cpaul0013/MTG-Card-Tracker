import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn:'root'
})
export class WantcardsService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
   

  }
  DisplayWantedCards(): any {
    return this.http.get(this.baseUrl + `api/WantCards/wantedcards`);
  }

  AddWantCards(cardId: string, price: number): any {
    return this.http.post(this.baseUrl + `api/WantCards/addWantCards`, {});
  }

  RemoveWantCards(cardId: string): any {
    return this.http.delete(this.baseUrl + `api/WantCards/removeFromWantCards`, {});
  }

  UpdateBuyPrice(cardId: string, price: number): any {
    return this.http.patch(this.baseUrl + `api/WantCards/updateBuyPrice`, {});
  }

  GetCardId(cardId: string): any {
    return this.http.get('https://api.scryfall.com/cards/${cardId}')
  }

}
