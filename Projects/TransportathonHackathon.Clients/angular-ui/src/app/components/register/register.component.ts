import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, ValidatorFn, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CustomerForRegisterDto } from 'src/app/models/dtos/customerForRegisterDto';
import { RegisterModel } from 'src/app/models/entities/registerModel';
import { AuthService } from 'src/app/services/auth.service';
import { ErrorService } from 'src/app/services/error.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  registerForm: FormGroup;
  submitted: boolean = false;

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private errorService: ErrorService,
    private router: Router,
    private tokenService: TokenService,
    private toastrService: ToastrService,
  ) {}

  ngOnInit(): void {
    this.createRegisterForm();
  }

  createRegisterForm() {
    this.registerForm = this.formBuilder.group(
      {
        firstName: ['', Validators.required],
        lastName: ['', Validators.required],
        email: ['', Validators.required],
        password: ['', Validators.required],
        confirmPassword: ['', Validators.required],
      },
      { validators: this.checkPasswords }
    );
  }

  register() {
    this.submitted = true;
    if (this.registerForm.valid) {
      let registerModel: RegisterModel = Object.assign(
        {},
        this.registerForm.value
      );

      let customerForRegisterModel: CustomerForRegisterDto =
        this.createCustomerForRegisterDto(registerModel, false);

      this.authService.registerWithCustomer(customerForRegisterModel).subscribe(
        (response) => {
          this.toastrService.success(response.message, "this.getTranslate('successful')");
          this.router.navigate(['/login']);
        },
        (responseError) => {
          this.errorService.writeErrorMessages(responseError);
        }
      );
    } else {
      this.toastrService.warning(
        "this.registerForm.errors.message",
        "this.getTranslate('warning')"
      );
    }
  }

  createCustomerForRegisterDto(
    registerModel: RegisterModel,
    approved: boolean
  ): CustomerForRegisterDto {
    let newRegisterModel: CustomerForRegisterDto = {
      customer: {
        userId: 0,
        approved: approved,
      },
      user: {
        firstName: registerModel.firstName,
        lastName: registerModel.lastName,
        email: registerModel.email,
        password: registerModel.password,
      },
    };

    return newRegisterModel;
  }

  checkPasswords: ValidatorFn = (
    group: AbstractControl
  ): ValidationErrors | null => {
    let pass = group.get('password')?.value;
    let confirmPass = group.get('confirmPassword')?.value;

    return pass === confirmPass
      ? null
      : { notSame: true, message: "this.getTranslate('passwordsDontMatch')" };
  };

  get getControls() {
    return this.registerForm.controls;
  }

}
