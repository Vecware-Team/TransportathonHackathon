
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { OperationClaim } from 'src/app/models/entities/operationClaim';
import { ErrorService } from 'src/app/services/error.service';
import { OperationClaimService } from 'src/app/services/operation-claim.service';
import { allTranslates } from 'src/app/services/translation.service';

@Component({
  selector: 'app-claim-update',
  templateUrl: './claim-update.component.html',
  styleUrls: ['./claim-update.component.css'],
})
export class ClaimUpdateComponent implements OnInit {
  operationClaimUpdateForm: FormGroup;
  claim: OperationClaim;

  constructor(
    private formBuilder: FormBuilder,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private errorService: ErrorService,
    private operationClaimService: OperationClaimService,
    private translate:TranslateService
  ) {}

  ngOnInit(): void {
    this.createOperationClaimUpdateForm();
  }

  createOperationClaimUpdateForm() {
    this.operationClaimUpdateForm = this.formBuilder.group({
      name: [this.claim.name, Validators.required],
    });
  }

  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }

  update() {
    if (this.operationClaimUpdateForm.valid) {
      let operationClaimModel: OperationClaim = Object.assign(
        {},
        this.operationClaimUpdateForm.value
      );
      operationClaimModel.id = +this.claim.id;

      this.operationClaimService.update(operationClaimModel).subscribe(
        (response) => {
          this.toastrService.success(
            response.message,
            this.translate.instant('successful')
          );
        },
        (responseError) => {
          this.errorService.writeErrorMessages(responseError);
        }
      );
    }
  }
}
