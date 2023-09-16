<<<<<<< Updated upstream
import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { GetByCompanyIdTransportRequestResponse } from 'src/app/models/response-models/transport-requests/getByCompanyIdTransportRequestResponse';
import { TransportRequestService } from 'src/app/services/transport-request.service';
=======
import { Component } from '@angular/core';
>>>>>>> Stashed changes

@Component({
  selector: 'app-reject-transport-request',
  templateUrl: './reject-transport-request.component.html',
<<<<<<< Updated upstream
  styleUrls: ['./reject-transport-request.component.css'],
})
export class RejectTransportRequestComponent implements OnInit {
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

  reject() {
    this.transportRequestService
      .approveTransportRequest({
        id: this.transportRequest.id,
        isApproved: false,
      })
      .subscribe((response) => {
        this.toastrService.success('Rejected', 'Successful');
      });
  }
=======
  styleUrls: ['./reject-transport-request.component.css']
})
export class RejectTransportRequestComponent {

>>>>>>> Stashed changes
}
