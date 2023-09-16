import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { PaymentRequest } from 'src/app/models/domain-models/paymentRequest';
import { TokenUserDto } from 'src/app/models/dtos/tokenUserDto';
import { CreatePaymentRequestRequest } from 'src/app/models/request-models/payment-request/createPaymentRequestRequest';
import { GetByCompanyIdTransportRequestResponse } from 'src/app/models/response-models/transport-requests/getByCompanyIdTransportRequestResponse';
import { GetByCompanyIdVehicleResponse } from 'src/app/models/response-models/vehicles/getByCompanyIdVehicleResponse';
import { PaymentRequestService } from 'src/app/services/payment-request.service';
import { TokenService } from 'src/app/services/token.service';
import { TransportRequestService } from 'src/app/services/transport-request.service';
import { VehicleService } from 'src/app/services/vehicle.service';

@Component({
  selector: 'app-approve-transport-request',
  templateUrl: './approve-transport-request.component.html',
  styleUrls: ['./approve-transport-request.component.css'],
})
export class ApproveTransportRequestComponent implements OnInit {
  transportRequest: GetByCompanyIdTransportRequestResponse;
  paymentRequestAddForm: FormGroup;
  vehicles: GetByCompanyIdVehicleResponse[];
  appUser: TokenUserDto;

  constructor(
    private transportRequestService: TransportRequestService,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private paymentRequestService: PaymentRequestService,
    private formBuilder: FormBuilder,
    private vehicleService: VehicleService,
    private tokenService: TokenService
  ) {}

  ngOnInit(): void {
    this.createPaymentRequestAddForm();
    this.getUser();
    this.getVehicleList();
  }

  getUser() {
    this.appUser = this.tokenService.getUserWithJWT()!;
  }

  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }

  getVehicleList() {
    this.vehicleService
      .getListByCompanyId({ companyId: this.appUser.id })
      .subscribe((response) => {
        this.vehicles = response;
      });
  }

  createPaymentRequestAddForm() {
    this.paymentRequestAddForm = this.formBuilder.group({
      price: ['', Validators.required],
      vehicleId: ['', Validators.required],
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
        vehicleId: this.paymentRequestAddForm.get('vehicleId')?.value,
      })
      .subscribe((response) => {
        this.toastrService.success('Approved', 'Successful');
        this.close();
      });
  }
}
