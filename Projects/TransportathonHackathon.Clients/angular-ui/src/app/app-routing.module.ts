import { NgModule } from '@angular/core';
import { ExtraOptions, RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './components/admin/admin.component';
import { adminGuard } from './guards/admin.guard';
import { loginGuard } from './guards/login.guard';
import { UsersComponent } from './components/admin/users/users.component';
import { RegisterComponent } from './components/register/register.component';
import { RegisterCustomerComponent } from './components/register/register-customer/register-customer.component';
import { RegisterCompanyComponent } from './components/register/register-company/register-company.component';
import { CompanyDetailsComponent } from './components/company-details/company-details.component';
import { CompanyListComponent } from './components/company-list/company-list.component';
import { LoginComponent } from './components/login/login.component';
import { CompanyManagementPanelComponent } from './components/company-management/company-management-panel.component';
import { CustomerDetailsComponent } from './components/customer-details/customer-details.component';
import { ChatComponent } from './components/chat/chat.component';
import { companyGuard } from './guards/company.guard';
import { CreateTransportRequestComponent } from './components/create-transport-request/create-transport-request.component';
import { HomeComponent } from './components/home/home.component';
import { TransportRequestListComponent } from './components/transport-request-list/transport-request-list.component';
import { PayTransportRequestComponent } from './components/transport-request-list/pay-transport-request/pay-transport-request.component';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { ContactComponent } from './components/contact/contact.component';
import { SettingsComponent } from './components/settings/settings.component';
import { NotFoundComponent } from './components/not-found/not-found.component';

export const routerOptions: ExtraOptions = {
  onSameUrlNavigation: 'reload',
  anchorScrolling: 'enabled',
  useHash: false,
  initialNavigation: 'enabledBlocking',
};

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    component: HomeComponent,
  },
  {
    path: 'home',
    component: HomeComponent,
  },
  {
    path: 'about-us',
    component: AboutUsComponent,
  },
  {
    path: 'contact',
    component: ContactComponent,
  },
  {
    path: 'settings',
    component: SettingsComponent,
  },
  {
    path: 'transport-requests',
    component: TransportRequestListComponent,
    canActivate: [loginGuard],
  },
  {
    path: 'transport-requests/payment/:transportRequestId',
    component: PayTransportRequestComponent,
    canActivate: [loginGuard],
  },
  {
    path: 'transport-requests/create/:companyId',
    component: CreateTransportRequestComponent,
    canActivate: [loginGuard],
  },
  {
    path: 'companies',
    component: CompanyListComponent,
  },
  {
    path: 'companies/company/details/:companyId',
    component: CompanyDetailsComponent,
  },
  {
    path: 'customer/details/:customerId',
    component: CustomerDetailsComponent,
  },
  {
    path: 'company/panel',
    component: CompanyManagementPanelComponent,
    canActivate: [companyGuard, loginGuard],
  },
  {
    path: 'company/panel/:currentPage',
    component: CompanyManagementPanelComponent,
    canActivate: [companyGuard, loginGuard],
  },
  {
    path: 'chat/:receiverId',
    component: ChatComponent,
    canActivate: [loginGuard],
  },
  {
    path: 'chat',
    component: ChatComponent,
    canActivate: [loginGuard],
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'profile',
    component: CustomerDetailsComponent,
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
  {
    path: 'register/customer',
    component: RegisterCustomerComponent,
  },
  {
    path: 'register/company',
    component: RegisterCompanyComponent,
  },
  {
    path: 'admin',
    component: AdminComponent,
    canActivate: [loginGuard],
  },
  {
    path: 'admin/:currentPage',
    component: AdminComponent,
    canActivate: [loginGuard],
  },
  { path: '**', component: NotFoundComponent },

];

@NgModule({
  imports: [RouterModule.forRoot(routes, routerOptions)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
