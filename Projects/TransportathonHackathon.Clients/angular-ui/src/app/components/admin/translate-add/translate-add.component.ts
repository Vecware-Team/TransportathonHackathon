import { LanguageService } from './../../../services/language.service';
import { Language } from './../../../models/entities/language';
import { Translate } from './../../../models/entities/translate';
import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { ErrorService } from 'src/app/services/error.service';
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  ValidationErrors,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { TranslationApiService, allTranslates } from 'src/app/services/translation.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-translate-add',
  templateUrl: './translate-add.component.html',
  styleUrls: ['./translate-add.component.css'],
})
export class TranslateAddComponent implements OnInit {
  translateAddForm: FormGroup;
  languages: Language[] = [];
  constructor(
    private translateService: TranslateService,
    private formBuilder: FormBuilder,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private errorService: ErrorService,
    private languageService: LanguageService,
    private translationApi:TranslationApiService
  ) {}

  ngOnInit(): void {
    this.createTranslateAddForm();
    this.getAllLanguages();
  }

  getAllLanguages() {
    this.languageService.getAll().subscribe((response) => {
      this.languages = response.data;
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
      key: ['', Validators.required],
      languageId: ['', Validators.required],
      value: ['', Validators.required],
    });
  }

  add() {
    if (this.translateAddForm.valid) {
      let translateModel: Translate = Object.assign(
        {},
        this.translateAddForm.value
      );

      translateModel.languageId = +translateModel.languageId;

      this.translationApi.add(translateModel).subscribe(
        (response) => {
          this.toastrService.success(
            response.message,
            this.translateService.instant('successful')
          );
        },
        (responseError) => {
          this.errorService.writeErrorMessages(responseError);
        }
      );
    }
  }
}
