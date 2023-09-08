import { LanguageService } from './../../../services/language.service';
import { Component, OnInit } from '@angular/core';
import {
  AbstractControl,
  FormBuilder,
  FormControl,
  FormGroup,
  ValidationErrors,
  ValidatorFn,
  Validators,
} from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { Language } from 'src/app/models/entities/language';
import { ErrorService } from 'src/app/services/error.service';
import { allTranslates } from 'src/app/services/translation.service';

@Component({
  selector: 'app-language-add',
  templateUrl: './language-add.component.html',
  styleUrls: ['./language-add.component.css'],
})
export class LanguageAddComponent implements OnInit {
  languageAddForm: FormGroup;
  language:Language;
  
  constructor(
    private formBuilder: FormBuilder,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private errorService: ErrorService,
    private languageService: LanguageService,
    private translate:TranslateService
  ) {}

  ngOnInit(): void {
    this.createLanguageAddForm();
  }

  createLanguageAddForm() {
   this.languageAddForm = this.formBuilder.group({
      languageName: ['', Validators.required],
      code: ['', Validators.required],
    });
  }

  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }

  add() {
    if (this.languageAddForm.valid) {
      let languageModel: Language = Object.assign(
        {},
        this.languageAddForm.value
      );

      this.languageService.add(languageModel).subscribe(
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
