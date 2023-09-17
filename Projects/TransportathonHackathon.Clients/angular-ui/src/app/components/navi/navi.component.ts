import { Component, OnInit } from '@angular/core';
import { NavigationStart, Router } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { AppUser } from 'src/app/models/domain-models/appUser';
import { Language } from 'src/app/models/domain-models/language';
import { TokenUserDto } from 'src/app/models/dtos/tokenUserDto';
import { GetListLanguageResponse } from 'src/app/models/response-models/languages/getListLanguageResponse';
import { LanguageService } from 'src/app/services/language.service';
import { SettingsService } from 'src/app/services/settings.service';
import { TokenService } from 'src/app/services/token.service';

@Component({
  selector: 'app-navi',
  templateUrl: './navi.component.html',
  styleUrls: ['./navi.component.css'],
})
export class NaviComponent implements OnInit {
  tokenUser: TokenUserDto | null;
  projectName = 'Transportathon';
  currentLanguage: GetListLanguageResponse | undefined;
  languages: GetListLanguageResponse[];

  constructor(
    private router: Router,
    private tokenService: TokenService,
    private languageService: LanguageService,
    private settingsService: SettingsService,
    private translate: TranslateService
  ) {}

  ngOnInit(): void {
    this.runActiveStateManagementScript();
    this.runCollapseScript();
    this.getUser();
    this.getLanguages();
  }

  getCurrentLanguage() {
    this.currentLanguage = this.languages.find(
      (l) => l.code == this.settingsService.getLanguageCodeFromLocalStorage()
    )!;
  }

  setLanguage(code: string) {
    this.settingsService.setLanguageOnLocalStorage(code);
    this.translate.use(code);
    window.location.reload();
  }

  getLanguages() {
    this.languageService.getList().subscribe((response) => {
      this.languages = response;
      this.getCurrentLanguage();
    });
  }

  getUser() {
    this.tokenUser = this.tokenService.getUserWithJWT() as TokenUserDto;
  }

  isLogged(): boolean {
    if (this.tokenService.getToken() !== null) {
      return true;
    }
    return false;
  }

  signOut() {
    this.tokenService.removeToken();
  }

  callCollapseEvent() {
    (<any>$('.navbar-collapse')).collapse('hide');
  }

  runCollapseScript() {
    $('.navbar-collapse .nav-link-collapse').on('click', function () {
      (<any>$('.navbar-collapse')).collapse('hide');
    });
  }

  runActiveStateManagementScript() {
    $('.nav-link').addClass('abb');

    this.router.events.subscribe((event) => {
      if (event instanceof NavigationStart) {
        $('.nav-link.nav-link-custom.active').removeClass('active');
        $('.nav-link.nav-link-custom').attr('routerLink', function (i, val) {
          if (val === event.url) {
            $(this).addClass('active');
          }

          if (event.url === '/about-us/construction-promotion-id-card') {
            $('.about-us').addClass('active');
          }
        });
      }
    });
  }
}
