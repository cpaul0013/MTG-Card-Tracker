export interface Cards {
  Id: string;
  Oracle_Id: string;
  Multiverse_ids: number[];
  Mtgo_id: number;
  Mtgo_foil_id: number;
  Tcgplayer_id: number;
  Cardmarket_id: number;
  Name: string;
  Lang: string;
  Released_at: string;
  Uri: string;
  Scryfall_uri: string;
  Layout: string;
  Highres_image: boolean;
  Image_status: string;
  Imagestring: Image_Uris[];
  Mana_cost: string;
  Cmc: string;
  Type_line: string;
  Oracletext: string;
  Power: string;
  Toughness: string;
  Colors: string[];
  Coloridentity: string[];
  Keywords: string[];
  Games: string;
  Reserved: boolean;
  Foil: boolean;
  Nonfoil: boolean;
  Finishes: boolean;
  Oversized: boolean;
  Promo: boolean;
  Rarity: string;
  Prices: Prices[];



}
export interface Image_Uris {
  small: string;
  normal: string;
  large: string;

}

export interface Prices {
  usd: number;
  tix: number;

}
