import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { Carrier } from 'src/app/models/domain-models/carrier';
import { DeleteCarrierRequest } from 'src/app/models/request-models/carriers/deleteCarrierRequest';
import { GetByCompanyIdEmployeeResponse } from 'src/app/models/response-models/employees/getByCompanyIdEmployeeResponse';
import { CarrierService } from 'src/app/services/carrier.service';

@Component({
  selector: 'app-hire-out-carrier',
  templateUrl: './hire-out-carrier.component.html',
  styleUrls: ['./hire-out-carrier.component.css'],
})
export class HireOutCarrierComponent {
  carrier: GetByCompanyIdEmployeeResponse;

  constructor(
    private carrierService: CarrierService,
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

  deleteCarrier() {
    if (!this.carrier) {
      this.toastrService.error('Carrier is null', 'Form Error');
      return;
    }

    let carrierModel: DeleteCarrierRequest = {
      employeeId: this.carrier.appUserId,
    };

    this.carrierService.delete(carrierModel).subscribe((response) => {
      this.toastrService.success(
        response.firstName + ' ' + response.lastName + ' deleted',
        this.translate.instant('successful')
      );
      this.close();
    });
  }
}
