import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { faComments } from '@fortawesome/free-solid-svg-icons';
import { ScrollService } from '../../services/scroll.service';
import { allTranslates } from '../../services/translation.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {

  constructor(
    private scrollService: ScrollService,
    private router: Router,
  ) {}

  ngOnInit(): void {
  }

  scrollTop(url: string, id: string) {
    this.scrollService.navigate(url, id, 0);
  }

  navigate(url: string, id: string) {
    this.router.navigateByUrl('');
  }
}
