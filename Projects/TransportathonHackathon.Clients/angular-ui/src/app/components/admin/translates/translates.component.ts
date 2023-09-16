import { Component } from '@angular/core';
import { faEdit, faRedoAlt, faTrash } from '@fortawesome/free-solid-svg-icons';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { GetListTranslateResponse } from 'src/app/models/response-models/translates/getListTranslateResponse';
import { TranslationService } from 'src/app/services/translation.service';
import { TranslateCreateComponent } from './translate-create/translate-create.component';
import { TranslateUpdateComponent } from './translate-update/translate-update.component';
import { TranslateDeleteComponent } from './translate-delete/translate-delete.component';

@Component({
  selector: 'app-translates',
  templateUrl: './translates.component.html',
  styleUrls: ['./translates.component.css'],
})
export class TranslatesComponent {
  faRedoAlt = faRedoAlt;
  faTrash = faTrash;
  faEdit = faEdit;
  dataLoaded = false;
  translates: GetListTranslateResponse[] = [];

  constructor(
    private translateService: TranslationService,
    private modalService: NgbModal
  ) {}
  ngOnInit(): void {
    this.getList();
  }

  getPageCounts(): number[] {
    return Array.from(Array(this.translates).keys());
  }

  openCreateTranslateModal() {
    var modalReferance = this.modalService.open(TranslateCreateComponent, {
      size: 'm',
      modalDialogClass: 'modal-dialog-centered',
    });
    modalReferance.closed.subscribe({
      next: () => {
        this.getList();
      },
    });
  }

  openUpdateTranslateModal(translate: GetListTranslateResponse) {
    var modalReferance = this.modalService.open(TranslateUpdateComponent, {
      size: 'm',
      modalDialogClass: 'modal-dialog-centered',
    });
    modalReferance.closed.subscribe({
      next: () => {
        this.getList();
      },
    });
    modalReferance.componentInstance.translate = translate;
  }

  openDeleteTranslateModal(translate: GetListTranslateResponse) {
    var modalReferance = this.modalService.open(TranslateDeleteComponent, {
      size: 'm',
      modalDialogClass: 'modal-dialog-centered',
    });
    modalReferance.closed.subscribe({
      next: () => {
        this.getList();
      },
    });
    modalReferance.componentInstance.translate = translate;
  }

  getList() {
    this.dataLoaded = false;
    this.translateService.getList().subscribe((response) => {
      this.translates = response;
      this.dataLoaded = true;
    });
  }
}
