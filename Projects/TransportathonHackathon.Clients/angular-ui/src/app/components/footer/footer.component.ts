import { Component } from '@angular/core';
import { faFacebook, faInstagram } from '@fortawesome/free-brands-svg-icons';
import { socialLinks } from 'src/app/constants/social-links';
import { ScrollService } from 'src/app/services/scroll.service';

@Component({
  selector: 'app-footer',
  templateUrl: './footer.component.html',
  styleUrls: ['./footer.component.css'],
})
export class FooterComponent {
  faFacebook = faFacebook;
  faInstagram = faInstagram;

  constructor(private scrollService: ScrollService) {}

  getSocialLink(key: string): string {
    return socialLinks.find((s) => s.key == key)!.link;
  }

  scrollTop() {
    this.scrollService.scrollTop();
  }
}
