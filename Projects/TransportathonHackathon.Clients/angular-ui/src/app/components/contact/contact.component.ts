import { Component } from '@angular/core';
import { faGithub, faLinkedin } from '@fortawesome/free-brands-svg-icons';
import { faEnvelope } from '@fortawesome/free-solid-svg-icons';
import { socialLinks } from 'src/app/constants/social-links';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.css'],
})
export class ContactComponent {
  faEnvolpe = faEnvelope;
  faLinkedin = faLinkedin;
  faGithub = faGithub;

  getSocialLink(key: string): string {
    return socialLinks.find((s) => s.key == key)!.link;
  }
}
