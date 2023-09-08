import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { ToastrService } from 'ngx-toastr';
import { Product } from 'src/app/models/entities/product';
import { ErrorService } from 'src/app/services/error.service';
import { ProductService } from 'src/app/services/product.service';

@Component({
  selector: 'app-product-crud',
  templateUrl: './product-crud.component.html',
  styleUrls: ['./product-crud.component.css']
})
export class ProductCrudComponent implements OnInit {
  productAddForm:FormGroup;
  product:Product;

  constructor(
    private formBuilder: FormBuilder,
    private activeModal: NgbActiveModal,
    private toastrService: ToastrService,
    private errorService: ErrorService,
    private productService:ProductService
  ) { }

  ngOnInit(): void {
    this.createLanguageAddForm();
  }

  createLanguageAddForm() {
   this.productAddForm = this.formBuilder.group({
      name: ['', Validators.required],
      description: ['', Validators.required],
      quantityPerUnit: ['', Validators.required],
      price: ['', Validators.required],
    });
  }

  close() {
    this.activeModal.close('Add Modal Closed');
  }

  dismiss() {
    this.activeModal.dismiss('Add Modal Dismissed');
  }

  add() {
    if (this.productAddForm.valid) {
      let productModel: Product = Object.assign(
        {},
        this.productAddForm.value
      );

      this.productService.add(productModel).subscribe(
        (response) => {
          this.toastrService.success(
            response.message,""
          );
        },
        (responseError) => {
          this.errorService.writeErrorMessages(responseError);
        }
      );
    }
  }
}
