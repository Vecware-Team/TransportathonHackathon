<<<<<<< Updated upstream
import { Component, OnInit } from '@angular/core';
import {
  faCircleCheck,
  faCircleXmark,
  faClock,
  faRedoAlt,
} from '@fortawesome/free-solid-svg-icons';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { GetByCompanyIdTransportRequestRequest } from 'src/app/models/request-models/transport-requests/getByCompanyIdTransportRequestRequest';
=======
import { Component } from '@angular/core';
import { faEdit, faRedoAlt, faTrash } from '@fortawesome/free-solid-svg-icons';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
>>>>>>> Stashed changes
import { GetByIdCompanyResponse } from 'src/app/models/response-models/companies/getByIdCompanyResponse';
import { GetByCompanyIdTransportRequestResponse } from 'src/app/models/response-models/transport-requests/getByCompanyIdTransportRequestResponse';
import { CompanyService } from 'src/app/services/company.service';
import { TokenService } from 'src/app/services/token.service';
import { TransportRequestService } from 'src/app/services/transport-request.service';
<<<<<<< Updated upstream
import { ApproveTransportRequestComponent } from './approve-transport-request/approve-transport-request.component';
import { RejectTransportRequestComponent } from './reject-transport-request/reject-transport-request.component';
import { PaymentRequestService } from 'src/app/services/payment-request.service';
import { GetByIdPaymentRequestResponse } from 'src/app/models/response-models/payment-request/getByIdPaymentRequestResponse';
import { TransportRequestInfoComponent } from './transport-request-info/transport-request-info.component';
=======
>>>>>>> Stashed changes

@Component({
  selector: 'app-transport-requests',
  templateUrl: './transport-requests.component.html',
  styleUrls: ['./transport-requests.component.css'],
})
<<<<<<< Updated upstream
export class TransportRequestsComponent implements OnInit {
  faRedoAlt = faRedoAlt;
  faCircleCheck = faCircleCheck;
  faCircleXMark = faCircleXmark;
  faClock = faClock;
=======
export class TransportRequestsComponent {
  faRedoAlt = faRedoAlt;
  faTrash = faTrash;
  faEdit = faEdit;
>>>>>>> Stashed changes
  dataLoaded = false;
  transportRequests: GetByCompanyIdTransportRequestResponse[];
  company: GetByIdCompanyResponse;

  constructor(
    private transportRequestService: TransportRequestService,
<<<<<<< Updated upstream
    private companyService: CompanyService,
    private modalService: NgbModal,
    private tokenService: TokenService,
    private paymentRequestService: PaymentRequestService
  ) {}

=======
    private modalService: NgbModal,
    private companyService: CompanyService,
    private tokenService: TokenService
  ) {}
>>>>>>> Stashed changes
  ngOnInit(): void {
    this.getCompany();
  }

<<<<<<< Updated upstream
=======
  getPageCounts(): number[] {
    return Array.from(Array(this.transportRequests).keys());
  }

>>>>>>> Stashed changes
  getCompany() {
    let userToken = this.tokenService.getUserWithJWT()!;
    this.companyService.getById(userToken.id).subscribe((response) => {
      this.company = response;
      this.getList();
    });
  }

<<<<<<< Updated upstream
  getApproveStatus(approve: any): string {
    if (approve == null) {
      return 'Waiting';
    } else if (approve == true) {
      return 'Approved';
    } else {
      return 'Rejected';
    }
  }

  getFinishStatus(isFinished: boolean): string {
    if (isFinished) {
      return 'Finished';
    } else {
      return 'Continues';
    }
  }

  openTransportRequestInfoModal(
    transportRequest: GetByCompanyIdTransportRequestResponse
  ) {
    var modalReferance = this.modalService.open(TransportRequestInfoComponent, {
      size: 'm',
      modalDialogClass: 'modal-dialog-centered',
    });
    modalReferance.componentInstance.transportRequest = transportRequest;
  }

  openApproveRequestModal(
    transportRequest: GetByCompanyIdTransportRequestResponse
  ) {
    var modalReferance = this.modalService.open(
      ApproveTransportRequestComponent,
      {
        size: 'm',
        modalDialogClass: 'modal-dialog-centered',
      }
    );
    modalReferance.componentInstance.transportRequest = transportRequest;
  }

  openRejectRequestModal(
    transportRequest: GetByCompanyIdTransportRequestResponse
  ) {
    var modalReferance = this.modalService.open(
      RejectTransportRequestComponent,
      {
        size: 'm',
        modalDialogClass: 'modal-dialog-centered',
      }
    );
    modalReferance.componentInstance.transportRequest = transportRequest;
  }

  getIsPaidText(isPaid: boolean) {
    if (isPaid) {
      return 'Is paid';
    }
    return 'Is waiting';
  }
=======
  // openApproveTransportRequestModal(transportRequest: GetByCompanyIdTransportRequestResponse) {
  //   var modalReferance = this.modalService.open(LanguageUpdateComponent, {
  //     size: 'm',
  //     modalDialogClass: 'modal-dialog-centered',
  //   });
  //   modalReferance.componentInstance.transportRequest = transportRequest;
  // }

  // openRejectTransportRequestModal(transportRequest: GetByCompanyIdTransportRequestResponse) {
  //   var modalReferance = this.modalService.open(LanguageDeleteComponent, {
  //     size: 'm',
  //     modalDialogClass: 'modal-dialog-centered',
  //   });
  //   modalReferance.componentInstance.transportRequest = transportRequest;
  // }
>>>>>>> Stashed changes

  getList() {
    this.dataLoaded = false;
    this.transportRequestService
<<<<<<< Updated upstream
      .getListByCompanyId({ companyId: this.company?.appUserId })
=======
      .getListByCompanyId({ companyId: this.company.appUserId })
>>>>>>> Stashed changes
      .subscribe((response) => {
        this.transportRequests = response;
        this.dataLoaded = true;
      });
  }
}
