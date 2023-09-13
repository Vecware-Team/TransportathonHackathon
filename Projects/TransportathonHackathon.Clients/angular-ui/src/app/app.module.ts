import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ToastrModule } from 'ngx-toastr';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslationService } from './services/translation.service';
import { HTTP_INTERCEPTORS, HttpClient } from '@angular/common/http';
import { NaviComponent } from './components/navi/navi.component';
import { FooterComponent } from './components/footer/footer.component';
import { AdminComponent } from './components/admin/admin.component';

import { CustomersComponent } from './components/admin/customers/customers.component';
import { CompaniesComponent } from './components/admin/companies/companies.component';
import { VehiclesComponent } from './components/admin/vehicles/vehicles.component';
import { EmployeesComponent } from './components/admin/employees/employees.component';
import { LanguagesComponent } from './components/admin/languages/languages.component';
import { TranslatesComponent } from './components/admin/translates/translates.component';
import { UsersComponent } from './components/admin/users/users.component';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { HttpClientModule } from '@angular/common/http';
import * as $ from 'jquery';
import { TranslateDeleteComponent } from './components/admin/translates/translate-delete/translate-delete.component';
import { LanguageDeleteComponent } from './components/admin/languages/language-delete/language-delete.component';
import { LanguageUpdateComponent } from './components/admin/languages/language-update/language-update.component';
import { LanguageCreateComponent } from './components/admin/languages/language-create/language-create.component';
import { TranslateCreateComponent } from './components/admin/translates/translate-create/translate-create.component';
import { TranslateUpdateComponent } from './components/admin/translates/translate-update/translate-update.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RegisterComponent } from './components/register/register.component';
import { RegisterCarrierComponent } from './components/register/register-carrier/register-carrier.component';
import { RegisterCompanyComponent } from './components/register/register-company/register-company.component';
import { RegisterCustomerComponent } from './components/register/register-customer/register-customer.component';
import { RegisterDriverComponent } from './components/register/register-driver/register-driver.component';
import { ErrorInterceptor } from './interceptors/error.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    NaviComponent,
    FooterComponent,
    AdminComponent,
    CustomersComponent,
    CompaniesComponent,
    VehiclesComponent,
    EmployeesComponent,
    LanguagesComponent,
    TranslatesComponent,
    UsersComponent,
    LanguageDeleteComponent,
    LanguageUpdateComponent,
    LanguageCreateComponent,
    TranslateCreateComponent,
    TranslateUpdateComponent,
    TranslateDeleteComponent,
    RegisterComponent,
    RegisterCarrierComponent,
    RegisterCompanyComponent,
    RegisterCustomerComponent,
    RegisterDriverComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    ToastrModule.forRoot({ positionClass: 'toast-bottom-right' }),
    FontAwesomeModule,
    ReactiveFormsModule,
    NgbModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useClass: TranslationService,
        deps: [HttpClient],
      },
    }),
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorInterceptor,
      multi: true,
    },
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
