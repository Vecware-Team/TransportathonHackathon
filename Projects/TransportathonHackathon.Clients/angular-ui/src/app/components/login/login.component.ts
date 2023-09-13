import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { LoginDto } from 'src/app/models/dtos/loginDto';
import { AuthService } from 'src/app/services/auth.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  loginForm: FormGroup;

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService,
    private translateService: TranslateService,
    private tokenService: TokenService
  ) {}

  ngOnInit(): void {
    this.createLoginForm();
  }

  createLoginForm() {
    this.loginForm = this.formBuilder.group({
      emailorUserName: ['', Validators.required],
      password: ['', Validators.required],
    });
  }

  login() {
    if (!this.loginForm.valid) {
      this.toastrService.error('My form invalid', 'Form Error');
    }

    let loginModel: LoginDto = Object.assign(
      {},
      this.loginForm.value
    );
    this.authService.login(loginModel).subscribe((response) => {
      this.tokenService.setToken(response.token);
      this.toastrService.success(
        'Successfully logged in',
        this.translateService.instant('successful')
      );
    });
  }
}
