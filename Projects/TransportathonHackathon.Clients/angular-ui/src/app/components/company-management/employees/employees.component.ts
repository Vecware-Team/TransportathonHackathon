import { Component } from '@angular/core';
import { faEdit, faRedoAlt, faTrash } from '@fortawesome/free-solid-svg-icons';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Employee } from 'src/app/models/domain-models/employee';
import { GetByIdCompanyResponse } from 'src/app/models/response-models/companies/getByIdCompanyResponse';
import { GetByCompanyIdEmployeeResponse } from 'src/app/models/response-models/employees/getByCompanyIdEmployeeResponse';
import { CompanyService } from 'src/app/services/company.service';
import { EmployeeService } from 'src/app/services/employee.service';
import { TokenService } from 'src/app/services/token.service';
import { HireOutDriverComponent } from './hire-out-driver/hire-out-driver.component';
import { HireCarrierComponent } from './hire-carrier/hire-carrier.component';
import { HireOutCarrierComponent } from './hire-out-carrier/hire-out-carrier.component';
import { HireDriverComponent } from './hire-driver/hire-driver.component';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css'],
})
export class EmployeesComponent {
  faRedoAlt = faRedoAlt;
  faTrash = faTrash;
  faEdit = faEdit;
  dataLoaded = false;
  employees: GetByCompanyIdEmployeeResponse[] = [];
  company: GetByIdCompanyResponse;

  constructor(
    private employeeService: EmployeeService,
    private companyService: CompanyService,
    private modalService: NgbModal,
    private tokenService: TokenService
  ) {}

  ngOnInit(): void {
    this.getCompany();
  }

  getCompany() {
    let userToken = this.tokenService.getUserWithJWT()!;
    this.companyService.getById(userToken.id).subscribe((response) => {
      this.company = response;
      this.getList();
    });
  }

  getPageCounts(): number[] {
    return Array.from(Array(this.employees).keys());
  }

  openHireDriverModal() {
    var modalReferance = this.modalService.open(HireDriverComponent, {
      size: 'm',
      modalDialogClass: 'modal-dialog-centered',
    });
    modalReferance.closed.subscribe({
      next: () => {
        this.getList();
      },
    });
    modalReferance.componentInstance.company = this.company;
  }

  openHireOutDriverModal(employee: GetByCompanyIdEmployeeResponse) {
    var modalReferance = this.modalService.open(HireOutDriverComponent, {
      size: 'm',
      modalDialogClass: 'modal-dialog-centered',
    });
    modalReferance.closed.subscribe({
      next: () => {
        this.getList();
      },
    });
    modalReferance.componentInstance.driver = employee;
  }

  openHireCarrierModal() {
    var modalReferance = this.modalService.open(HireCarrierComponent, {
      size: 'm',
      modalDialogClass: 'modal-dialog-centered',
    });
    modalReferance.closed.subscribe({
      next: () => {
        this.getList();
      },
    });
    modalReferance.componentInstance.company = this.company;
  }

  openHireOutCarrierModal(employee: GetByCompanyIdEmployeeResponse) {
    var modalReferance = this.modalService.open(HireOutCarrierComponent, {
      size: 'm',
      modalDialogClass: 'modal-dialog-centered',
    });
    modalReferance.closed.subscribe({
      next: () => {
        this.getList();
      },
    });
    modalReferance.componentInstance.carrier = employee;
  }

  getEmployeeType(employee: GetByCompanyIdEmployeeResponse): string {
    if (employee.carrier) {
      return 'carrier';
    } else if (employee.driver) {
      return 'driver';
    } else {
      return 'employee';
    }
  }

  getList() {
    this.dataLoaded = false;
    this.employeeService
      .getListByCompanyId({ companyId: this.company.appUserId })
      .subscribe((response) => {
        this.employees = response;
        this.dataLoaded = true;
      });
  }
}
