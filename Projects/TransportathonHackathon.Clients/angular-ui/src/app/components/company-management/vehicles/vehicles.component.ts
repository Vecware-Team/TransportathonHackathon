import { Component, OnInit } from '@angular/core';
import { faEdit, faRedoAlt, faTrash } from '@fortawesome/free-solid-svg-icons';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { GetByIdCompanyResponse } from 'src/app/models/response-models/companies/getByIdCompanyResponse';
import { GetByCompanyIdVehicleResponse } from 'src/app/models/response-models/vehicles/getByCompanyIdVehicleResponse';
import { CompanyService } from 'src/app/services/company.service';
import { TokenService } from 'src/app/services/token.service';
import { VehicleService } from 'src/app/services/vehicle.service';
import { CarAddComponent } from './cars/car-add/car-add.component';
import { CarDeleteComponent } from './cars/car-delete/car-delete.component';
import { CarUpdateComponent } from './cars/car-update/car-update.component';
import { TruckAddComponent } from './trucks/truck-add/truck-add.component';
import { TruckDeleteComponent } from './trucks/truck-delete/truck-delete.component';
import { TruckUpdateComponent } from './trucks/truck-update/truck-update.component';
import { PickupTruckAddComponent } from './pickup-trucks/pickup-truck-add/pickup-truck-add.component';
import { PickupTruckDeleteComponent } from './pickup-trucks/pickup-truck-delete/pickup-truck-delete.component';
import { PickupTruckUpdateComponent } from './pickup-trucks/pickup-truck-update/pickup-truck-update.component';

@Component({
  selector: 'app-vehicles',
  templateUrl: './vehicles.component.html',
  styleUrls: ['./vehicles.component.css'],
})
export class VehiclesComponent implements OnInit {
  faRedoAlt = faRedoAlt;
  faTrash = faTrash;
  faEdit = faEdit;
  vehicles: GetByCompanyIdVehicleResponse[];
  company: GetByIdCompanyResponse;
  dataLoaded = false;
  constructor(
    private vehicleService: VehicleService,
    private companyService: CompanyService,
    private modalService: NgbModal,
    private tokenService: TokenService
  ) {}

  ngOnInit(): void {
    this.getCompany();
  }

  getPageCounts(): number[] {
    return Array.from(Array(this.vehicles).keys());
  }

  getCompany() {
    let userToken = this.tokenService.getUserWithJWT()!;
    this.companyService.getById(userToken.id).subscribe((response) => {
      this.company = response;
      this.getList();
    });
  }

  getVehicleType(vehicle: GetByCompanyIdVehicleResponse): string {
    if (vehicle.car) {
      return 'Car';
    } else if (vehicle.truck) {
      return 'Truck';
    } else if (vehicle.pickupTruck) {
      return 'PickupTruck';
    } else {
      return 'Vehicle';
    }
  }

  openModal(modalName: string, objectToModify: any = null) {
    let component: any;
    modalName = modalName.toLocaleLowerCase();

    switch (modalName) {
      case 'car-add':
        component = CarAddComponent;
        break;
      case 'car-delete':
        component = CarDeleteComponent;
        break;
      case 'car-update':
        component = CarUpdateComponent;
        break;
      case 'truck-add':
        component = TruckAddComponent;
        break;
      case 'truck-delete':
        component = TruckDeleteComponent;
        break;
      case 'truck-update':
        component = TruckUpdateComponent;
        break;
      case 'pickuptruck-add':
        component = PickupTruckAddComponent;
        break;
      case 'pickuptruck-delete':
        component = PickupTruckDeleteComponent;
        break;
      case 'pickuptruck-update':
        component = PickupTruckUpdateComponent;
        break;
      default:
        component = null;
        break;
    }

    var modalReferance = this.modalService.open(component, {
      size: 'm',
      modalDialogClass: 'modal-dialog-centered',
    });
    modalReferance.closed.subscribe({
      next: () => {
        this.getList();
      },
    });
    modalReferance.componentInstance.company = this.company;
    if (objectToModify !== null) {
      modalReferance.componentInstance.objectToModify = objectToModify;
    }
  }

  getList() {
    this.dataLoaded = false;
    this.vehicleService
      .getListByCompanyId({ companyId: this.company.appUserId })
      .subscribe((response) => {
        this.vehicles = response;
        this.dataLoaded = true;
      });
  }
}
