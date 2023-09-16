import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
<<<<<<< Updated upstream
import { AppUserToken } from 'src/app/models/domain-models/appUserToken';
import { TokenUserDto } from 'src/app/models/dtos/tokenUserDto';
import { CreateCarrierRequest } from 'src/app/models/request-models/carriers/createCarrierRequest';
import { AuthService } from 'src/app/services/auth.service';
import { TokenService } from 'src/app/services/token.service';
=======
import { CreateCarrierRequest } from 'src/app/models/request-models/carriers/createCarrierRequest';
import { GetByIdCompanyResponse } from 'src/app/models/response-models/companies/getByIdCompanyResponse';
import { AuthService } from 'src/app/services/auth.service';
>>>>>>> Stashed changes

@Component({
  selector: 'app-hire-carrier',
  templateUrl: './hire-carrier.component.html',
  styleUrls: ['./hire-carrier.component.css'],
})
export class HireCarrierComponent {
  hireCarrierForm: FormGroup;
<<<<<<< Updated upstream
  company: TokenUserDto;
=======
  company: GetByIdCompanyResponse;
>>>>>>> Stashed changes

  constructor(
    private authService: AuthService,
    private formBuilder: FormBuilder,
<<<<<<< Updated upstream
    private toastrService: ToastrService,
    private translateService: TranslateService,
    private tokenService: TokenService,
    private activeModal:NgbActiveModal
  ) {}

  ngOnInit(): void {
    this.getCompany();
    this.createHireCarrierForm();
  }

  getCompany() {
    this.company = this.tokenService.getUserWithJWT()!;
  }

  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }
=======
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private translateService: TranslateService
  ) {}

  ngOnInit(): void {
    this.createHireCarrierForm();
  }

>>>>>>> Stashed changes
  createHireCarrierForm() {
    this.hireCarrierForm = this.formBuilder.group({
      userName: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required],
      email: ['', Validators.required],
      password: ['', Validators.required],
      age: ['', Validators.required],
    });
  }

<<<<<<< Updated upstream
=======
  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }

>>>>>>> Stashed changes
  hireCarrier() {
    if (!this.hireCarrierForm.valid) {
      this.toastrService.error('My form invalid', 'Form Error');
    }

    let registerModel: CreateCarrierRequest = Object.assign(
      {},
      this.hireCarrierForm.value
    );
<<<<<<< Updated upstream
    registerModel.companyId = this.company.id;

=======
    registerModel.companyId = this.company.appUserId;
>>>>>>> Stashed changes
    this.authService.registerAsCarrier(registerModel).subscribe((response) => {
      this.toastrService.success(
        'Successfully registered',
        this.translateService.instant('successful')
      );
    });
  }
}
