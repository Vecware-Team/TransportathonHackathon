import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { faMessage } from '@fortawesome/free-regular-svg-icons';
import { faStar } from '@fortawesome/free-regular-svg-icons';
import { Paginate } from 'src/app/core/models/pagination/paginate';
import { TokenUserDto } from 'src/app/models/dtos/tokenUserDto';
import { GetByIdCompanyResponse } from 'src/app/models/response-models/companies/getByIdCompanyResponse';
import { GetListDynamicCompanyResponse } from 'src/app/models/response-models/companies/getListDynamicCompanyResponse';
import { CompanyService } from 'src/app/services/company.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-company-details',
  templateUrl: './company-details.component.html',
  styleUrls: ['./company-details.component.css'],
})
export class CompanyDetailsComponent implements OnInit {
  faMessage = faMessage;
  faStar = faStar;
  company: GetByIdCompanyResponse;
  
  constructor(
    private companyService: CompanyService,
    private activatedRoute: ActivatedRoute,private tokenService:TokenService
  ) {}

  ngOnInit(): void {
    this.subscribeRoute();
  }
  subscribeRoute() {
    this.getCompany(this.activatedRoute.snapshot.params['companyId']);
  }
  getCompany(id: string) {
    this.companyService.getById(id).subscribe((response) => {
      this.company = response;
    });
  }
}
