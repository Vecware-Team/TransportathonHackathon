import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { CreateCarRequest } from 'src/app/models/request-models/cars/createCarRequest';
import { GetByIdCompanyResponse } from 'src/app/models/response-models/companies/getByIdCompanyResponse';
import { GetByCompanyIdDriverResponse } from 'src/app/models/response-models/drivers/getByCompanyIdDriverResponse';
import { CarService } from 'src/app/services/car.service';
import { DriverService } from 'src/app/services/driver.service';

@Component({
  selector: 'app-car-add',
  templateUrl: './car-add.component.html',
  styleUrls: ['./car-add.component.css'],
})
export class CarAddComponent {
  company: GetByIdCompanyResponse;
  carAddForm: FormGroup;
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
    this.getDrivers();
    this.createCarAddForm();
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

  createCarAddForm() {
    this.carAddForm = this.formBuilder.group({
      driverId: ['', Validators.required],
      brand: ['', Validators.required],
      model: ['', Validators.required],
      modelYear: ['', Validators.required],
    });
  }

  add() {
    if (!this.carAddForm.valid) {
      this.toastrService.error('form is invalid', 'Form Error');
      return;
    }

    let carModel: CreateCarRequest = Object.assign({}, this.carAddForm.value);
    carModel.companyId = this.company.appUserId;
    
    this.carService.create(carModel).subscribe((response) => {
      this.toastrService.success(
        response.brand + ' ' + response.model + ' added',
        this.translate.instant('successful')
      );
    });
  }
}
