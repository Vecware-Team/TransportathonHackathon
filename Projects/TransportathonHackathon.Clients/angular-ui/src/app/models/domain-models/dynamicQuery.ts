import { Filter } from "./filter";
import { Sort } from "./sort";


export interface DynamicQuery {
  sort: Sort[] | null;
  filter: Filter | null;
}
