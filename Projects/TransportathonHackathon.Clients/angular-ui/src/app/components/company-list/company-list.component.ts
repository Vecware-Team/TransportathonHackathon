import { Component, OnInit } from '@angular/core';
import { Paginate } from 'src/app/core/models/pagination/paginate';
import { CompanyFilter } from 'src/app/filters/companyFilter';
import { DynamicQuery } from 'src/app/models/domain-models/dynamicQuery';
import { GetListCompanyResponse } from 'src/app/models/response-models/companies/getListCompanyResponse';
import { GetListDynamicCompanyResponse } from 'src/app/models/response-models/companies/getListDynamicCompanyResponse';
import { CompanyService } from 'src/app/services/company.service';

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
  constructor(private companyService: CompanyService) {}

  ngOnInit(): void {
    this.getCompanies();
  }

  // getFilter(): DynamicQuery {
  //   let query: DynamicQuery = {
  //     sort: null,
  //     filter: null,
  //   };

  //   if (this.filter.companyNameFilter) {
  //     query.filter = {
  //       field: 'companyName',
  //       value: this.filter.companyNameFilter!,
  //       operator: 'eq',
  //       logic: null,
  //       filters:null
  //     };
  //   }

  //   return query;
  // }

  getCompanies() {
    this.companyService
      .getList(
        { size: this.pageSize, index: this.pageIndex },
      )
      .subscribe((response) => {
        this.companies = response;
      });
  }
}
