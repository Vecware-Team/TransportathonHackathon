import { faFacebook, faInstagram } from '@fortawesome/free-brands-svg-icons';
import { socialLinks } from './../../constants/social-links';
import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { allTranslates } from 'src/app/services/translation.service';
import { SocialLink } from 'src/app/models/entities/socialLink';
import { IconProp } from '@fortawesome/fontawesome-svg-core';
@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css'],
})
export class FooterComponent implements OnInit {
  faFacebook = faFacebook;
  faInstagram = faInstagram;
  
  constructor(private router: Router) {}

  ngOnInit(): void {}

  navigate(url: string, id: string) {
    this.router.navigate([url]).then(() => {
      this.scroll(id);
    });
  }

  scroll(id: string) {
    var element = document.getElementById(id);
    var headerOffset = 135;
    var elementPosition = element!.getBoundingClientRect().top;
    var offsetPosition = elementPosition + window.pageYOffset - headerOffset;

    window.scrollTo({
      top: offsetPosition,
      behavior: 'smooth',
    });
  }

  getSocialLink(key: string): string {
    return socialLinks.find((s) => s.key == key)!.link;
  }
}
