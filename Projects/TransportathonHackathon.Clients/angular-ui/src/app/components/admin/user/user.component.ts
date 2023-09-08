import { UserClaimComponent } from './../user-claim/user-claim.component';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Component, OnInit } from '@angular/core';
import {
  faCircle,
  faClipboardCheck,
  faClipboardList,
  faCog,
  faDotCircle,
  faRedoAlt,
} from '@fortawesome/free-solid-svg-icons';
import { allTranslates } from 'src/app/services/translation.service';
import { User } from 'src/app/models/entities/user';
import { UserService } from 'src/app/services/user.service';
declare var bootstrap: any;

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css'],
})
export class UserComponent implements OnInit {
  users: User[] = [];
  faCog = faCog;
  faClipboardCheck = faClipboardCheck;
  faRedoAlt = faRedoAlt;
  faDotCircle = faCircle;
  dataLoaded = false;

  private tooltipList = new Array<any>();

  constructor(
    private userService: UserService,
    private modalService: NgbModal
  ) {}

  ngOnInit(): void {
    this.getAllUsers();
  }

  openEditUserModal(user: User) {
    let modalReference = this.modalService.open(UserClaimComponent, {
      size: 'xl',
    });
    modalReference.componentInstance.user = user;
  }

  openEditClaimsModal(user: User) {
    let modalReference = this.modalService.open(UserClaimComponent, {
      size: 'xl',
    });
    modalReference.componentInstance.user = user;
  }

  getAllUsers() {
    this.dataLoaded = false;
    this.userService.getAll().subscribe((response) => {
      this.users = response.data;
      this.dataLoaded = true;
    });
  }
}
