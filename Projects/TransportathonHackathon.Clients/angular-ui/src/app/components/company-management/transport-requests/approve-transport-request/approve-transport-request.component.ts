import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { GetByCompanyIdTransportRequestResponse } from 'src/app/models/response-models/transport-requests/getByCompanyIdTransportRequestResponse';
import { TransportRequestService } from 'src/app/services/transport-request.service';

@Component({
  selector: 'app-approve-transport-request',
  templateUrl: './approve-transport-request.component.html',
  styleUrls: ['./approve-transport-request.component.css'],
})
export class ApproveTransportRequestComponent implements OnInit {
  transportRequest: GetByCompanyIdTransportRequestResponse;

  constructor(
    private transportRequestService: TransportRequestService,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {}

  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }

  approve() {
    this.transportRequestService
      .approveTransportRequest({
        id: this.transportRequest.id,
        isApproved: true,
      })
      .subscribe((response) => {
        this.toastrService.success('Approved', 'Successful');
      });
  }
}
