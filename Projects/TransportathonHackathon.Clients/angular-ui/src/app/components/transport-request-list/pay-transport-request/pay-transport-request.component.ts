import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { PayPaymentRequestRequest } from 'src/app/models/request-models/payment-request/payPaymentRequestRequest';
import { GetByIdPaymentRequestResponse } from 'src/app/models/response-models/payment-request/getByIdPaymentRequestResponse';
import { GetByCustomerIdTransportRequestResponse } from 'src/app/models/response-models/transport-requests/getByCustomerIdTransportRequestResponse';
import { GetByIdTransportRequestResponse } from 'src/app/models/response-models/transport-requests/getByIdTransportRequestResponse';
import { PaymentRequestService } from 'src/app/services/payment-request.service';
import { TransportRequestService } from 'src/app/services/transport-request.service';

@Component({
  selector: 'app-pay-transport-request',
  templateUrl: './pay-transport-request.component.html',
  styleUrls: ['./pay-transport-request.component.css'],
})
export class PayTransportRequestComponent implements OnInit {
  transportRequest: GetByIdTransportRequestResponse;
  paymentForm: FormGroup;
  paymentRequest: GetByIdPaymentRequestResponse;

  constructor(
    private transportRequestService: TransportRequestService,
    private paymentRequestService: PaymentRequestService,
    private formBuilder: FormBuilder,
    private activatedRoute: ActivatedRoute,
    private toastrService: ToastrService
  ) {}

  ngOnInit(): void {
    this.subscribeRoute();
    this.createPaymentForm();
  }

  subscribeRoute() {
    this.activatedRoute.params.subscribe((param) => {
      if (!param['transportRequestId']) {
        return;
      }

      this.getTransportRequest(param['transportRequestId']);
      this.getPaymentRequest(param['transportRequestId']);
    });
  }

  getTransportRequest(transportRequestId: string) {
    this.transportRequestService
      .getById({ id: transportRequestId })
      .subscribe((response) => {
        this.transportRequest = response;
      });
  }

  getPaymentRequest(transportRequestId: string) {
    this.paymentRequestService
      .getById({ transportRequestId: transportRequestId })
      .subscribe((response) => {
        this.paymentRequest = response;
      });
  }

  createPaymentForm() {
    this.paymentForm = this.formBuilder.group({
      fullName: ['', Validators.required],
      cardNumber: ['', Validators.required],
      month: ['', Validators.required],
      year: ['', Validators.required],
      cvv: ['', Validators.required],
    });
  }

  pay() {
    if (!this.paymentForm.valid) {
      this.toastrService.error('Form is invalid', 'Form error');
    }

    let paymentRequestRequest: PayPaymentRequestRequest =
      {} as PayPaymentRequestRequest;
    paymentRequestRequest.paymentRequest = Object.assign(
      {},
      this.paymentForm.value
    );

    paymentRequestRequest.paymentRequest.price = this.paymentRequest.price;
    paymentRequestRequest.transportRequestId = this.transportRequest.id;

    this.paymentRequestService.pay(paymentRequestRequest).subscribe(response=>{
      this.toastrService.success("Successfully paid", "Successful")
    })
  }
}
