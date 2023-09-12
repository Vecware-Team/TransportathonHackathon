import { NgModule } from '@angular/core';
import { ExtraOptions, RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './components/admin/admin.component';
import { adminGuard } from './guards/admin.guard';
import { loginGuard } from './guards/login.guard';
import { UsersComponent } from './components/admin/users/users.component';


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
    path: 'admin',
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
  exports: [RouterModule]
})

export class AppRoutingModule { }
