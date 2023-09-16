import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { PaymentRequest } from 'src/app/models/domain-models/paymentRequest';
import { CreatePaymentRequestRequest } from 'src/app/models/request-models/payment-request/createPaymentRequestRequest';
import { GetByCompanyIdTransportRequestResponse } from 'src/app/models/response-models/transport-requests/getByCompanyIdTransportRequestResponse';
import { PaymentRequestService } from 'src/app/services/payment-request.service';
import { TransportRequestService } from 'src/app/services/transport-request.service';

@Component({
  selector: 'app-approve-transport-request',
  templateUrl: './approve-transport-request.component.html',
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

  approve() {
    if (!this.paymentRequestAddForm.valid) {
      this.toastrService.error('Price is null', 'Form error');
    }

    let paymentRequest: PaymentRequest = Object.assign(
      {},
      this.paymentRequestAddForm.value
    );
    this.transportRequestService
      .approveAndPayTransportRequest({
        id: this.transportRequest.id,
        isApproved: true,
        price: paymentRequest.price,
      })
      .subscribe((response) => {
        this.toastrService.success('Approved', 'Successful');
      });
  }
}
