<<<<<<< Updated upstream
import { Component } from '@angular/core';
=======
import { Component, OnInit } from '@angular/core';
>>>>>>> Stashed changes
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
<<<<<<< Updated upstream
import { TokenUserDto } from 'src/app/models/dtos/tokenUserDto';
import { CreateDriverRequest } from 'src/app/models/request-models/drivers/createDriverRequest';
import { AuthService } from 'src/app/services/auth.service';
import { TokenService } from 'src/app/services/token.service';
=======
import { CreateDriverRequest } from 'src/app/models/request-models/drivers/createDriverRequest';
import { GetByIdCompanyResponse } from 'src/app/models/response-models/companies/getByIdCompanyResponse';
import { AuthService } from 'src/app/services/auth.service';
import { DriverService } from 'src/app/services/driver.service';
>>>>>>> Stashed changes

@Component({
  selector: 'app-hire-driver',
  templateUrl: './hire-driver.component.html',
  styleUrls: ['./hire-driver.component.css'],
})
<<<<<<< Updated upstream
export class HireDriverComponent {
  hireDriverForm: FormGroup;
  company: TokenUserDto;
  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private toastrService: ToastrService,
    private translateService: TranslateService,
    private tokenService: TokenService,
    private activeModal: NgbActiveModal
  ) {}

  ngOnInit(): void {
    this.getCompany();
    this.createHireDriverForm();
  }

  getCompany() {
    this.company = this.tokenService.getUserWithJWT()!;
=======
export class HireDriverComponent implements OnInit {
  hireDriverForm: FormGroup;
  company: GetByIdCompanyResponse;

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private translateService: TranslateService
  ) {}

  ngOnInit(): void {
    this.createHireDriverForm();
>>>>>>> Stashed changes
  }

  createHireDriverForm() {
    this.hireDriverForm = this.formBuilder.group({
      userName: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
      age: ['', Validators.required],
    });
  }

  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }

  hireDriver() {
    if (!this.hireDriverForm.valid) {
      this.toastrService.error('My form invalid', 'Form Error');
    }

    let registerModel: CreateDriverRequest = Object.assign(
      {},
      this.hireDriverForm.value
    );
<<<<<<< Updated upstream
    registerModel.companyId = this.company.id;
=======
    registerModel.companyId = this.company.appUserId;
>>>>>>> Stashed changes

    this.authService.registerAsDriver(registerModel).subscribe((response) => {
      this.toastrService.success(
        'Successfully registered',
        this.translateService.instant('successful')
      );
    });
  }
}
