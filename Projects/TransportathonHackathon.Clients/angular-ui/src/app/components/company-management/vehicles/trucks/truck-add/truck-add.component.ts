import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { CreateTruckRequest } from 'src/app/models/request-models/trucks/createTruckRequest';
import { GetByIdCompanyResponse } from 'src/app/models/response-models/companies/getByIdCompanyResponse';
import { GetByCompanyIdDriverResponse } from 'src/app/models/response-models/drivers/getByCompanyIdDriverResponse';
import { DriverService } from 'src/app/services/driver.service';
import { TruckService } from 'src/app/services/truck.service';

@Component({
  selector: 'app-truck-add',
  templateUrl: './truck-add.component.html',
  styleUrls: ['./truck-add.component.css'],
})
export class TruckAddComponent {
  company: GetByIdCompanyResponse;
  truckAddForm: FormGroup;
  drivers: GetByCompanyIdDriverResponse[];

  constructor(
    private truckService: TruckService,
    private formBuilder: FormBuilder,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private translate: TranslateService,
    private driverService: DriverService
  ) {}

  ngOnInit(): void {
    this.getDrivers();
    this.createTruckAddForm();
  }

  getDrivers() {
    this.driverService
      .getListByCompanyId({
        companyId: this.company.appUserId,
      })
      .subscribe((response) => {
        this.drivers = response;
      });
  }

  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }

  createTruckAddForm() {
    this.truckAddForm = this.formBuilder.group({
      driverId: ['', Validators.required],
      brand: ['', Validators.required],
      model: ['', Validators.required],
      modelYear: ['', Validators.required],
      size: ['', Validators.required],
    });
  }

  add() {
    if (!this.truckAddForm.valid) {
      this.toastrService.error('form is invalid', 'Form Error');
      return;
    }

    let truckModel: CreateTruckRequest = Object.assign(
      {},
      this.truckAddForm.value
    );
    truckModel.companyId = this.company.appUserId;

    this.truckService.create(truckModel).subscribe((response) => {
      this.toastrService.success(
        response.brand + ' ' + response.model + ' added',
        this.translate.instant('successful')
      );
      this.close();
    });
  }
}
