import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { CreateCompanyRequest } from 'src/app/models/request-models/company/createCompanyRequest';
import { AuthService } from 'src/app/services/auth.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-register-company',
  templateUrl: './register-company.component.html',
  styleUrls: ['./register-company.component.css'],
})
export class RegisterCompanyComponent {
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
      companyName: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  register() {
    if (!this.registerForm.valid) {
      this.toastrService.error('Form is invalid', 'Form Error');
    }

    let registerModel: CreateCompanyRequest = Object.assign(
      {},
      this.registerForm.value
    );
    this.authService.registerAsCompany(registerModel).subscribe((response) => {
      this.tokenService.setToken(response.token);
      this.toastrService.success(
        'Successfully registered',
        this.translateService.instant('successful')
      );
      this.router.navigate([
        'company/panel/' + this.tokenService.getUserWithJWT()?.id,
      ]);
    });
  }
}
