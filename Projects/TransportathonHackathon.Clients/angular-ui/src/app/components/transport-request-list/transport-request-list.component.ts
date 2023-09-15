import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Paginate } from 'src/app/core/models/pagination/paginate';
import { TokenUserDto } from 'src/app/models/dtos/tokenUserDto';
import { GetByCustomerIdPaymentRequestResponse } from 'src/app/models/response-models/payment-request/getByCustomerIdPaymentRequestResponse';
import { GetByCustomerIdTransportRequestResponse } from 'src/app/models/response-models/transport-requests/getByCustomerIdTransportRequestResponse';
import { PaymentRequestService } from 'src/app/services/payment-request.service';
import { TokenService } from 'src/app/services/token.service';
import { TransportRequestService } from 'src/app/services/transport-request.service';
import { PayTransportRequestComponent } from './pay-transport-request/pay-transport-request.component';
import { RejectTransportRequestComponent } from './reject-transport-request/reject-transport-request.component';
import { Router } from '@angular/router';

@Component({
  selector: 'app-transport-request-list',
  templateUrl: './transport-request-list.component.html',
  styleUrls: ['./transport-request-list.component.css'],
})
export class TransportRequestListComponent implements OnInit {
  transportRequests: GetByCustomerIdTransportRequestResponse[];
  customer: TokenUserDto;
  paymentRequests: Paginate<GetByCustomerIdPaymentRequestResponse>;

  constructor(
    private transportRequestService: TransportRequestService,
    private tokenService: TokenService,
    private paymentRequestService: PaymentRequestService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getCustomer();
    this.getList();
    this.getPaymentRequestList();
  }

  getCustomer() {
    this.customer = this.tokenService.getUserWithJWT()!;
  }

  getPaymentRequestByTransportRequest(
    transportRequest: GetByCustomerIdTransportRequestResponse
  ): GetByCustomerIdPaymentRequestResponse | undefined {
    return this.paymentRequests.items.find(
      (p) => p.transportRequestId === transportRequest.id
    );
  }

  pay(transportRequest: GetByCustomerIdTransportRequestResponse) {
    this.router.navigate([
      '/transport-requests/payment/' + transportRequest.id,
    ]);
  }

  reject(transportRequest: GetByCustomerIdTransportRequestResponse) {
    this.router.navigate([
      '/transport-requests/reject/' + transportRequest.id,
    ]);
  }

  getList() {
    this.transportRequestService
      .getListByCustomerId({ customerId: this.customer.id })
      .subscribe((response) => {
        this.transportRequests = response;
      });
  }

  getPaymentRequestList() {
    this.paymentRequestService
      .getListByCustomerId({ customerId: this.customer.id })
      .subscribe((response) => {
        this.paymentRequests = response;
      });
  }
}
