import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Paginate } from 'src/app/core/models/pagination/paginate';
import { GetByIdCompanyResponse } from 'src/app/models/response-models/companies/getByIdCompanyResponse';
import { GetListDynamicCompanyResponse } from 'src/app/models/response-models/companies/getListDynamicCompanyResponse';
import { CompanyService } from 'src/app/services/company.service';

@Component({
  selector: 'app-company-details',
  templateUrl: './company-details.component.html',
  styleUrls: ['./company-details.component.css'],
})
export class CompanyDetailsComponent implements OnInit {
  company: GetByIdCompanyResponse;

  constructor(
    private companyService: CompanyService,
    private activatedRoute: ActivatedRoute
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
