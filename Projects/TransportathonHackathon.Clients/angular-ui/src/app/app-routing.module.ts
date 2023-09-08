import { NgModule } from '@angular/core';
import { ExtraOptions, RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ProductListComponent } from './components/product-list/product-list.component';
import { LoginGuard } from './guards/login.guard';
import { AdminGuard } from './guards/admin.guard';
import { LoginComponent } from './components/login/login.component';
import { AdminComponent } from './components/admin/admin.component';
import { TranslateComponent } from './components/admin/translate/translate.component';
import { ProductCrudComponent } from './components/product-crud/product-crud.component';
import { RegisterComponent } from './components/register/register.component';
import { PpComponent } from './components/pp/pp.component';

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
    path: 'products',
    component: ProductListComponent,
  },
  {
    path: 'profile',
    component: PpComponent,
  },
  {
    path: 'translates',
    component: TranslateComponent,
  },
  {
    path: 'admin',
    component: AdminComponent,
    canActivate: [AdminGuard, LoginGuard],
  },
  {
    path: 'admin/:currentPage',
    component: AdminComponent,
    canActivate: [AdminGuard, LoginGuard],
  },
  {
    path: 'login',
    component: LoginComponent,
  },
  {
    path: 'admin/product/add',
    component: ProductCrudComponent,
    canActivate: [AdminGuard, LoginGuard],
  },
  {
    path: 'register',
    component: RegisterComponent,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes, routerOptions)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
