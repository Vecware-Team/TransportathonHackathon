import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { faImage } from '@fortawesome/free-solid-svg-icons';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { NgxFileDropEntry } from 'ngx-file-drop';
import { ToastrService } from 'ngx-toastr';
import { ProfilePicture } from 'src/app/models/entities/profilePicture';
import { User } from 'src/app/models/entities/user';
import { ErrorService } from 'src/app/services/error.service';
import { ProfilePictureService } from 'src/app/services/profile-picture.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-pp-add',
  templateUrl: './pp-add.component.html',
  styleUrls: ['./pp-add.component.css'],
})
export class PpAddComponent implements OnInit {
  faImage = faImage;
  ppAddForm: FormGroup;
  ppFile: NgxFileDropEntry;
  currentUser: User;
  uploading = false;

  constructor(
    private profilePictureService: ProfilePictureService,
    private toastrService: ToastrService,
    private translate: TranslateService,
    private errorService: ErrorService,
    private activeModal: NgbActiveModal,
    private tokenService: TokenService
  ) {}

  ngOnInit(): void {
    this.getUser();
  }

  getUser() {
    this.currentUser = this.tokenService.getUserWithJWT();
  }

  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }

  ppDropped(picture: NgxFileDropEntry[]) {
    this.ppFile = picture[0];
  }

  deletePicture() {
    this.ppFile = {} as NgxFileDropEntry;
  }

  uploadPicture() {
    let droppedFile = this.ppFile;
    this.uploading = true;

    if (droppedFile.fileEntry.isFile) {
      const fileEntry = droppedFile.fileEntry as FileSystemFileEntry;
      fileEntry.file((file: File) => {
        let addedPP: ProfilePicture = {
          userId: this.currentUser.id!,
          path: '',
        };

        // http post

        this.profilePictureService.add(file, addedPP).subscribe(
          (response) => {
            this.uploading = false;
            this.toastrService.success(
              response.message,
              this.translate.instant('successful')
            );
          },
          (responseError) => {
            this.errorService.writeErrorMessages(responseError);
          }
        );
      });
    }
  }
}
