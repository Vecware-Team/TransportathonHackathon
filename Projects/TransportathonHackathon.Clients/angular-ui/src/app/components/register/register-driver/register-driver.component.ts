import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { CreateDriverRequest } from 'src/app/models/request-models/drivers/createDriverRequest';
import { AuthService } from 'src/app/services/auth.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-register-driver',
  templateUrl: './register-driver.component.html',
  styleUrls: ['./register-driver.component.css']
})
export class RegisterDriverComponent {
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

    let registerModel: CreateDriverRequest = Object.assign(
      {},
      this.registerForm.value
    );
    this.authService.registerAsDriver(registerModel).subscribe((response) => {
      this.tokenService.setToken(response.token);
      this.toastrService.success(
        'Successfully registered',
        this.translateService.instant('successful')
      );
    });
  }
}
