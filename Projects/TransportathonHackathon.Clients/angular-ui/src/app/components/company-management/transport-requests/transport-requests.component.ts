import { Component, OnInit } from '@angular/core';
import {
  faCircleCheck,
  faCircleXmark,
  faRedoAlt,
} from '@fortawesome/free-solid-svg-icons';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { GetByCompanyIdTransportRequestRequest } from 'src/app/models/request-models/transport-requests/getByCompanyIdTransportRequestRequest';
import { GetByIdCompanyResponse } from 'src/app/models/response-models/companies/getByIdCompanyResponse';
import { GetByCompanyIdTransportRequestResponse } from 'src/app/models/response-models/transport-requests/getByCompanyIdTransportRequestResponse';
import { CompanyService } from 'src/app/services/company.service';
import { TokenService } from 'src/app/services/token.service';
import { TransportRequestService } from 'src/app/services/transport-request.service';
import { ApproveTransportRequestComponent } from './approve-transport-request/approve-transport-request.component';
import { RejectTransportRequestComponent } from './reject-transport-request/reject-transport-request.component';

@Component({
  selector: 'app-transport-requests',
  templateUrl: './transport-requests.component.html',
  styleUrls: ['./transport-requests.component.css'],
})
export class TransportRequestsComponent implements OnInit {
  faRedoAlt = faRedoAlt;
  faCircleCheck = faCircleCheck;
  faCircleXMark = faCircleXmark;
  dataLoaded = false;
  transportRequests: GetByCompanyIdTransportRequestResponse[];
  company: GetByIdCompanyResponse;

  constructor(
    private transportRequestService: TransportRequestService,
    private companyService: CompanyService,
    private modalService: NgbModal,
    private tokenService: TokenService
  ) {}

  ngOnInit(): void {
    this.getCompany();
  }

  getCompany() {
    let userToken = this.tokenService.getUserWithJWT()!;
    this.companyService.getById(userToken.id).subscribe((response) => {
      this.company = response;
      this.getList();
    });
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

  getList() {
    this.dataLoaded = false;
    this.transportRequestService
      .getListByCompanyId({ companyId: this.company?.appUserId })
      .subscribe((response) => {
        this.transportRequests = response;
        this.dataLoaded = true;
      });
  }
}
