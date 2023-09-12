import { Component } from '@angular/core';
import { faRedoAlt } from '@fortawesome/free-solid-svg-icons';
import { GetListLanguageResponse } from 'src/app/models/response-models/languages/getListLanguageResponse';
import { LanguageService } from 'src/app/services/language.service';

@Component({
  selector: 'app-languages',
  templateUrl: './languages.component.html',
  styleUrls: ['./languages.component.css'],
})
export class LanguagesComponent {
  faRedoAlt = faRedoAlt;
  dataLoaded = false;
  languages: GetListLanguageResponse[] = [];

  constructor(private languageService: LanguageService) {}
  ngOnInit(): void {
    this.getList();
  }

  getPageCounts(): number[] {
    return Array.from(Array(this.languages).keys());
  }

  getList() {
    this.dataLoaded = false;
    this.languageService.getList().subscribe((response) => {
      this.languages = response;
      this.dataLoaded = true;
    });
  }
}
