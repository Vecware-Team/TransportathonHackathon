import { LanguageUpdateComponent } from './../language-update/language-update.component';
import { LanguageDeleteComponent } from './../language-delete/language-delete.component';
import { LanguageAddComponent } from './../language-add/language-add.component';
import { Language } from './../../../models/entities/language';
import { Component, OnInit } from '@angular/core';
import { faEdit, faRedoAlt, faTrash } from '@fortawesome/free-solid-svg-icons';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { LanguageService } from 'src/app/services/language.service';

@Component({
  selector: 'app-language',
  templateUrl: './language.component.html',
  styleUrls: ['./language.component.css'],
})
export class LanguageComponent implements OnInit {
  faEdit = faEdit;
  faTrash = faTrash;
  faRedoAlt = faRedoAlt;

  languages: Language[] = [];
  dataLoaded = false;

  constructor(
    private modalService: NgbModal,
    private languageService: LanguageService
  ) {}

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.dataLoaded = false;
    this.languageService.getAll().subscribe((response) => {
      this.languages = response.data;
      this.dataLoaded = true;
    });
  }

  openAddForm() {
    var modalReferance = this.modalService.open(LanguageAddComponent, {
      size: 'm',
    });
  }

  openDeleteForm(language: Language) {
    var modalReferance = this.modalService.open(LanguageDeleteComponent, {
      size: 'm',
    });
    modalReferance.componentInstance.language = language;
  }

  openUpdateForm(language: Language) {
    var modalReferance = this.modalService.open(LanguageUpdateComponent, {
      size: 'm',
    });
    modalReferance.componentInstance.language = language;
  }
}
