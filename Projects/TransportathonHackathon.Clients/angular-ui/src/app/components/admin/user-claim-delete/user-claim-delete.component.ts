
import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { UserOperationClaim } from 'src/app/models/entities/userOperationClaim';
import { ErrorService } from 'src/app/services/error.service';
import { allTranslates } from 'src/app/services/translation.service';
import { UserOperationClaimService } from 'src/app/services/user-operation-claim.service';

@Component({
  selector: 'app-user-claim-delete',
  templateUrl: './user-claim-delete.component.html',
  styleUrls: ['./user-claim-delete.component.css'],
})
export class UserClaimDeleteComponent implements OnInit {
  userClaim: UserOperationClaim;
  userClaimName: string;
  
  constructor(
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private errorService: ErrorService,
    private userOperationClaimService: UserOperationClaimService,private translate:TranslateService
  ) {}

  ngOnInit(): void {}

  close() {
    this.activeModal.close('Delete Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Delete Modal Dismissed');
  }

  delete() {
    this.userOperationClaimService.delete(this.userClaim).subscribe(
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
