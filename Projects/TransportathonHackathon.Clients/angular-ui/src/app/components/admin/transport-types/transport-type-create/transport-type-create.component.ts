import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { CreateTransportTypeRequest } from 'src/app/models/request-models/transport-types/createTransportTypeRequest';
import { TransportTypeService } from 'src/app/services/transport-type.service';

@Component({
  selector: 'app-transport-type-create',
  templateUrl: './transport-type-create.component.html',
  styleUrls: ['./transport-type-create.component.css']
})
export class TransportTypeCreateComponent {
  transportTypeAddForm: FormGroup;

  constructor(
    private transportTypeService: TransportTypeService,
    private formBuilder: FormBuilder,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private translate: TranslateService
  ) {}

  ngOnInit(): void {
    this.createTransportTypeAddForm();
  }

  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }

  createTransportTypeAddForm() {
    this.transportTypeAddForm = this.formBuilder.group({
      type: ['', Validators.required],
    });
  }

  add() {
    if (!this.transportTypeAddForm.valid) {
      this.toastrService.error('form is invalid', 'Form Error');
      return;
    }

    let transportTypeModel: CreateTransportTypeRequest = Object.assign(
      {},
      this.transportTypeAddForm.value
    );

    this.transportTypeService.create(transportTypeModel).subscribe((response) => {
      this.toastrService.success(
        response.type + ' added',
        this.translate.instant('successful')
      );
    });
  }
}
