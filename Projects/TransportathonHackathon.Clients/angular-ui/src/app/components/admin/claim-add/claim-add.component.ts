import { ErrorService } from './../../../services/error.service';
import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  ValidationErrors,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { OperationClaim } from 'src/app/models/entities/operationClaim';
import { OperationClaimService } from 'src/app/services/operation-claim.service';
import { allTranslates } from 'src/app/services/translation.service';

@Component({
  selector: 'app-claim-add',
  templateUrl: './claim-add.component.html',
  styleUrls: ['./claim-add.component.css'],
})
export class ClaimAddComponent implements OnInit {
  operationClaimAddForm: FormGroup;

  constructor(
    private operationClaimService: OperationClaimService,
    private formBuilder: FormBuilder,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private errorService: ErrorService,
    private translate: TranslateService
  ) {}

  ngOnInit(): void {
    this.createOperationClaimAddForm();
  }

  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }

  createOperationClaimAddForm() {
    this.operationClaimAddForm = this.formBuilder.group({
      name: ['', Validators.required],
    });
  }

  add() {
    if (this.operationClaimAddForm.valid) {
      let operationClaimModel: OperationClaim = Object.assign(
        {},
        this.operationClaimAddForm.value
      );

      this.operationClaimService.add(operationClaimModel).subscribe(
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
