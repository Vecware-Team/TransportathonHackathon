import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
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
  dataLoaded = false;

  constructor(
    private companyService: CompanyService,
    private tokenService: TokenService,
    private activatedRoute: ActivatedRoute,
    private router: Router
  ) {}

  ngOnInit(): void {
    this.getUserToken();
    this.subscribeRoute();
  }

  subscribeRoute() {
    this.activatedRoute.queryParams.subscribe((param) => {
      if (param['size'] && param['index']) {
        this.pageSize = param['size'];
        this.pageIndex = param['index'];
      }
      this.getCompanies(this.pageIndex);
    });
  }

  getUserToken() {
    this.appUser = this.tokenService.getUserWithJWT()!;
  }

  getPageCount(): number[] {
    return Array.from({ length: this.companies.pages }, (v, k) => k);
  }

  updateRoute(index: number) {
    this.router.navigate([], {
      relativeTo: this.activatedRoute,
      queryParams: { index: this.pageIndex, size: this.pageSize },
      queryParamsHandling: 'merge',
    });
  }

  getCompanies(index: number = 0) {
    this.pageIndex = index;
    this.dataLoaded = false;
    this.companyService
      .getList({ size: this.pageSize, index: index })
      .subscribe((response) => {
        this.companies = response;
        this.dataLoaded = true;
      });
  }
}
