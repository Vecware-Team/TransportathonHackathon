import { Component, OnInit } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { GetListLanguageResponse } from 'src/app/models/response-models/languages/getListLanguageResponse';
import { LanguageService } from 'src/app/services/language.service';
import { SettingsService } from 'src/app/services/settings.service';

@Component({
  selector: 'app-settings',
  templateUrl: './settings.component.html',
  styleUrls: ['./settings.component.css'],
})
export class SettingsComponent implements OnInit {
  languages: GetListLanguageResponse[];
  languageCode: string = this.settingsService.getLanguageCodeFromLocalStorage();
  constructor(
    private translate: TranslateService,
    private settingsService: SettingsService,
    private languageService: LanguageService
  ) {}

  ngOnInit(): void {
    this.getLanguageList();
  }

  getLanguageList() {
    this.languageService.getList().subscribe((response) => {
      this.languages = response;
    });
  }

  onLanguageChanged(event: any) {
    this.settingsService.setLanguageOnLocalStorage(this.languageCode);
    this.translate.use(this.languageCode);
    window.location.reload();
  }
}
