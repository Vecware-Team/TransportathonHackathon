import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { UpdateTranslateRequest } from 'src/app/models/request-models/translates/updateTranslateRequest';
import { GetListLanguageResponse } from 'src/app/models/response-models/languages/getListLanguageResponse';
import { GetListTranslateResponse } from 'src/app/models/response-models/translates/getListTranslateResponse';
import { LanguageService } from 'src/app/services/language.service';
import { TranslationService } from 'src/app/services/translation.service';

@Component({
  selector: 'app-translate-update',
  templateUrl: './translate-update.component.html',
  styleUrls: ['./translate-update.component.css'],
})
export class TranslateUpdateComponent {
  translateUpdateForm: FormGroup;
  translate: GetListTranslateResponse;
  languages: GetListLanguageResponse[];

  constructor(
    private languageService: LanguageService,
    private translationService: TranslationService,
    private formBuilder: FormBuilder,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private translateService: TranslateService
  ) {}

  ngOnInit(): void {
    this.createTranslateUpdateForm();
    this.getLanguageList();
  }

  getLanguageList() {
    this.languageService.getList().subscribe((response) => {
      this.languages = response;
    });
  }

  close() {
    this.activeModal.close('Delete Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Delete Modal Dismissed');
  }

  createTranslateUpdateForm() {
    this.translateUpdateForm = this.formBuilder.group({
      key: [this.translate.key, Validators.required],
      languageId: [this.translate.languageId, Validators.required],
      value: [this.translate.value, Validators.required],
    });
  }

  updateTranslate() {
    if (!this.translateUpdateForm.valid) {
      this.toastrService.error('Form is invalid', 'Form Error');
      return;
    }

    let translateModel: UpdateTranslateRequest = Object.assign(
      {},
      this.translateUpdateForm.value
    );
    translateModel.id = this.translate.id;

    console.log(translateModel)
    this.translationService.update(translateModel).subscribe((response) => {
      this.toastrService.success(
        response.key + ' updated',
        this.translateService.instant('successful')
      );
    });
  }
}
