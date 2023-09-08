import { FormBuilder, FormGroup } from '@angular/forms';
import { TranslateDeleteComponent } from './../translate-delete/translate-delete.component';

import { TranslateAddComponent } from './../translate-add/translate-add.component';

import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import {
  faEdit,
  faTrash,
  faRedoAlt,
  faSearch,
} from '@fortawesome/free-solid-svg-icons';
import { TranslateUpdateComponent } from '../translate-update/translate-update.component';
import { TranslationApiService, allTranslates } from 'src/app/services/translation.service';
import { Translate } from 'src/app/models/entities/translate';
import { Language } from 'src/app/models/entities/language';
import { LanguageService } from 'src/app/services/language.service';

@Component({
  selector: 'app-translate',
  templateUrl: './translate.component.html',
  styleUrls: ['./translate.component.css'],
})
export class TranslateComponent implements OnInit {
  translates: Translate[] = [];
  filterText: string = '';
  languageFilter: number;
  faEdit = faEdit;
  faTrash = faTrash;
  faRedoAlt = faRedoAlt;
  faSearch = faSearch;
  languages: Language[] = [];
  filterForm: FormGroup;
  dataLoaded = false;

  constructor(
    private translationApi: TranslationApiService,
    private modalService: NgbModal,
    private languageService: LanguageService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.getAll();
    this.getAllLanguages();
    this.createFilterForm();
  }
  createFilterForm() {
    this.filterForm = this.formBuilder.group({
      filterText: [''],
      languageFilter: [0],
    });
  }

  getAllLanguages() {
    this.languageService.getAll().subscribe((response) => {
      this.languages = response.data;
    });
  }

  getAll() {
    this.dataLoaded = false;
    this.translationApi.getAll().subscribe((response) => {
      this.translates = response.data;
      this.dataLoaded = true;
    });
  }

  getNameByLanguageId(languageId: number): string {
    return this.languages.find((l) => l.id === languageId)?.languageName!;
  }

  openAddForm() {
    var modalReferance = this.modalService.open(TranslateAddComponent, {
      size: 'm',
    });
  }

  openDeleteForm(translate: Translate) {
    var modalReferance = this.modalService.open(TranslateDeleteComponent, {
      size: 'm',
    });
    modalReferance.componentInstance.translate = translate;
  }

  openUpdateForm(translate: Translate) {
    var modalReferance = this.modalService.open(TranslateUpdateComponent, {
      size: 'm',
    });
    modalReferance.componentInstance.translate = translate;
  }

  filter() {
    this.filterText = this.filterForm.get('filterText')?.value;
    this.languageFilter = this.filterForm.get('languageFilter')?.value;
  }
}
