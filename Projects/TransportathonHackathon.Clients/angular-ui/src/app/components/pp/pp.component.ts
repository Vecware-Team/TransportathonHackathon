import { Component, OnInit } from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ProfilePicture } from 'src/app/models/entities/profilePicture';
import { User } from 'src/app/models/entities/user';
import { ProfilePictureService } from 'src/app/services/profile-picture.service';
import { TokenService } from 'src/app/services/token.service';
import { environment } from 'src/environments/environment';
import { PpDeleteComponent } from './pp-delete/pp-delete.component';
import { PpAddComponent } from './pp-add/pp-add.component';

@Component({
  selector: 'app-pp',
  templateUrl: './pp.component.html',
  styleUrls: ['./pp.component.css'],
})
export class PpComponent implements OnInit {
  picture: ProfilePicture;
  user: User;
  baseUrl = environment.baseUrl;
  constructor(
    private profilePictureService: ProfilePictureService,
    private tokenService: TokenService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.getUser();
    this.getPP();
  }

  getUser() {
    this.user = this.tokenService.getUserWithJWT();
  }
  getPP() {
    this.profilePictureService
      .getByUserId(this.user.id)
      .subscribe((response) => (this.picture = response.data));
  }

  openDeleteForm(pp: ProfilePicture) {
    var modalReferance = this.modalService.open(PpDeleteComponent, {
      size: 'm',
    });
    modalReferance.componentInstance.pp = pp;
  }

  openAddForm() {
    this.modalService.open(PpAddComponent, {
      size: 'm',
    });
  }
}
