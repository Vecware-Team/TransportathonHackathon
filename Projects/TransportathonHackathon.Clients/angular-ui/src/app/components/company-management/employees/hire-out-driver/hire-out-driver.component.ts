import { Component } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { TranslateService } from '@ngx-translate/core';
import { ToastrService } from 'ngx-toastr';
import { DeleteDriverRequest } from 'src/app/models/request-models/drivers/deleteDriverRequest';
import { GetByCompanyIdEmployeeResponse } from 'src/app/models/response-models/employees/getByCompanyIdEmployeeResponse';
import { DriverService } from 'src/app/services/driver.service';

@Component({
  selector: 'app-hire-out-driver',
  templateUrl: './hire-out-driver.component.html',
  styleUrls: ['./hire-out-driver.component.css']
})
export class HireOutDriverComponent {
  driver: GetByCompanyIdEmployeeResponse;

  constructor(
    private driverService: DriverService,
    private formBuilder: FormBuilder,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private translate: TranslateService
  ) {}

  ngOnInit(): void {}

  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }

  deleteDriver() {
    if (!this.driver) {
      this.toastrService.error('Driver is null', 'Form Error');
      return;
    }

    let driverModel: DeleteDriverRequest = {
      employeeId: this.driver.appUserId,
    };

    this.driverService.delete(driverModel).subscribe((response) => {
      this.toastrService.success(
        response.firstName + ' ' + response.lastName + ' deleted',
        this.translate.instant('successful')
      );
      this.close();
    });
  }
}
