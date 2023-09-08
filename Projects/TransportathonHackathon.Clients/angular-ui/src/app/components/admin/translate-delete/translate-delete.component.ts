import { Translate } from './../../../models/entities/translate';
import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { ErrorService } from 'src/app/services/error.service';
import { TranslationApiService, allTranslates } from 'src/app/services/translation.service';

@Component({
  selector: 'app-translate-delete',
  templateUrl: './translate-delete.component.html',
  styleUrls: ['./translate-delete.component.css'],
})
export class TranslateDeleteComponent implements OnInit {
  translate: Translate;

  constructor(
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private errorService: ErrorService,
    private translationApi: TranslationApiService,
    private translateService:TranslateService
  ) {}

  ngOnInit(): void {}

  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }

  delete() {
    this.translationApi.delete(this.translate).subscribe((response) => {
      this.toastrService.success(
        response.message,
        this.translateService.instant('successful')
      );
      this.close();
    });
  }
}
