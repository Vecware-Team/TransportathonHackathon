import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { UpdatePickupTruckRequest } from 'src/app/models/request-models/pickup-trucks/updatePickupTruckRequest';
import { GetByIdCompanyResponse } from 'src/app/models/response-models/companies/getByIdCompanyResponse';
import { GetByCompanyIdDriverResponse } from 'src/app/models/response-models/drivers/getByCompanyIdDriverResponse';
import { GetByCompanyIdVehicleResponse } from 'src/app/models/response-models/vehicles/getByCompanyIdVehicleResponse';
import { DriverService } from 'src/app/services/driver.service';
import { PickupTruckService } from 'src/app/services/pickup-truck.service';

@Component({
  selector: 'app-pickup-truck-update',
  templateUrl: './pickup-truck-update.component.html',
  styleUrls: ['./pickup-truck-update.component.css'],
})
export class PickupTruckUpdateComponent {
  company: GetByIdCompanyResponse;
  pickupTruckUpdateForm: FormGroup;
  objectToModify: GetByCompanyIdVehicleResponse;
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
    this.createPickupTruckUpdateForm();
    this.getDrivers();
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
    this.activeModal.close('Delete Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Delete Modal Dismissed');
  }

  createPickupTruckUpdateForm() {
    this.pickupTruckUpdateForm = this.formBuilder.group({
      driverId: [this.objectToModify.driverId, Validators.required],
      brand: [this.objectToModify.pickupTruck?.brand, Validators.required],
      model: [this.objectToModify.pickupTruck?.model, Validators.required],
      modelYear: [
        this.objectToModify.pickupTruck?.modelYear,
        Validators.required,
      ],
      size: [this.objectToModify.pickupTruck?.size, Validators.required],
    });
  }

  updatePickupTruck() {
    if (!this.pickupTruckUpdateForm.valid) {
      this.toastrService.error('Form is invalid', 'Form Error');
      return;
    }

    let pickupTruckModel: UpdatePickupTruckRequest = Object.assign(
      {},
      this.pickupTruckUpdateForm.value
    );
    pickupTruckModel.companyId = this.company.appUserId;
    pickupTruckModel.vehicleId = this.objectToModify.id;

    this.pickupTruckService.update(pickupTruckModel).subscribe((response) => {
      this.toastrService.success(
        response.brand + ' - ' + response.model + ' updated',
        this.translate.instant('successful')
      );
    });
  }
}
