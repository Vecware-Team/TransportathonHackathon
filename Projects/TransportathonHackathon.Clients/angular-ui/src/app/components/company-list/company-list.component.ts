import { Component, OnInit } from '@angular/core';
import { Paginate } from 'src/app/core/models/pagination/paginate';
import { CompanyFilter } from 'src/app/filters/companyFilter';
import { DynamicQuery } from 'src/app/models/domain-models/dynamicQuery';
import { TokenUserDto } from 'src/app/models/dtos/tokenUserDto';
import { GetListCompanyResponse } from 'src/app/models/response-models/companies/getListCompanyResponse';
import { GetListDynamicCompanyResponse } from 'src/app/models/response-models/companies/getListDynamicCompanyResponse';
import { CompanyService } from 'src/app/services/company.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-company-list',
  templateUrl: './company-list.component.html',
  styleUrls: ['./company-list.component.css'],
})
export class CompanyListComponent implements OnInit {
  companies: Paginate<GetListCompanyResponse>;
  pageSize: number = 10;
  pageIndex: number = 0;
  filter: CompanyFilter = {};
  appUser: TokenUserDto;

  constructor(
    private companyService: CompanyService,
    private tokenService: TokenService
  ) {}

  ngOnInit(): void {
    this.getUserToken();
    this.getCompanies();
  }

  getUserToken() {
    this.appUser = this.tokenService.getUserWithJWT()!;
  }

  getCompanies() {
    this.companyService
      .getList({ size: this.pageSize, index: this.pageIndex })
      .subscribe((response) => {
        this.companies = response;
      });
  }
}
