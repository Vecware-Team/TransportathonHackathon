import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { CreateLanguageRequest } from 'src/app/models/request-models/languages/createLanguageRequest';
import { LanguageService } from 'src/app/services/language.service';

@Component({
  selector: 'app-language-create',
  templateUrl: './language-create.component.html',
  styleUrls: ['./language-create.component.css'],
})
export class LanguageCreateComponent {
  languageAddForm: FormGroup;

  constructor(
    private languageService: LanguageService,
    private formBuilder: FormBuilder,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private translate: TranslateService
  ) {}

  ngOnInit(): void {
    this.createLanguageAddForm();
  }

  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }

  createLanguageAddForm() {
    this.languageAddForm = this.formBuilder.group({
      code: ['', Validators.required],
      globallyName: ['', Validators.required],
      locallyName: ['', Validators.required],
    });
  }

  add() {
    if (!this.languageAddForm.valid) {
      this.toastrService.error('form is invalid', 'Form Error');
      return;
    }

    let languageModel: CreateLanguageRequest = Object.assign(
      {},
      this.languageAddForm.value
    );

    this.languageService.create(languageModel).subscribe((response) => {
      this.toastrService.success(
        response.globallyName + ' added',
        this.translate.instant('successful')
      );
      this.close();
    });
  }
}
