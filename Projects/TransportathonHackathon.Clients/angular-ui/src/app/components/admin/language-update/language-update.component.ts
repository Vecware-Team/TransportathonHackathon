import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { Language } from 'src/app/models/entities/language';
import { ErrorService } from 'src/app/services/error.service';
import { LanguageService } from 'src/app/services/language.service';
import { allTranslates } from 'src/app/services/translation.service';

@Component({
  selector: 'app-language-update',
  templateUrl: './language-update.component.html',
  styleUrls: ['./language-update.component.css'],
})
export class LanguageUpdateComponent implements OnInit {
  languageUpdateForm: FormGroup;
  language: Language;

  constructor(
    private formBuilder: FormBuilder,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private errorService: ErrorService,
    private languageService: LanguageService,
    private translate:TranslateService
  ) {}

  ngOnInit(): void {
    this.createLanguageUpdateForm();
  }

  createLanguageUpdateForm() {
    this.languageUpdateForm = this.formBuilder.group({
      languageName: [this.language.languageName, Validators.required],
      code: [this.language.code, Validators.required],
    });
  }

  close() {
    this.activeModal.close('Update Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Update Modal Dismissed');
  }

  update() {
    if (this.languageUpdateForm.valid) {
      let languageModel: Language = Object.assign(
        {},
        this.languageUpdateForm.value
      );

      languageModel.id = this.language.id;

      this.languageService.update(languageModel).subscribe(
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
}
