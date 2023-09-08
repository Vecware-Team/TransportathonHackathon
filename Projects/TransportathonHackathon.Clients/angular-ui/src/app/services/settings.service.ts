import { LanguageService } from './language.service';
import { Injectable } from '@angular/core';
import { Language } from '../models/entities/language';
import { Router, ActivatedRoute } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class SettingsService {
  defaultLanguageCode: string = 'tr-TR';

  constructor(
    private languageService: LanguageService,
    private router: ActivatedRoute
  ) {}

  getLanguageCodeFromRoute(): string {
    let code = this.router.snapshot.paramMap.get('code');

    if (code == null) {
      this.setLanguage(this.defaultLanguageCode);
      return this.defaultLanguageCode;
    } else {
      this.setLanguage(code);
      return code;
    }
  }
  
  getLanguageCodeFromLocalStorage(): string {
    let code = localStorage.getItem('code');

    if (code == null) {
      return this.defaultLanguageCode;
    } else {
      return code;
    }
  }

  setLanguage(languageCode: string) {
    localStorage.setItem('code', languageCode);
  }
}
