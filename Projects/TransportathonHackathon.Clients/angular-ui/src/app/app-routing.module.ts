import { NgModule } from '@angular/core';
import { ExtraOptions, RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './components/admin/admin.component';
import { adminGuard } from './guards/admin.guard';
import { loginGuard } from './guards/login.guard';
import { UsersComponent } from './components/admin/users/users.component';
import { RegisterComponent } from './components/register/register.component';
import { RegisterCustomerComponent } from './components/register/register-customer/register-customer.component';
import { RegisterCompanyComponent } from './components/register/register-company/register-company.component';
import { RegisterCarrierComponent } from './components/register/register-carrier/register-carrier.component';
import { RegisterDriverComponent } from './components/register/register-driver/register-driver.component';
import { CompanyDetailsComponent } from './components/company-details/company-details.component';
import { CompanyListComponent } from './components/company-list/company-list.component';
import { LoginComponent } from './components/login/login.component';
import { CompanyManagementPanelComponent } from './components/company-management/company-management-panel.component';
import { CustomerDetailsComponent } from './components/customer-details/customer-details.component';
import { ChatComponent } from './components/chat/chat.component';
import { companyGuard } from './guards/company.guard';
import { CreateTransportRequestComponent } from './components/create-transport-request/create-transport-request.component';
import { Chat2Component } from './components/chat2/chat2.component';
import { HomeComponent } from './components/home/home.component';
import { TransportRequestListComponent } from './components/transport-request-list/transport-request-list.component';
import { PaymentRequestListComponent } from './components/payment-request-list/payment-request-list.component';

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
    path: 'my-chat',
    component: Chat2Component,
  },
  {
    path: 'transport-requests',
    component: TransportRequestListComponent,
  },
  {
    path: 'payment-requests',
    component: PaymentRequestListComponent,
  },
  {
    path: 'transport-requests/create/:companyId',
    component: CreateTransportRequestComponent,
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
    path: 'chat/:companyId',
    component: ChatComponent,
  },
  {
    path: 'chat',
    component: ChatComponent,
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
];

@NgModule({
  imports: [RouterModule.forRoot(routes, routerOptions)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
