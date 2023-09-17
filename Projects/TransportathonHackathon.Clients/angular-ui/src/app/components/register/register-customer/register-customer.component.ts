import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { ErrorSeperator } from 'src/app/core/errors/services/error-seperator';
import { CreateCustomerRequest } from 'src/app/models/request-models/customers/createCustomerRequest';
import { AuthService } from 'src/app/services/auth.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-register-customer',
  templateUrl: './register-customer.component.html',
  styleUrls: ['./register-customer.component.css'],
})
export class RegisterCustomerComponent implements OnInit {
  registerForm: FormGroup;

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService,
    private translateService: TranslateService,
    private tokenService: TokenService,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.formBuilder.group({
      userName: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  register() {
    if (!this.registerForm.valid) {
      this.toastrService.error('My form invalid', 'Form Error');
    }

    let registerModel: CreateCustomerRequest = Object.assign(
      {},
      this.registerForm.value
    );
    this.authService.registerAsCustomer(registerModel).subscribe((response) => {
      this.tokenService.setToken(response.token);
      this.toastrService.success(
        'Successfully registered',
        this.translateService.instant('successful')
      );
      this.router
        .navigate([
          'customer/details/' + this.tokenService.getUserWithJWT()?.id,
        ])
        .finally(() => {
          location.reload();
        });
    });
  }
}
