import { Injectable } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class SettingsService {
  defaultLanguageCode: string = 'tr-TR';

  constructor(
    private router: ActivatedRoute
  ) {}

  getLanguageCodeFromRoute(): string {
    let code = this.router.snapshot.paramMap.get('code');

    if (code == null) {
      this.setLanguageOnLocalStorage(this.defaultLanguageCode);
      return this.defaultLanguageCode;
    } else {
      this.setLanguageOnLocalStorage(code);
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

  setLanguageOnLocalStorage(languageCode: string) {
    localStorage.setItem('code', languageCode);
  }
}
