import { Component, OnInit } from '@angular/core';
import { NavigationStart, Router } from '@angular/router';

@Component({
  selector: 'app-navi',
  templateUrl: './navi.component.html',
  styleUrls: ['./navi.component.css'],
})
export class NaviComponent implements OnInit {
  constructor(private router: Router) {}

  ngOnInit(): void {
    this.runActiveStateManagementScript();
    this.runCollapseScript();
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
}
