import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { CreateCustomerRequest } from 'src/app/models/request-models/customers/createCustomerRequest';
import { AuthService } from 'src/app/services/auth.service';

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
    private translateService: TranslateService
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
    console.log(this.registerForm.value);

    let registerModel: CreateCustomerRequest = Object.assign(
      {},
      this.registerForm.value
    );
    console.log(registerModel);
    this.authService.registerAsCustomer(registerModel).subscribe((response) => {
      this.toastrService.success(
        'Successfully registered',
        this.translateService.instant('successful')
      );
    });
  }
}
