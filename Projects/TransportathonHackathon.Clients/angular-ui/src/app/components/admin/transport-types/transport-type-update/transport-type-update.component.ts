import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { UpdateTransportTypeRequest } from 'src/app/models/request-models/transport-types/updateTransportTypeRequest';
import { GetListTransportTypeResponse } from 'src/app/models/response-models/transport-types/getListTransportTypeResponse';
import { TransportTypeService } from 'src/app/services/transport-type.service';

@Component({
  selector: 'app-transport-type-update',
  templateUrl: './transport-type-update.component.html',
  styleUrls: ['./transport-type-update.component.css'],
})
export class TransportTypeUpdateComponent {
  transportTypeUpdateForm: FormGroup;
  transportType: GetListTransportTypeResponse;

  constructor(
    private transportTypeService: TransportTypeService,
    private formBuilder: FormBuilder,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private translate: TranslateService
  ) {}

  ngOnInit(): void {
    this.createTransportTypeUpdateForm();
  }

  close() {
    this.activeModal.close('Update Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Update Modal Dismissed');
  }

  createTransportTypeUpdateForm() {
    this.transportTypeUpdateForm = this.formBuilder.group({
      type: [this.transportType.type, Validators.required],
    });
  }

  update() {
    if (!this.transportTypeUpdateForm.valid) {
      this.toastrService.error('form is invalid', 'Form Error');
      return;
    }

    let transportTypeModel: UpdateTransportTypeRequest = Object.assign(
      {},
      this.transportTypeUpdateForm.value
    );
    transportTypeModel.id = this.transportType.id;

    this.transportTypeService
      .update(transportTypeModel)
      .subscribe((response) => {
        this.toastrService.success(
          response.type + ' updated',
          this.translate.instant('successful')
        );
      });
  }
}
