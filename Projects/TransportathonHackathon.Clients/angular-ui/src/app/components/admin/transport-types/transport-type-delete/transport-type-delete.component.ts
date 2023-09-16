import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { DeleteTransportTypeRequest } from 'src/app/models/request-models/transport-types/deleteTransportTypeReques';
import { GetListTransportTypeResponse } from 'src/app/models/response-models/transport-types/getListTransportTypeResponse';
import { TransportTypeService } from 'src/app/services/transport-type.service';

@Component({
  selector: 'app-transport-type-delete',
  templateUrl: './transport-type-delete.component.html',
  styleUrls: ['./transport-type-delete.component.css'],
})
export class TransportTypeDeleteComponent {
  transportType: GetListTransportTypeResponse;

  constructor(
    private transportTypeService: TransportTypeService,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private translate: TranslateService
  ) {}

  ngOnInit(): void {}

  close() {
    this.activeModal.close('Delete Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Delete Modal Dismissed');
  }

  deleteTransportType() {
    if (this.transportType.id == null) {
      this.toastrService.error('Transport type is null', 'Form Error');
      return;
    }

    let transportTypeModel: DeleteTransportTypeRequest = {
      id: this.transportType.id,
    };

    this.transportTypeService
      .delete(transportTypeModel)
      .subscribe((response) => {
        this.toastrService.success(
          response.type + ' deleted',
          this.translate.instant('successful')
        );
        this.close();
      });
  }
}
