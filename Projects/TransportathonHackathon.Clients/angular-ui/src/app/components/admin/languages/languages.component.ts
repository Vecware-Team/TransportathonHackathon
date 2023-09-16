import { Component } from '@angular/core';
import { faEdit, faRedoAlt, faTrash } from '@fortawesome/free-solid-svg-icons';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { GetListLanguageResponse } from 'src/app/models/response-models/languages/getListLanguageResponse';
import { LanguageService } from 'src/app/services/language.service';
import { LanguageUpdateComponent } from './language-update/language-update.component';
import { LanguageCreateComponent } from './language-create/language-create.component';
import { LanguageDeleteComponent } from './language-delete/language-delete.component';
import { Language } from 'src/app/models/domain-models/language';
import { DeleteLanguageRequest } from 'src/app/models/request-models/languages/deleteLanguageRequest';

@Component({
  selector: 'app-languages',
  templateUrl: './languages.component.html',
  styleUrls: ['./languages.component.css'],
})
export class LanguagesComponent {
  faRedoAlt = faRedoAlt;
  faTrash = faTrash;
  faEdit = faEdit;
  dataLoaded = false;
  languages: GetListLanguageResponse[] = [];

  constructor(
    private languageService: LanguageService,
    private modalService: NgbModal
  ) {}
  ngOnInit(): void {
    this.getList();
  }

  getPageCounts(): number[] {
    return Array.from(Array(this.languages).keys());
  }

  openCreateLanguageModal() {
    var modalReferance = this.modalService.open(LanguageCreateComponent, {
      size: 'm',
      modalDialogClass: 'modal-dialog-centered',
    });
    modalReferance.closed.subscribe({
      next: () => {
        this.getList();
      },
    });
  }

  openUpdateLanguageModal(language: GetListLanguageResponse) {
    var modalReferance = this.modalService.open(LanguageUpdateComponent, {
      size: 'm',
      modalDialogClass: 'modal-dialog-centered',
    });
    modalReferance.closed.subscribe({
      next: () => {
        this.getList();
      },
    });
    modalReferance.componentInstance.language = language;
  }

  openDeleteLanguageModal(language: GetListLanguageResponse) {
    var modalReferance = this.modalService.open(LanguageDeleteComponent, {
      size: 'm',
      modalDialogClass: 'modal-dialog-centered',
    });
    modalReferance.closed.subscribe({
      next: () => {
        this.getList();
      },
    });
    modalReferance.componentInstance.language = language;
  }

  getList() {
    this.dataLoaded = false;
    this.languageService.getList().subscribe((response) => {
      this.languages = response;
      this.dataLoaded = true;
    });
  }
}
