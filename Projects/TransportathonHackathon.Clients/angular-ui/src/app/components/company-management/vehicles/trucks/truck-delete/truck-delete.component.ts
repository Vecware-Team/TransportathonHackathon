import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { DeleteTruckRequest } from 'src/app/models/request-models/trucks/deleteTruckRequest';
import { GetByIdCompanyResponse } from 'src/app/models/response-models/companies/getByIdCompanyResponse';
import { GetByCompanyIdVehicleResponse } from 'src/app/models/response-models/vehicles/getByCompanyIdVehicleResponse';
import { TruckService } from 'src/app/services/truck.service';

@Component({
  selector: 'app-truck-delete',
  templateUrl: './truck-delete.component.html',
  styleUrls: ['./truck-delete.component.css'],
})
export class TruckDeleteComponent {
  company: GetByIdCompanyResponse;
  objectToModify: GetByCompanyIdVehicleResponse;

  constructor(
    private truckService: TruckService,
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

  deleteTruck() {
    if (!this.objectToModify.truck) {
      this.toastrService.error('Truck is not found', 'Form Error');
      return;
    }

    let truckModel: DeleteTruckRequest = { vehicleId: this.objectToModify.id };

    this.truckService.delete(truckModel).subscribe((response) => {
      this.toastrService.success(
        response.brand + ' ' + response.model + ' deleted',
        this.translate.instant('successful')
      );
    });
  }
}
