import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { DeleteTranslateRequest } from 'src/app/models/request-models/translates/deleteTranslateRequest';
import { GetListTranslateResponse } from 'src/app/models/response-models/translates/getListTranslateResponse';
import { TranslationService } from 'src/app/services/translation.service';

@Component({
  selector: 'app-translate-delete',
  templateUrl: './translate-delete.component.html',
  styleUrls: ['./translate-delete.component.css'],
})
export class TranslateDeleteComponent {
  translate: GetListTranslateResponse;

  constructor(
    private formBuilder: FormBuilder,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private translateService: TranslateService,
    private translationService: TranslationService
  ) {}

  ngOnInit(): void {}

  close() {
    this.activeModal.close('Delete Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Delete Modal Dismissed');
  }

  deleteTranslate() {
    if (this.translate.id == null) {
      this.toastrService.error('Language is invalid', 'Form Error');
      return;
    }

    let translateModel: DeleteTranslateRequest = {
      id: this.translate.id,
    };

    this.translationService.delete(translateModel).subscribe((response) => {
      this.toastrService.success(
        response.key + ' deleted',
        this.translateService.instant('successful')
      );
      this.close();
    });
  }
}
