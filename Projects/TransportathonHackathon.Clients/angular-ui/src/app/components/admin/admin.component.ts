import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, NavigationStart, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AppUser } from 'src/app/models/domain-models/appUser';
import { AuthService } from 'src/app/services/auth.service';
import { TokenService } from 'src/app/services/token.service';
import { environment } from 'src/environments/environment';
import { UsersComponent } from './users/users.component';
import { TranslatesComponent } from './translates/translates.component';
import { LanguagesComponent } from './languages/languages.component';
import {
  faClipboardList,
  faCogs,
  faCouch,
  faGlobe,
  faImages,
  faLandmark,
  faLanguage,
  faTachometerAlt,
  faUsersCog,
} from '@fortawesome/free-solid-svg-icons';
import { CustomersComponent } from './customers/customers.component';
import { TransportTypesComponent } from './transport-types/transport-types.component';

@Component({
  selector: 'app-admin',
  templateUrl: './admin.component.html',
  styleUrls: ['./admin.component.css'],
})
export class AdminComponent implements OnInit {
  faClipboardList = faClipboardList;
  faUsersCog = faUsersCog;
  faLanguage = faLanguage;
  faCogs = faCogs;
  faImages = faImages;
  faGauge = faTachometerAlt;
  faLandmark = faLandmark;
  faGlobe = faGlobe;
  faCouch = faCouch;

  projectName = environment.projectName;
  currentMainPage: string = '';
  currentComponent: any;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private toastrService: ToastrService,
    private authService: AuthService,
    private tokenService: TokenService
  ) {}
  ngOnInit(): void {
    this.subscribeRoute();
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

  signOut() {
    this.authService.signOut();
    sessionStorage.removeItem('adminCurrentPage');
    this.toastrService.info('Going to homepage...', 'Logged Out');
    this.router.navigate(['']);
  }

  subscribeRoute() {
    this.activatedRoute.params.subscribe((param) => {
      this.currentMainPage = param['currentPage'];
      switch (param['currentPage']) {
        case 'manage-customers':
          this.currentComponent = CustomersComponent;
          break;
        case 'manage-translates':
          this.currentComponent = TranslatesComponent;
          break;
        case 'manage-languages':
          this.currentComponent = LanguagesComponent;
          break;
        case 'manage-transport-types':
          this.currentComponent = TransportTypesComponent;
          break;
        default:
          this.currentComponent = CustomersComponent;
          break;
      }
    });
  }
}
