import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TokenService } from 'src/app/services/token.service';
import { TransportRequestService } from 'src/app/services/transport-request.service';

@Component({
  selector: 'app-create-transport-request',
  templateUrl: './create-transport-request.component.html',
  styleUrls: ['./create-transport-request.component.css'],
})
export class CreateTransportRequestComponent implements OnInit {
  checkoutForm: FormGroup;

  constructor(
    private transportRequestService: TransportRequestService,
    private formBuilder: FormBuilder,
    private tokenService: TokenService
  ) {}

  ngOnInit(): void {
    this.createCheckoutForm();
  }

  createCheckoutForm() {
    this.checkoutForm = this.formBuilder.group({
      placeSize: ['', Validators.required],
      startDate: ['', Validators.required],
      country: ['', Validators.required],
      city: ['', Validators.required],
      fullName: ['', Validators.required],
      cardNumber: ['', Validators.required],
      month: ['', Validators.required],
      year: ['', Validators.required],
      cvv: ['', Validators.required],
    });
  }

  createTransportRequest() {}
}
