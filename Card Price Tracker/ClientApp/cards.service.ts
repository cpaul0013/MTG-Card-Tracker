import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';

@Injectable()
export class CardsService {
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) {

  }

  CardSearch(cardName: string): any {
    return this.http.get('https://api.scryfall.com/cards/named?fuzzy=' + cardName)

  }
  
  GetCardId(cardId: string): any {
    return this.http.get('https://api.scryfall.com/cards/${cardId}')
  }
}
