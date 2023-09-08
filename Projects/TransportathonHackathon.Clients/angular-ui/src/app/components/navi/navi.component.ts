import { Component, OnInit } from '@angular/core';
import { NavigationStart, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ProfilePicture } from 'src/app/models/entities/profilePicture';
import { User } from 'src/app/models/entities/user';
import { AuthService } from 'src/app/services/auth.service';
import { ProfilePictureService } from 'src/app/services/profile-picture.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-navi',
  templateUrl: './navi.component.html',
  styleUrls: ['./navi.component.css'],
})
export class NaviComponent implements OnInit {
  user: User;
  profilePicture: ProfilePicture;
  baseUrl = environment.baseUrl;
  constructor(
    private authService: AuthService,
    private router: Router,
    private toastrService: ToastrService,
    private profilePictureService: ProfilePictureService
  ) {}

  ngOnInit(): void {
    this.getUserFromToken();
    this.getPP();
    this.runActiveStateManagementScript();
    this.runCollapseScript();
  }
  getPP() {
    this.profilePictureService
      .getByUserId(this.user.id)
      .subscribe((response) => {
        this.profilePicture = response.data;
      });
  }

  getUserFromToken() {
    this.user = this.authService.getUser();
  }

  runCollapseScript() {
    $('.navbar-collapse .nav-link-collapse').on('click', function () {
      (<any>$('.navbar-collapse')).collapse('hide');
    });
  }

  callCollapseEvent() {
    (<any>$('.navbar-collapse')).collapse('hide');
  }

  runActiveStateManagementScript() {
    $('.nav-link').addClass('abb');

    this.router.events.subscribe((event) => {
      if (event instanceof NavigationStart) {
        $('.nav-link.nav-link-custom.active').removeClass('active');
        $('.nav-link.nav-link-custom').attr('routerLink', function (i, val) {
          if (val === event.url) {
            $(this).addClass('active');
          }

          if (event.url === '/about-us/construction-promotion-id-card') {
            $('.about-us').addClass('active');
          }
        });
      }
    });
  }

  signOut() {
    this.authService.signOut();
    sessionStorage.removeItem('adminCurrentPage');
    this.toastrService.info('Going to homepage...', 'Logged Out');
    this.router.navigate(['']);
  }

  isSignedIn() {
    return this.authService.isSignedIn();
  }

  isAuthenticated() {
    return this.authService.isAuthenticated();
  }
}
