import { Component, OnInit } from '@angular/core';
import { GetListCompanyResponse } from 'src/app/models/response-models/companies/getListCompanyResponse';
import { CompanyService } from 'src/app/services/company.service';
import { ScrollService } from 'src/app/services/scroll.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  companies: GetListCompanyResponse[];
  constructor(
    private scrollService: ScrollService,
    private companyService: CompanyService
  ) {}

  ngOnInit(): void {
    this.getList();
  }

  getList() {
    this.companyService
      .getList({ index: 0, size: 100 })
      .subscribe((response) => {
        this.companies = response.items;
      });
  }

  scrollTop(url: string, id: string) {
    this.scrollService.navigate(url, id, 0);
  }
}
