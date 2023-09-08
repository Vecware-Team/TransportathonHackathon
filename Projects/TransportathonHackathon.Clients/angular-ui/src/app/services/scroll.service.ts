import { Injectable } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class ScrollService {
  constructor(private router: Router, private activatedRoute: ActivatedRoute) {}

  navigate(url: string, id: string, headerOffset: number = 135) {
    this.router.navigate([url]).then(() => {
      this.scroll(id, headerOffset);
    });
  }

  navigateToTop(url: string) {
    this.router.navigate([url]).then(() => {
      this.scrollTop();
    });
  }

  scrollTop() {
    window.scrollTo(0, 0);
  }

  scroll(id: string, headerOffset: number) {
    var element = document.getElementById(id);
    var elementPosition = element!.getBoundingClientRect().top;
    var offsetPosition = elementPosition + window.pageYOffset - headerOffset;

    window.scrollTo({
      top: offsetPosition,
      behavior: 'smooth',
    });
  }
}
