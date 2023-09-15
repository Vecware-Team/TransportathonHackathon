import { Component, OnInit } from '@angular/core';
import { TokenUserDto } from 'src/app/models/dtos/tokenUserDto';
import { GetByCustomerIdTransportRequestResponse } from 'src/app/models/response-models/transport-requests/getByCustomerIdTransportRequestResponse';
import { TokenService } from 'src/app/services/token.service';
import { TransportRequestService } from 'src/app/services/transport-request.service';

@Component({
  selector: 'app-transport-request-list',
  templateUrl: './transport-request-list.component.html',
  styleUrls: ['./transport-request-list.component.css'],
})
export class TransportRequestListComponent implements OnInit {
  transportRequests: GetByCustomerIdTransportRequestResponse[];
  customer: TokenUserDto;

  constructor(
    private transportRequestService: TransportRequestService,
    private tokenService: TokenService
  ) {}

  ngOnInit(): void {
    this.getCustomer();
    this.getList();
  }

  getCustomer() {
    this.customer = this.tokenService.getUserWithJWT()!;
  }

  getList() {
    this.transportRequestService
      .getListByCustomerId({ customerId: this.customer.id })
      .subscribe((response) => {
        this.transportRequests = response;
      });
  }

  
}
