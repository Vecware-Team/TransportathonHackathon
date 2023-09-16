<<<<<<< Updated upstream
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { CreatePaymentRequestRequest } from 'src/app/models/request-models/payment-request/createPaymentRequestRequest';
import { GetByCompanyIdTransportRequestResponse } from 'src/app/models/response-models/transport-requests/getByCompanyIdTransportRequestResponse';
import { PaymentRequestService } from 'src/app/services/payment-request.service';
import { TransportRequestService } from 'src/app/services/transport-request.service';
=======
import { Component } from '@angular/core';
>>>>>>> Stashed changes

@Component({
  selector: 'app-approve-transport-request',
  templateUrl: './approve-transport-request.component.html',
<<<<<<< Updated upstream
  styleUrls: ['./approve-transport-request.component.css'],
})
export class ApproveTransportRequestComponent implements OnInit {
  transportRequest: GetByCompanyIdTransportRequestResponse;
  paymentRequestAddForm: FormGroup;

  constructor(
    private transportRequestService: TransportRequestService,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private paymentRequestService: PaymentRequestService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.createPaymentRequestAddForm();
  }

  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }

  createPaymentRequestAddForm() {
    this.paymentRequestAddForm = this.formBuilder.group({
      price: ['', Validators.required],
    });
  }

  sendPaymentRequest() {
    if (!this.paymentRequestAddForm.valid) {
      this.toastrService.error('Price is null', 'Form error');
    }

    let request: CreatePaymentRequestRequest = Object.assign(
      {},
      this.paymentRequestAddForm.value
    );
    request.transportRequestId = this.transportRequest.id;

    this.paymentRequestService.create(request).subscribe((response) => {
      this.toastrService.success('Pay request sent', 'Successful');
    });
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
=======
  styleUrls: ['./approve-transport-request.component.css']
})
export class ApproveTransportRequestComponent {
  
>>>>>>> Stashed changes
}
