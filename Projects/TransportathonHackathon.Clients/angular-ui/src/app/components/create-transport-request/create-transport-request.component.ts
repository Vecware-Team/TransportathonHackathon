import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { TokenUserDto } from 'src/app/models/dtos/tokenUserDto';
import { PaymentObject } from 'src/app/models/request-models/payment/paymentObject';
import { CreateTransportRequestRequest } from 'src/app/models/request-models/transport-requests/createTransportRequestRequest';
import { GetListTransportTypeResponse } from 'src/app/models/response-models/transport-types/getListTransportTypeResponse';
import { TokenService } from 'src/app/services/token.service';
import { TransportRequestService } from 'src/app/services/transport-request.service';
import { TransportTypeService } from 'src/app/services/transport-type.service';

@Component({
  selector: 'app-create-transport-request',
  templateUrl: './create-transport-request.component.html',
  styleUrls: ['./create-transport-request.component.css'],
})
export class CreateTransportRequestComponent implements OnInit {
  checkoutForm: FormGroup;
  paymentForm: FormGroup;
  companyId: string;
  customer: TokenUserDto;
  transportTypes: GetListTransportTypeResponse[];

  constructor(
    private transportRequestService: TransportRequestService,
    private formBuilder: FormBuilder,
    private tokenService: TokenService,
    private toastrService: ToastrService,
    private activatedRote: ActivatedRoute,
    private transportTypeService: TransportTypeService
  ) {}

  ngOnInit(): void {
    this.getTransportTypeList();
    this.getUserToken();
    this.createCheckoutForm();
    this.subscribeRoute();
  }

  getTransportTypeList() {
    this.transportTypeService.getList().subscribe((response) => {
      this.transportTypes = response;
    });
  }

  getUserToken() {
    this.customer = this.tokenService.getUserWithJWT()!;
  }

  subscribeRoute() {
    this.activatedRote.params.subscribe((param) => {
      this.companyId = param['companyId'];
    });
  }

  createCheckoutForm() {
    this.checkoutForm = this.formBuilder.group({
      placeSize: ['', Validators.required],
      startDate: ['', Validators.required],
      countryFrom: ['', Validators.required],
      cityFrom: ['', Validators.required],
      countryTo: ['', Validators.required],
      cityTo: ['', Validators.required],
      transportTypeId: ['', Validators.required],
      // fullName: ['', Validators.required],
      // cardNumber: ['', Validators.required],
      // month: ['', Validators.required],
      // year: ['', Validators.required],
      // cvv: ['', Validators.required],
    });
  }

  createTransportRequest() {
    if (!this.checkoutForm.valid) {
      this.toastrService.error('Transport form is invalid', 'Form error');
    }

    let requestModel: CreateTransportRequestRequest = Object.assign(
      {},
      this.checkoutForm.value
    );
    requestModel.companyId = this.companyId;
    requestModel.customerId = this.customer.id;

    this.transportRequestService.create(requestModel).subscribe((response) => {
      this.toastrService.success('Request sent', 'Successful');
    });
  }
}
