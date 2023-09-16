import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { DeleteCarRequest } from 'src/app/models/request-models/cars/deleteCarRequest';
import { GetByIdCompanyResponse } from 'src/app/models/response-models/companies/getByIdCompanyResponse';
import { GetByCompanyIdVehicleResponse } from 'src/app/models/response-models/vehicles/getByCompanyIdVehicleResponse';
import { CarService } from 'src/app/services/car.service';

@Component({
  selector: 'app-car-delete',
  templateUrl: './car-delete.component.html',
  styleUrls: ['./car-delete.component.css'],
})
export class CarDeleteComponent {
  company: GetByIdCompanyResponse;
  objectToModify: GetByCompanyIdVehicleResponse;

  constructor(
    private carService: CarService,
    private formBuilder: FormBuilder,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private translate: TranslateService
  ) {}

  ngOnInit(): void {}

  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }

  deleteCar() {
    if (!this.objectToModify.car) {
      this.toastrService.error('Car is null', 'Form Error');
      return;
    }

    let carModel: DeleteCarRequest = { vehicleId: this.objectToModify.id };

    this.carService.delete(carModel).subscribe((response) => {
      this.toastrService.success(
        response.brand + ' ' + response.model + ' deleted',
        this.translate.instant('successful')
      );
      this.close();
    });
  }
}
