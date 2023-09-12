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
  customers: Paginate<GetListCustomerResponse>;

  constructor(private customerService: CustomerService) {}
  ngOnInit(): void {
    this.getList();
  }

getPageCounts():number[]{
  return Array.from(Array(this.customers.count).keys())
}

  getList() {
    let a=Array.from(Array(this.customers.count).keys())
    this.dataLoaded = false;
    this.customerService.getList().subscribe((response) => {
      this.customers = response;
      this.dataLoaded = true;
    });
  }
}
