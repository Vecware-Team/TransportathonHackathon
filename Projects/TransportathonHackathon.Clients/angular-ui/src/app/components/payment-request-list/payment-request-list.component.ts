import { Component, OnInit } from '@angular/core';
import { TokenUserDto } from 'src/app/models/dtos/tokenUserDto';
import { GetByCustomerIdPaymentRequestResponse } from 'src/app/models/response-models/payment-request/getByCustomerIdPaymentRequestResponse';
import { PaymentRequestService } from 'src/app/services/payment-request.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-payment-request-list',
  templateUrl: './payment-request-list.component.html',
  styleUrls: ['./payment-request-list.component.css'],
})
export class PaymentRequestListComponent implements OnInit {
  paymentRequests: GetByCustomerIdPaymentRequestResponse[];
  customer: TokenUserDto;

  constructor(
    private tokenService: TokenService,
    private paymentRequestService: PaymentRequestService
  ) {}

  ngOnInit(): void {
    this.getCustomer();
    this.getList();
  }

  getCustomer() {
    this.customer = this.tokenService.getUserWithJWT()!;
  }

  getList() {
    this.paymentRequestService
      .getListByCustomerId({
        customerId: this.customer.id,
      })
      .subscribe((response) => {
        this.paymentRequests = response;
      });
  }
}
