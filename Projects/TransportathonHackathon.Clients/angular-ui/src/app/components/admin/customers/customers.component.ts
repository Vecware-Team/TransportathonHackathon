import { Component, OnInit } from '@angular/core';
import { faRedoAlt } from '@fortawesome/free-solid-svg-icons';
import { Paginate } from 'src/app/core/models/pagination/paginate';
import { GetListCustomerResponse } from 'src/app/models/response-models/customers/getListCustomerResponse';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css'],
})
export class CustomersComponent implements OnInit {
  faRedoAlt = faRedoAlt;
  dataLoaded = false;
  customers: Paginate<GetListCustomerResponse> = {} as Paginate<GetListCustomerResponse>;
  index = 0;
  size = 10;

  constructor(private customerService: CustomerService) { }
  ngOnInit(): void {
    this.getList();
  }

  getPageCounts(): number[] {
    let array: number[] = [];

    for (let index = 0; index < this.customers.pages; index++) {
      array.push(index + 1);
    }
    return array;
  }

  getList() {
    this.dataLoaded = false;
    this.customerService
      .getList({ index: this.index, size: this.size })
      .subscribe((response) => {
        this.customers = response;
        this.dataLoaded = true;
      });
  }

  getPage(page: number) {
    if (page > 0 || page <= this.customers.pages) {

      this.index = page - 1;
      this.getList();
    }
  }

  getPreviousPage() {
    if (this.customers.hasPrevious) {
      this.index = this.index - 1;
      this.getList();
    }
  }

  getNextPage() {
    if (this.customers.hasNext) {
      this.index = this.index + 1;
      this.getList();
    }
  }

  changeSize(size: number) {
    this.size = size
  }
}
