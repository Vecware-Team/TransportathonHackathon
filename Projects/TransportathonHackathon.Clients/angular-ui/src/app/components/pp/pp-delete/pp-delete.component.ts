import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { ProfilePicture } from 'src/app/models/entities/profilePicture';
import { ErrorService } from 'src/app/services/error.service';
import { ProfilePictureService } from 'src/app/services/profile-picture.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-pp-delete',
  templateUrl: './pp-delete.component.html',
  styleUrls: ['./pp-delete.component.css'],
})
export class PpDeleteComponent implements OnInit {
  pp: ProfilePicture;
  baseUrl=environment.baseUrl
  constructor(
    private profilePictureService: ProfilePictureService,
    private toastrService: ToastrService,
    private translate: TranslateService,
    private errorService: ErrorService,
    private activeModal: NgbActiveModal
  ) {}

  ngOnInit(): void {}

  delete() {
    this.profilePictureService.delete(this.pp).subscribe(
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
    this.activeModal.close('Delete Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Delete Modal Dismissed');
  }
}
