import { Component } from '@angular/core';
import { ActivatedRoute, NavigationStart, Router } from '@angular/router';
import {
  faBriefcase,
  faClipboardList,
  faCogs,
  faGlobe,
  faImages,
  faLandmark,
  faLanguage,
  faTachometerAlt,
  faTruck,
  faTruckFast,
  faUsersCog,
} from '@fortawesome/free-solid-svg-icons';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/services/auth.service';
import { TokenService } from 'src/app/services/token.service';
import { environment } from 'src/environments/environment';
import { VehiclesComponent } from './vehicles/vehicles.component';
import { CompanyService } from 'src/app/services/company.service';
import { AppUser } from 'src/app/models/domain-models/appUser';
import { GetByIdCompanyResponse } from 'src/app/models/response-models/companies/getByIdCompanyResponse';
import { EmployeesComponent } from './employees/employees.component';

@Component({
  selector: 'app-company-management-panel',
  templateUrl: './company-management-panel.component.html',
  styleUrls: ['./company-management-panel.component.css'],
})
export class CompanyManagementPanelComponent {
  faGauge = faTachometerAlt;
  faTruck = faTruck;
  faBriefcase = faBriefcase;
  faTruckFast = faTruckFast;

  currentMainPage: string = '';
  currentComponent: any;
  company: GetByIdCompanyResponse;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private toastrService: ToastrService,
    private authService: AuthService,
    private companyService: CompanyService,
    private tokenService: TokenService
  ) {}

  ngOnInit(): void {
    this.subscribeRoute();
    this.getCompany();
  }

  getCompany() {
    let id = (this.tokenService.getUserWithJWT() as AppUser).id;
    this.companyService.getById(id).subscribe((response) => {
      this.company = response;
    });
  }

  navigate(url: string, id: string) {
    this.router.navigate([url]).then(() => {
      this.scroll(id);
    });
  }

  runActiveStateManagementScript() {
    this.router.events.subscribe((event) => {
      if (event instanceof NavigationStart) {
        $('.nav-link.nav-link-h.active').removeClass('active');
        $('.nav-link.nav-link-h').attr('routerLink', function (i, val) {
          if (val === event.url) {
            $(this).addClass('active');
          }
        });
      }
    });
  }

  scroll(id: string) {
    var element = document.getElementById(id);
    var headerOffset = 135;
    var elementPosition = element!.getBoundingClientRect().top;
    var offsetPosition = elementPosition + window.pageYOffset - headerOffset;

    window.scrollTo({
      top: offsetPosition,
      behavior: 'smooth',
    });
  }

  subscribeRoute() {
    this.activatedRoute.params.subscribe((param) => {
      this.currentMainPage = param['currentPage'];
      switch (param['currentPage']) {
        case 'manage-vehicles':
          this.currentComponent = VehiclesComponent;
          break;
        case 'manage-employees':
          this.currentComponent = EmployeesComponent;
          break;
        // case 'manage-transport-requests':
        //   this.currentComponent = ;
        //   break;
        default:
          this.currentComponent = EmployeesComponent;
          break;
      }
    });
  }
}
