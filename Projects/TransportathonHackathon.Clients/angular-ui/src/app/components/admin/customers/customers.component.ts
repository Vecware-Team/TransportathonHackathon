import { Component, OnInit } from '@angular/core';
import { Paginate } from 'src/app/core/models/pagination/paginate';
import { GetListCustomerResponse } from 'src/app/models/response-models/customers/getListCustomerResponse';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css'],
})
export class CustomersComponent implements OnInit {
  customers: Paginate<GetListCustomerResponse>;

  constructor(private customerService: CustomerService) {}
  ngOnInit(): void {
    this.getList();
  }

  getList() {
    this.customerService
      .getList()
      .subscribe((response) => (this.customers = response));
  }
}
