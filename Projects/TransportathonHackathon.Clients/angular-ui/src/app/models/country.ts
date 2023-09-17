import { City } from './city';

export interface Country {
  id: number;
  name: string;
  iso2: string;
  cities: City[];
}
