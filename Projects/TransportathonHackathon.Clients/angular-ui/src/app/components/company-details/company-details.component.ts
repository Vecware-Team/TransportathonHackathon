import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { faMessage } from '@fortawesome/free-regular-svg-icons';
import { faStar } from '@fortawesome/free-regular-svg-icons';
import { faCar, faTruck, faUser } from '@fortawesome/free-solid-svg-icons';
import { Paginate } from 'src/app/core/models/pagination/paginate';
import { TokenUserDto } from 'src/app/models/dtos/tokenUserDto';
import { GetByIdCompanyResponse } from 'src/app/models/response-models/companies/getByIdCompanyResponse';
import { GetListDynamicCompanyResponse } from 'src/app/models/response-models/companies/getListDynamicCompanyResponse';
import { GetByCompanyIdDriverResponse } from 'src/app/models/response-models/drivers/getByCompanyIdDriverResponse';
import { GetByCompanyIdEmployeeResponse } from 'src/app/models/response-models/employees/getByCompanyIdEmployeeResponse';
import { GetByCompanyIdVehicleResponse } from 'src/app/models/response-models/vehicles/getByCompanyIdVehicleResponse';
import { CompanyService } from 'src/app/services/company.service';
import { EmployeeService } from 'src/app/services/employee.service';
import { TokenService } from 'src/app/services/token.service';
import { VehicleService } from 'src/app/services/vehicle.service';

@Component({
  selector: 'app-company-details',
  templateUrl: './company-details.component.html',
  styleUrls: ['./company-details.component.css'],
})
export class CompanyDetailsComponent implements OnInit {
  faMessage = faMessage;
  faTruck = faTruck;
  faCar = faCar;
  faStar = faStar;
  faUser = faUser;
  company: GetByIdCompanyResponse;
  vehicles: GetByCompanyIdVehicleResponse[];
  employees: GetByCompanyIdEmployeeResponse[];

  constructor(
    private companyService: CompanyService,
    private activatedRoute: ActivatedRoute,
    private tokenService: TokenService,
    private vehicleService: VehicleService,
    private employeeService: EmployeeService
  ) {}

  ngOnInit(): void {
    this.subscribeRoute();
  }
  subscribeRoute() {
    this.getCompany(this.activatedRoute.snapshot.params['companyId']);
  }

  isSigned(): boolean {
    if (this.tokenService.getToken() === null) {
      return false;
    }
    return true;
  }

  getVehicles() {
    this.vehicleService
      .getListByCompanyId({ companyId: this.company.appUserId })
      .subscribe((response) => {
        this.vehicles = response;
      });
  }

  getEmployees() {
    this.employeeService
      .getListByCompanyId({ companyId: this.company.appUserId })
      .subscribe((response) => {
        this.employees = response;
      });
  }

  getCompany(id: string) {
    this.companyService.getById(id).subscribe((response) => {
      this.company = response;
      this.getVehicles();
      this.getEmployees();
    });
  }
}
