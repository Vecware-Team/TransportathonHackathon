import { ClaimDeleteComponent } from './../claim-delete/claim-delete.component';
import { ClaimUpdateComponent } from './../claim-update/claim-update.component';
import { ClaimAddComponent } from './../claim-add/claim-add.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

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
import { faEdit, faRedoAlt, faTrash } from '@fortawesome/free-solid-svg-icons';
import { OperationClaimService } from 'src/app/services/operation-claim.service';
import { OperationClaim } from 'src/app/models/entities/operationClaim';

@Component({
  selector: 'app-claim',
  templateUrl: './claim.component.html',
  styleUrls: ['./claim.component.css'],
})
export class ClaimComponent implements OnInit {
  faEdit = faEdit;
  faTrash = faTrash;
  faRedoAlt = faRedoAlt;
  operationClaims: OperationClaim[] = [];
  operationClaimAddForm: FormGroup;
  dataLoaded = false;

  constructor(
    private operationClaimService: OperationClaimService,
    private formBuilder: FormBuilder,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.getAllClaims();
  }

  getAllClaims() {
    this.dataLoaded = false;
    this.operationClaimService.getAll().subscribe((response) => {
      this.operationClaims = response.data;
      this.dataLoaded = true;
    });
  }

  openAddForm() {
    var modalReferance = this.modalService.open(ClaimAddComponent, {
      size: 'm',
    });
  }

  openUpdateForm(claim: OperationClaim) {
    var modalReferance = this.modalService.open(ClaimUpdateComponent, {
      size: 'm',
      modalDialogClass: 'modal-dialog-centered',
    });
    modalReferance.componentInstance.claim = claim;
  }

  openDeleteForm(claim: OperationClaim) {
    var modalReferance = this.modalService.open(ClaimDeleteComponent, {
      size: 'm',
      modalDialogClass: 'modal-dialog-centered',
    });
    modalReferance.componentInstance.claim = claim;
  }
}
