import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { DeletePickupTruckRequest } from 'src/app/models/request-models/pickup-trucks/deletePickupTruckRequest';
import { GetByIdCompanyResponse } from 'src/app/models/response-models/companies/getByIdCompanyResponse';
import { GetByCompanyIdVehicleResponse } from 'src/app/models/response-models/vehicles/getByCompanyIdVehicleResponse';
import { PickupTruckService } from 'src/app/services/pickup-truck.service';

@Component({
  selector: 'app-pickup-truck-delete',
  templateUrl: './pickup-truck-delete.component.html',
  styleUrls: ['./pickup-truck-delete.component.css'],
})
export class PickupTruckDeleteComponent {
  company: GetByIdCompanyResponse;
  objectToModify: GetByCompanyIdVehicleResponse;

  constructor(
    private pickupTruckService: PickupTruckService,
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

  deletePickupTruck() {
    if (!this.objectToModify.pickupTruck) {
      this.toastrService.error('Car is null', 'Form Error');
      return;
    }

    let pickupTruckModel: DeletePickupTruckRequest = {
      vehicleId: this.objectToModify.id,
    };

    this.pickupTruckService.delete(pickupTruckModel).subscribe((response) => {
      this.toastrService.success(
        response.brand + ' ' + response.model + ' deleted',
        this.translate.instant('successful')
      );
      this.close();
    });
  }
}
