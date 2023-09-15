import { Component } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { GetByCompanyIdTransportRequestResponse } from 'src/app/models/response-models/transport-requests/getByCompanyIdTransportRequestResponse';

@Component({
  selector: 'app-transport-request-info',
  templateUrl: './transport-request-info.component.html',
  styleUrls: ['./transport-request-info.component.css'],
})
export class TransportRequestInfoComponent {
  transportRequest: GetByCompanyIdTransportRequestResponse;

  constructor(private activeModal: NgbActiveModal) {}
  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }
}
