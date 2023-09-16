import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { UpdateCarRequest } from 'src/app/models/request-models/cars/updateCarRequest';
import { GetByIdCompanyResponse } from 'src/app/models/response-models/companies/getByIdCompanyResponse';
import { GetByCompanyIdDriverResponse } from 'src/app/models/response-models/drivers/getByCompanyIdDriverResponse';
import { GetByCompanyIdVehicleResponse } from 'src/app/models/response-models/vehicles/getByCompanyIdVehicleResponse';
import { CarService } from 'src/app/services/car.service';
import { DriverService } from 'src/app/services/driver.service';

@Component({
  selector: 'app-car-update',
  templateUrl: './car-update.component.html',
  styleUrls: ['./car-update.component.css'],
})
export class CarUpdateComponent {
  company: GetByIdCompanyResponse;
  carUpdateForm: FormGroup;
  objectToModify: GetByCompanyIdVehicleResponse;
  drivers: GetByCompanyIdDriverResponse[];

  constructor(
    private carService: CarService,
    private formBuilder: FormBuilder,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private translate: TranslateService,
    private driverService: DriverService
  ) {}

  ngOnInit(): void {
    this.createCarUpdateForm();
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

  createCarUpdateForm() {
    this.carUpdateForm = this.formBuilder.group({
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
    });
  }

  updateCar() {
    if (!this.carUpdateForm.valid) {
      this.toastrService.error('Form is invalid', 'Form Error');
      return;
    }

    let carModel: UpdateCarRequest = Object.assign(
      {},
      this.carUpdateForm.value
    );
    carModel.companyId = this.company.appUserId;
    carModel.vehicleId = this.objectToModify.id;

    this.carService.update(carModel).subscribe((response) => {
      this.toastrService.success(
        response.brand + ' - ' + response.model + ' updated',
        this.translate.instant('successful')
      );
    });
  }
}
