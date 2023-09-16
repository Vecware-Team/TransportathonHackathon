import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { UpdateLanguageRequest } from 'src/app/models/request-models/languages/updateLanguageRequest';
import { GetListLanguageResponse } from 'src/app/models/response-models/languages/getListLanguageResponse';
import { LanguageService } from 'src/app/services/language.service';

@Component({
  selector: 'app-language-update',
  templateUrl: './language-update.component.html',
  styleUrls: ['./language-update.component.css'],
})
export class LanguageUpdateComponent {
  languageUpdateForm: FormGroup;
  language: GetListLanguageResponse;

  constructor(
    private languageService: LanguageService,
    private formBuilder: FormBuilder,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private translate: TranslateService
  ) {}

  ngOnInit(): void {
    this.createLanguageUpdateForm();
  }

  close() {
    this.activeModal.close('Delete Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Delete Modal Dismissed');
  }

  createLanguageUpdateForm() {
    this.languageUpdateForm = this.formBuilder.group({
      code: [this.language.code, Validators.required],
      globallyName: [this.language.globallyName, Validators.required],
      locallyName: [this.language.locallyName, Validators.required],
    });
  }

  updateLanguage() {
    if (!this.languageUpdateForm.valid) {
      this.toastrService.error('Form is invalid', 'Form Error');
      return;
    }

    let languageModel: UpdateLanguageRequest = Object.assign(
      {},
      this.languageUpdateForm.value
    );
    languageModel.id = this.language.id;
    
    this.languageService.update(languageModel).subscribe((response) => {
      this.toastrService.success(
        response.globallyName + ' updated',
        this.translate.instant('successful')
      );
      this.close();
    });
  }
}
