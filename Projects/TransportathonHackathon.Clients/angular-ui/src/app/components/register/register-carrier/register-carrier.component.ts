import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { CreateCarrierRequest } from 'src/app/models/request-models/carriers/createCarrierRequest';
import { AuthService } from 'src/app/services/auth.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-register-carrier',
  templateUrl: './register-carrier.component.html',
  styleUrls: ['./register-carrier.component.css']
})
export class RegisterCarrierComponent {
  registerForm: FormGroup;

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService,
    private translateService: TranslateService,
    private tokenService: TokenService
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
      age: ['', Validators.required],
      companyId: ['', Validators.required],
    });
  }

  register() {
    if (!this.registerForm.valid) {
      this.toastrService.error('My form invalid', 'Form Error');
    }

    let registerModel: CreateCarrierRequest = Object.assign(
      {},
      this.registerForm.value
    );
    this.authService.registerAsCarrier(registerModel).subscribe((response) => {
      this.tokenService.setToken(response.token);
      this.toastrService.success(
        'Successfully registered',
        this.translateService.instant('successful')
      );
    });
  }
}
