import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {
  HTTP_INTERCEPTORS,
  HttpClient,
  HttpClientModule,
} from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ScrollService } from './services/scroll.service';
import { SettingsService } from './services/settings.service';
import { LocationStrategy, PathLocationStrategy } from '@angular/common';
import { NaviComponent } from './components/navi/navi.component';
import { FooterComponent } from './components/footer/footer.component';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslationService } from './services/translation.service';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [AppComponent, NaviComponent, FooterComponent],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ToastrModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useClass: TranslationService,
        deps: [HttpClient],
      },
    }),
  ],
  providers: [{ provide: LocationStrategy, useClass: PathLocationStrategy }],
  bootstrap: [AppComponent],
})
export class AppModule {}
