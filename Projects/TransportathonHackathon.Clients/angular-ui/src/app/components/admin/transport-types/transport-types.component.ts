import { Component } from '@angular/core';
import { faEdit, faRedoAlt, faTrash } from '@fortawesome/free-solid-svg-icons';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { GetListTransportTypeResponse } from 'src/app/models/response-models/transport-types/getListTransportTypeResponse';
import { TransportTypeService } from 'src/app/services/transport-type.service';
import { TransportTypeCreateComponent } from './transport-type-create/transport-type-create.component';
import { TransportTypeDeleteComponent } from './transport-type-delete/transport-type-delete.component';
import { TransportTypeUpdateComponent } from './transport-type-update/transport-type-update.component';

@Component({
  selector: 'app-transport-types',
  templateUrl: './transport-types.component.html',
  styleUrls: ['./transport-types.component.css'],
})
export class TransportTypesComponent {
  faRedoAlt = faRedoAlt;
  faTrash = faTrash;
  faEdit = faEdit;
  dataLoaded = false;
  transportTypes: GetListTransportTypeResponse[] = [];

  constructor(
    private transportTypeService: TransportTypeService,
    private modalService: NgbModal
  ) {}
  ngOnInit(): void {
    this.getList();
  }

  openCreateTransportTypeModal() {
    var modalReferance = this.modalService.open(TransportTypeCreateComponent, {
      size: 'm',
      modalDialogClass: 'modal-dialog-centered',
    });
    modalReferance.closed.subscribe({
      next: () => {
        this.getList();
      },
    });
  }

  openUpdateTransportTypeModal(transportType: GetListTransportTypeResponse) {
    var modalReferance = this.modalService.open(TransportTypeUpdateComponent, {
      size: 'm',
      modalDialogClass: 'modal-dialog-centered',
    });
    modalReferance.closed.subscribe({
      next: () => {
        this.getList();
      },
    });
    modalReferance.componentInstance.transportType = transportType;
  }

  openDeleteTransportTypeModal(transportType: GetListTransportTypeResponse) {
    var modalReferance = this.modalService.open(TransportTypeDeleteComponent, {
      size: 'm',
      modalDialogClass: 'modal-dialog-centered',
    });
    modalReferance.closed.subscribe({
      next: () => {
        this.getList();
      },
    });
    modalReferance.componentInstance.transportType = transportType;
  }

  getList() {
    this.dataLoaded = false;
    this.transportTypeService.getList().subscribe((response) => {
      this.transportTypes = response;
      this.dataLoaded = true;
    });
  }
}
