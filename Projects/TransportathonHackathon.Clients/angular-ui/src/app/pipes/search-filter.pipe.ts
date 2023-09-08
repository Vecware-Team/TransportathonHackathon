import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'searchFilter',
})
export class SearchFilterPipe<T> implements PipeTransform {
  transform(value: T[], searchText: string): T[] {
    return value;
  }
}
