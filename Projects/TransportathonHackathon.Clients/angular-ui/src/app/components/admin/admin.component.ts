import { User } from './../../models/entities/user';
import { TokenService } from 'src/app/services/token.service';
import { ToastrService } from 'ngx-toastr';
import { Router, ActivatedRoute, NavigationStart } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { SizeProp } from '@fortawesome/fontawesome-svg-core';
import {
  faClipboardList,
  faCogs,
  faGlobe,
  faImages,
  faLandmark,
  faLanguage,
  faTachometerAlt,
  faUsers,
  faUsersCog,
} from '@fortawesome/free-solid-svg-icons';
import { AuthService } from 'src/app/services/auth.service';
import { UserComponent } from './user/user.component';
import { ClaimComponent } from './claim/claim.component';
import { UserClaimComponent } from './user-claim/user-claim.component';
import { TranslateComponent } from './translate/translate.component';
import { LanguageComponent } from './language/language.component';
import { environment } from 'src/environments/environment';

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
  projectName = environment.projectName;
  
  currentMainPage: string = '';
  currentComponent: any;

  constructor(
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private authService: AuthService,
    private toastrService: ToastrService,
    private tokenService: TokenService
  ) {}

  ngOnInit(): void {
    this.subscribeRoute();
    this.runTooltipSelectorJs();
    // this.runActiveStateManagementScript();
  }

  runTooltipSelectorJs() {
    // const tooltipTriggerList = document.querySelectorAll(
    //   '[data-bs-toggle="tooltip"]'
    // );
    // const tooltipList = [...tooltipTriggerList].map(
    //   (tooltipTriggerEl) => new bootstrap.Tooltip(tooltipTriggerEl)
    // );
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

  getUserInfo(): User {
    return this.tokenService.getUserWithJWT();
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
        case 'manage-users':
          this.currentComponent = UserComponent;
          break;
        case 'manage-claims':
          this.currentComponent = ClaimComponent;
          break;
        case 'manage-user-claims':
          this.currentComponent = UserClaimComponent;
          break;
        case 'manage-translates':
          this.currentComponent = TranslateComponent;
          break;
        case 'manage-languages':
          this.currentComponent = LanguageComponent;
          break;
        default:
          this.currentComponent = UserComponent;
          break;
      }
    });
  }
}
