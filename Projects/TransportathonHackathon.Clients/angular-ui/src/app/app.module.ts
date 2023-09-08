import { AuthInterceptor } from './interceptors/auth.interceptor';
import {
  HTTP_INTERCEPTORS,
  HttpClient,
  HttpClientModule,
} from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { AppRoutingModule } from './app-routing.module';
import { LocationStrategy, PathLocationStrategy } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { FooterComponent } from './components/footer/footer.component';
import { HomeComponent } from './components/home/home.component';
import { NaviComponent } from './components/navi/navi.component';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { ContactComponent } from './components/contact/contact.component';
import { TranslateComponent } from './components/admin/translate/translate.component';
import { TranslateUpdateComponent } from './components/admin/translate-update/translate-update.component';
import { TranslateDeleteComponent } from './components/admin/translate-delete/translate-delete.component';
import { TranslateAddComponent } from './components/admin/translate-add/translate-add.component';
import { AdminComponent } from './components/admin/admin.component';
import { LanguageComponent } from './components/admin/language/language.component';
import { LanguageAddComponent } from './components/admin/language-add/language-add.component';
import { LanguageDeleteComponent } from './components/admin/language-delete/language-delete.component';
import { LanguageUpdateComponent } from './components/admin/language-update/language-update.component';

import { TranslationApiService } from './services/translation.service';
import { TranslateSearchFilterPipe } from './pipes/translate-search-filter.pipe';
import { SearchFilterPipe } from './pipes/search-filter.pipe';
import { SafePipe } from './pipes/safe.pipe';
import { SharedModule } from './shared/shared.module';
import { PpComponent } from './components/pp/pp.component';
import { PpAddComponent } from './components/pp/pp-add/pp-add.component';
import { PpDeleteComponent } from './components/pp/pp-delete/pp-delete.component';
import { NgxFileDropModule } from 'ngx-file-drop';
import { CoreModule } from './core/core.module';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { FaIconLibrary } from '@fortawesome/angular-fontawesome';
import { ToastrModule } from 'ngx-toastr';

@NgModule({
  declarations: [
    AppComponent,
    LanguageComponent,
    LanguageAddComponent,
    LanguageDeleteComponent,
    LanguageUpdateComponent,
    FooterComponent,
    HomeComponent,
    NaviComponent,
    AboutUsComponent,
    ContactComponent,
    TranslateComponent,
    TranslateUpdateComponent,
    TranslateDeleteComponent,
    TranslateAddComponent,
    AdminComponent,
    TranslateSearchFilterPipe,
    SearchFilterPipe,
    SafePipe,
    PpComponent,
    PpAddComponent,
    PpDeleteComponent,
  ],
  imports: [
    CoreModule,
    BrowserModule,
    AppRoutingModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FontAwesomeModule,
    NgbModule,
    NgxFileDropModule,
    SharedModule,
    ToastrModule.forRoot({
      positionClass: 'toast-bottom-right',
    }),
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useClass: TranslationApiService,
        deps: [HttpClient],
      },
    }),
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    { provide: LocationStrategy, useClass: PathLocationStrategy },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
