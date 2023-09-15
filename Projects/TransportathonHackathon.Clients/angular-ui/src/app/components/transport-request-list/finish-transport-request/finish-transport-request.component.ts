import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { GetByIdTransportRequestResponse } from 'src/app/models/response-models/transport-requests/getByIdTransportRequestResponse';
import { TransportRequestService } from 'src/app/services/transport-request.service';

@Component({
  selector: 'app-finish-transport-request',
  templateUrl: './finish-transport-request.component.html',
  styleUrls: ['./finish-transport-request.component.css'],
})
export class FinishTransportRequestComponent {
  transportRequest: GetByIdTransportRequestResponse;

  constructor(
    private transportRequestService: TransportRequestService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private toastrService: ToastrService,
    private activeModal: NgbActiveModal
  ) {}

  ngOnInit(): void {}

  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }

  finishTransportRequest() {
    if (!this.transportRequest) {
      this.toastrService.error('Transport request is null', 'Error');
    }

    this.transportRequestService
      .finishTransportRequest({
        id: this.transportRequest.id,
      })
      .subscribe((response) => {
        this.toastrService.success('Successfully finished', 'Successful');
      });
  }
}
