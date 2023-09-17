import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { CreateTranslateRequest } from 'src/app/models/request-models/translates/createTranslateRequest';
import { GetListLanguageResponse } from 'src/app/models/response-models/languages/getListLanguageResponse';
import { LanguageService } from 'src/app/services/language.service';
import { TranslationService } from 'src/app/services/translation.service';

@Component({
  selector: 'app-translate-create',
  templateUrl: './translate-create.component.html',
  styleUrls: ['./translate-create.component.css'],
})
export class TranslateCreateComponent {
  translateAddForm: FormGroup;
  languages: GetListLanguageResponse[];
  languageDataLoaded = false;

  constructor(
    private translateService: TranslationService,
    private formBuilder: FormBuilder,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private translate: TranslateService,
    private languageService: LanguageService
  ) {}

  ngOnInit(): void {
    this.createTranslateAddForm();
    this.getLanguageList();
  }

  getLanguageList() {
    this.languageDataLoaded = false;
    this.languageService.getList().subscribe((response) => {
      this.languages = response;
      this.languageDataLoaded = true;
    });
  }

  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }

  createTranslateAddForm() {
    this.translateAddForm = this.formBuilder.group({
      languageId: ['', Validators.required],
      key: ['', Validators.required],
      value: ['', Validators.required],
    });
  }

  add() {
    if (!this.translateAddForm.valid) {
      this.toastrService.error('form is invalid', 'Form Error');
      return;
    }

    let translateModel: CreateTranslateRequest = Object.assign(
      {},
      this.translateAddForm.value
    );

    this.translateService.create(translateModel).subscribe((response) => {
      this.toastrService.success(
        response.key + ' added',
        this.translate.instant('successful')
      );
    });
  }
}
