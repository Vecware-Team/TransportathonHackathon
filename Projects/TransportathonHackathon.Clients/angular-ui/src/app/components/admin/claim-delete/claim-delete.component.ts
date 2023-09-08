import { OperationClaim } from 'src/app/models/entities/operationClaim';
import { OperationClaimService } from 'src/app/services/operation-claim.service';
import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { ErrorService } from 'src/app/services/error.service';
import { allTranslates } from 'src/app/services/translation.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-claim-delete',
  templateUrl: './claim-delete.component.html',
  styleUrls: ['./claim-delete.component.css'],
})
export class ClaimDeleteComponent implements OnInit {
  claim: OperationClaim;

  constructor(
    private operationClaimService: OperationClaimService,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private errorService: ErrorService,
    private translate:TranslateService
  ) {}

  ngOnInit(): void {}

  delete() {
    this.operationClaimService.delete(this.claim).subscribe(
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

    this.close();
  }

  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }
}
