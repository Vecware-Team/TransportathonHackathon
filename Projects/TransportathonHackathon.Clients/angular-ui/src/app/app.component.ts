import { ViewportScroller } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Router, Scroll } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { delay, filter } from 'rxjs';
import { SettingsService } from './services/settings.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title = 'angular-ui';

  constructor(
    private translate: TranslateService,
    private router: Router,
    private viewportScroller: ViewportScroller,
    private settingsService: SettingsService
  ) {
    translate.setDefaultLang('tr-TR');
  }

  ngOnInit(): void {
    this.actvateScrollPositionRestoration();
    this.setLanguage();
  }

  setLanguage() {
    this.translate.use(this.settingsService.getLanguageCodeFromLocalStorage());
  }

  actvateScrollPositionRestoration() {
    this.router.events
      .pipe(filter((e): e is Scroll => e instanceof Scroll))
      .pipe(delay(1)) // <--------------------------- This line
      .subscribe((e) => {
        if (e.position) {
          // backward navigation
          this.viewportScroller.scrollToPosition(e.position);
        } else if (e.anchor) {
          // anchor navigation
          this.viewportScroller.scrollToAnchor(e.anchor);
        } else {
          // forward navigation
          this.viewportScroller.scrollToPosition([0, 0]);
        }
      });
  }
}
