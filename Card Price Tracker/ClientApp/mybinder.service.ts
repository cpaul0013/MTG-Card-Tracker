import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MybinderService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }

  DisplayMyBinder(): any {

    return this.http.get(this.baseUrl + `api/MyBinder/allCards`);
  }

  AddCardToBinder(cardId: string): any {
    return this.http.post(this.baseUrl + `api/MyBinder/addToBinder`, {});
  }

  RemoveCardFromBinder(cardId: string): any {
    return this.http.delete(this.baseUrl + `api/MyBinder/removeFromMyBinder`, {});
  }

  GetCardId(cardId: string): any {
    return this.http.get('https://api.scryfall.com/cards/${cardId}')
  }
}
