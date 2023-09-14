import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { CreatePickupTruckRequest } from 'src/app/models/request-models/pickup-trucks/createPickupTruckRequest';
import { GetByIdCompanyResponse } from 'src/app/models/response-models/companies/getByIdCompanyResponse';
import { GetByCompanyIdDriverResponse } from 'src/app/models/response-models/drivers/getByCompanyIdDriverResponse';
import { DriverService } from 'src/app/services/driver.service';
import { PickupTruckService } from 'src/app/services/pickup-truck.service';

@Component({
  selector: 'app-pickup-truck-add',
  templateUrl: './pickup-truck-add.component.html',
  styleUrls: ['./pickup-truck-add.component.css'],
})
export class PickupTruckAddComponent {
  company: GetByIdCompanyResponse;
  pickupTruckAddForm: FormGroup;
  drivers: GetByCompanyIdDriverResponse[];

  constructor(
    private pickupTruckService: PickupTruckService,
    private formBuilder: FormBuilder,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private translate: TranslateService,
    private driverService: DriverService
  ) {}

  ngOnInit(): void {
    this.getDrivers();
    this.createPickupTruckAddForm();
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

  createPickupTruckAddForm() {
    this.pickupTruckAddForm = this.formBuilder.group({
      driverId: ['', Validators.required],
      brand: ['', Validators.required],
      model: ['', Validators.required],
      modelYear: ['', Validators.required],
      size: ['', Validators.required],
    });
  }

  add() {
    if (!this.pickupTruckAddForm.valid) {
      this.toastrService.error('form is invalid', 'Form Error');
      return;
    }

    let pickupTruckModel: CreatePickupTruckRequest = Object.assign(
      {},
      this.pickupTruckAddForm.value
    );
    pickupTruckModel.companyId = this.company.appUserId;

    this.pickupTruckService.create(pickupTruckModel).subscribe((response) => {
      this.toastrService.success(
        response.brand + ' ' + response.model + ' added',
        this.translate.instant('successful')
      );
    });
  }
}
