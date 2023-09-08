
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
import { User } from 'src/app/models/entities/user';
import { UserOperationClaim } from 'src/app/models/entities/userOperationClaim';
import { ErrorService } from 'src/app/services/error.service';
import { OperationClaimService } from 'src/app/services/operation-claim.service';
import { allTranslates } from 'src/app/services/translation.service';
import { UserOperationClaimService } from 'src/app/services/user-operation-claim.service';

@Component({
  selector: 'app-user-claim-add',
  templateUrl: './user-claim-add.component.html',
  styleUrls: ['./user-claim-add.component.css'],
})
export class UserClaimAddComponent implements OnInit {
  userClaimAddForm: FormGroup;
  user: User;
  operationClaims: OperationClaim[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private errorService: ErrorService,
    private operationClaimService: OperationClaimService,
    private userOperationClaimService: UserOperationClaimService,
    private translate:TranslateService
  ) {}

  ngOnInit(): void {
    this.createUserClaimAddForm();
    this.getAllOperationClaims();
  }

  getAllOperationClaims() {
    this.operationClaimService.getAll().subscribe((response) => {
      this.operationClaims = response.data;
    });
  }

  createUserClaimAddForm() {
    this.userClaimAddForm = this.formBuilder.group({
      userId: [this.user.id, Validators.required],
      operationClaimId: ['', Validators.required],
    });
  }

  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }

  add() {
    if (this.userClaimAddForm.valid) {
      let operationClaimModel: UserOperationClaim = Object.assign(
        {},
        this.userClaimAddForm.value
      );

      operationClaimModel.operationClaimId = +operationClaimModel.operationClaimId!;

      this.userOperationClaimService.add(operationClaimModel).subscribe(
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
