import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'angular-ui';


  constructor(private translate:TranslateService) {
    translate.setDefaultLang('tr-TR');
    translate.use('tr-TR');   
  }
}
