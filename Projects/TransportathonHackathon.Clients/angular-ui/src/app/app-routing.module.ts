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
    component: AdminComponent,
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
    path: 'register/carrier',
    component: RegisterCarrierComponent,
  },
  {
    path: 'register/driver',
    component: RegisterDriverComponent,
  },
  {
    path: 'admin',
    component: AdminComponent,
    canActivate: [adminGuard, loginGuard],
  },
  {
    path: 'admin/:currentPage',
    component: AdminComponent,
    canActivate: [adminGuard, loginGuard],
  },
  {
    path: 'admin/:currentPage',
    component: AdminComponent,
    canActivate: [adminGuard, loginGuard],
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, routerOptions)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
