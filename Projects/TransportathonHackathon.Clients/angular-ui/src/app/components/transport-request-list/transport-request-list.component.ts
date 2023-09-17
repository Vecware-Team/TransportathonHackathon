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
import { Router } from '@angular/router';
import { CloseTransportRequestComponent } from './close-transport-request/close-transport-request.component';
import { faCheck } from '@fortawesome/free-solid-svg-icons';
import { FinishTransportRequestComponent } from './finish-transport-request/finish-transport-request.component';
import { CommentStoreService } from 'src/app/services/store-services/comment-store.service';
import { VehicleService } from 'src/app/services/vehicle.service';

@Component({
  selector: 'app-transport-request-list',
  templateUrl: './transport-request-list.component.html',
  styleUrls: ['./transport-request-list.component.css'],
})
export class TransportRequestListComponent implements OnInit {
  faCheck = faCheck;
  transportRequests: GetByCustomerIdTransportRequestResponse[];
  customer: TokenUserDto;

  constructor(
    private transportRequestService: TransportRequestService,
    private tokenService: TokenService,
    private paymentRequestService: PaymentRequestService,
    private router: Router,
    private modalService: NgbModal,
  ) {}

  ngOnInit(): void {
    this.getCustomer();
    this.getList();
  }

  getCustomer() {
    this.customer = this.tokenService.getUserWithJWT()!;
  }

  getApprovedText(isApproved: boolean | null) {
    if (isApproved == null) return 'Waiting for approve';

    if (isApproved) {
      return 'approved';
    }
    return 'rejected';
  }

  getIsPaidText(isPaid: boolean) {
    if (isPaid) {
      return 'isPaid';
    }
    return 'isWaiting';
  }

  finish(transportRequest: GetByCustomerIdTransportRequestResponse) {
    var modalReferance = this.modalService.open(
      FinishTransportRequestComponent,
      {
        size: 'm',
        modalDialogClass: 'modal-dialog-centered',
      }
    );

    modalReferance.closed.subscribe({
      next: () => {
        this.getList();
      },
    });
    modalReferance.componentInstance.transportRequest = transportRequest;
  }

  pay(transportRequest: GetByCustomerIdTransportRequestResponse) {
    this.router.navigate([
      '/transport-requests/payment/' + transportRequest.id,
    ]);
  }

  reject(transportRequest: GetByCustomerIdTransportRequestResponse) {
    var modalReferance = this.modalService.open(
      CloseTransportRequestComponent,
      {
        size: 'm',
        modalDialogClass: 'modal-dialog-centered',
      }
    );

    modalReferance.closed.subscribe({
      next: () => {
        this.getList();
      },
    });
    modalReferance.componentInstance.transportRequest = transportRequest;
  }

  getList() {
    this.transportRequestService
      .getListByCustomerId({ customerId: this.customer.id })
      .subscribe((response) => {
        this.transportRequests = response;
      });
  }
}
