import { LanguageService } from './../../../services/language.service';
import { Language } from './../../../models/entities/language';
import { Component, OnInit } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { ErrorService } from 'src/app/services/error.service';
import { allTranslates } from 'src/app/services/translation.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-language-delete',
  templateUrl: './language-delete.component.html',
  styleUrls: ['./language-delete.component.css'],
})
export class LanguageDeleteComponent implements OnInit {
  language: Language;

  constructor(
    private languageService: LanguageService,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private errorService: ErrorService,
    private translate:TranslateService
  ) {}

  ngOnInit(): void {}

  delete() {
    this.languageService.delete(this.language).subscribe(
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

    this.close();
  }

  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }
}
