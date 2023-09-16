import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { UpdateTruckRequest } from 'src/app/models/request-models/trucks/updateTruckRequest';
import { GetByIdCompanyResponse } from 'src/app/models/response-models/companies/getByIdCompanyResponse';
import { GetByCompanyIdDriverResponse } from 'src/app/models/response-models/drivers/getByCompanyIdDriverResponse';
import { GetByCompanyIdVehicleResponse } from 'src/app/models/response-models/vehicles/getByCompanyIdVehicleResponse';
import { DriverService } from 'src/app/services/driver.service';
import { TruckService } from 'src/app/services/truck.service';

@Component({
  selector: 'app-truck-update',
  templateUrl: './truck-update.component.html',
  styleUrls: ['./truck-update.component.css'],
})
export class TruckUpdateComponent {
  company: GetByIdCompanyResponse;
  truckUpdateForm: FormGroup;
  objectToModify: GetByCompanyIdVehicleResponse;
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
    this.createTruckUpdateForm();
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

  createTruckUpdateForm() {
    this.truckUpdateForm = this.formBuilder.group({
      driverId: [this.objectToModify.driverId, Validators.required],
<<<<<<< Updated upstream
      brand: [this.objectToModify.brand, Validators.required],
      model: [this.objectToModify.model, Validators.required],
      modelYear: [this.objectToModify.modelYear, Validators.required],
=======
      brand: [this.objectToModify?.brand, Validators.required],
      model: [this.objectToModify?.model, Validators.required],
      modelYear: [this.objectToModify?.modelYear, Validators.required],
>>>>>>> Stashed changes
      size: [this.objectToModify.truck?.size, Validators.required],
    });
  }

  updateTruck() {
    if (!this.truckUpdateForm.valid) {
      this.toastrService.error('Form is invalid', 'Form Error');
      return;
    }

    let truckModel: UpdateTruckRequest = Object.assign(
      {},
      this.truckUpdateForm.value
    );
    truckModel.companyId = this.company.appUserId;
    truckModel.vehicleId = this.objectToModify.id;

    this.truckService.update(truckModel).subscribe((response) => {
      this.toastrService.success(
        response.brand + ' - ' + response.model + ' updated',
        this.translate.instant('successful')
      );
    });
  }
}
