import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { GetByIdCustomerResponse } from 'src/app/models/response-models/customers/getByIdCustomerResponse';
import { CustomerService } from 'src/app/services/customer.service';

@Component({
  selector: 'app-customer-details',
  templateUrl: './customer-details.component.html',
  styleUrls: ['./customer-details.component.css'],
})
export class CustomerDetailsComponent implements OnInit {
  customer: GetByIdCustomerResponse;
  
  constructor(
    private activatedRoute: ActivatedRoute,
    private customerService: CustomerService
  ) {}

  ngOnInit(): void {
    this.subscribeRoute();
  }

  subscribeRoute() {
    this.getCustomer(this.activatedRoute.snapshot.params['customerId']);
  }

  getCustomer(id: string) {
    this.customerService.getById({ appUserId: id }).subscribe((response) => {
      this.customer = response;
    });
  }
}
