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
import { CompanyDetailsComponent } from './components/company-details/company-details.component';
import { CustomerDetailsComponent } from './components/customer-details/customer-details.component';
import { CompanyManagementPanelComponent } from './components/company-management/company-management-panel.component';
import { CompanyListComponent } from './components/company-list/company-list.component';
import { TruckAddComponent } from './components/company-management/vehicles/trucks/truck-add/truck-add.component';

import { PickupTruckAddComponent } from './components/company-management/vehicles/pickup-trucks/pickup-truck-add/pickup-truck-add.component';

import { VehiclesComponent } from './components/company-management/vehicles/vehicles.component';
import { TruckUpdateComponent } from './components/company-management/vehicles/trucks/truck-update/truck-update.component';
import { TruckDeleteComponent } from './components/company-management/vehicles/trucks/truck-delete/truck-delete.component';
import { PickupTruckDeleteComponent } from './components/company-management/vehicles/pickup-trucks/pickup-truck-delete/pickup-truck-delete.component';
import { PickupTruckUpdateComponent } from './components/company-management/vehicles/pickup-trucks/pickup-truck-update/pickup-truck-update.component';
import { CarAddComponent } from './components/company-management/vehicles/cars/car-add/car-add.component';
import { CarDeleteComponent } from './components/company-management/vehicles/cars/car-delete/car-delete.component';
import { CarUpdateComponent } from './components/company-management/vehicles/cars/car-update/car-update.component';
import { EmployeesComponent } from './components/company-management/employees/employees.component';
import { LoginComponent } from './components/login/login.component';
import { TransportRequestsComponent } from './components/company-management/transport-requests/transport-requests.component';
import { HireCarrierComponent } from './components/company-management/employees/hire-carrier/hire-carrier.component';
import { HireDriverComponent } from './components/company-management/employees/hire-driver/hire-driver.component';
import { HireOutDriverComponent } from './components/company-management/employees/hire-out-driver/hire-out-driver.component';
import { HireOutCarrierComponent } from './components/company-management/employees/hire-out-carrier/hire-out-carrier.component';
import { httpInterceptorProviders } from './interceptors/http-request.interceptor';
import { ChatComponent } from './components/chat/chat.component';
import { ApproveTransportRequestComponent } from './components/company-management/transport-requests/approve-transport-request/approve-transport-request.component';
import { RejectTransportRequestComponent } from './components/company-management/transport-requests/reject-transport-request/reject-transport-request.component';
import { CreateTransportRequestComponent } from './components/create-transport-request/create-transport-request.component';
import { TransportTypesComponent } from './components/admin/transport-types/transport-types.component';
import { TransportTypeCreateComponent } from './components/admin/transport-types/transport-type-create/transport-type-create.component';
import { TransportTypeDeleteComponent } from './components/admin/transport-types/transport-type-delete/transport-type-delete.component';
import { TransportTypeUpdateComponent } from './components/admin/transport-types/transport-type-update/transport-type-update.component';
import { HomeComponent } from './components/home/home.component';
import { TransportRequestListComponent } from './components/transport-request-list/transport-request-list.component';
import { PaymentRequestListComponent } from './components/payment-request-list/payment-request-list.component';
import { PayTransportRequestComponent } from './components/transport-request-list/pay-transport-request/pay-transport-request.component';
import { CloseTransportRequestComponent } from './components/transport-request-list/close-transport-request/close-transport-request.component';

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
    CompanyDetailsComponent,
    CustomerDetailsComponent,
    CompanyManagementPanelComponent,
    CompanyListComponent,
    TruckAddComponent,
    TruckDeleteComponent,
    TruckUpdateComponent,
    PickupTruckAddComponent,
    PickupTruckDeleteComponent,
    PickupTruckUpdateComponent,
    CarAddComponent,
    CarDeleteComponent,
    CarUpdateComponent,
    LoginComponent,
    TransportRequestsComponent,
    HireCarrierComponent,
    HireDriverComponent,
    HireOutDriverComponent,
    HireOutCarrierComponent,
    ChatComponent,
    ApproveTransportRequestComponent,
    RejectTransportRequestComponent,
    CreateTransportRequestComponent,
    TransportTypesComponent,
    TransportTypeCreateComponent,
    TransportTypeDeleteComponent,
    TransportTypeUpdateComponent,
    HomeComponent,
    TransportRequestListComponent,
    PaymentRequestListComponent,
    PayTransportRequestComponent,
    CloseTransportRequestComponent,
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
    }, httpInterceptorProviders
  ],
  bootstrap: [AppComponent],
})
export class AppModule { }
