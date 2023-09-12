import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ToastrModule } from 'ngx-toastr';
import { TranslateLoader, TranslateModule } from '@ngx-translate/core';
import { TranslationService } from './services/translation.service';
import { HttpClient } from '@angular/common/http';
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
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ToastrModule.forRoot({ positionClass: 'top-right' }),
    FontAwesomeModule,
    TranslateModule.forRoot({
      loader: {
        provide: TranslateLoader,
        useClass: TranslationService,
        deps: [HttpClient],
      },
    }),
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
