import { Component } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { Language } from 'src/app/models/domain-models/language';
import { DeleteLanguageRequest } from 'src/app/models/request-models/languages/deleteLanguageRequest';
import { GetListLanguageResponse } from 'src/app/models/response-models/languages/getListLanguageResponse';
import { LanguageService } from 'src/app/services/language.service';

@Component({
  selector: 'app-language-delete',
  templateUrl: './language-delete.component.html',
  styleUrls: ['./language-delete.component.css'],
})
export class LanguageDeleteComponent {
  languageAddForm: FormGroup;
  language: GetListLanguageResponse;

  constructor(
    private languageService: LanguageService,
    private formBuilder: FormBuilder,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private translate: TranslateService
  ) {}

  ngOnInit(): void {}

  close() {
    this.activeModal.close('Delete Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Delete Modal Dismissed');
  }

  deleteLanguage() {
    if (this.language.id == null) {
      this.toastrService.error('Language is invalid', 'Form Error');
      return;
    }

    let languageModel: DeleteLanguageRequest = Object.assign({}, this.language);

    this.languageService.delete(languageModel).subscribe((response) => {
      this.toastrService.success(
        response.globallyName + ' deleted',
        this.translate.instant('successful')
      );
    });
  }
}
