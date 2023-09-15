import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class RouterService {
  constructor(private router: Router) { }

  homeRoute() {
    this.router.navigate(['/']);
  }

  adminRoute() {
    this.router.navigate(['/admin']);
  }

  companyPanelRoute() {
    this.router.navigate(['/company/panel']);
  }

  loginRoute() {
    this.router.navigate(['/login']);
  }

  registerRoute() {
    this.router.navigate(['/register']);
  }
}
