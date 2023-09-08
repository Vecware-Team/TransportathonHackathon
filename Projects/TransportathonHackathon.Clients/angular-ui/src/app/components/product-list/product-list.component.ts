import { Component, OnInit } from '@angular/core';
import { faEdit, faRedoAlt, faTrash } from '@fortawesome/free-solid-svg-icons';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Product } from 'src/app/models/entities/product';
import { ProductService } from 'src/app/services/product.service';
import { ProductCrudComponent } from '../product-crud/product-crud.component';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.css']
})
export class ProductListComponent implements OnInit {

  faEdit = faEdit;
  faTrash = faTrash;
  faRedoAlt = faRedoAlt;

  products: Product[] = [];
  dataLoaded = false;

  constructor(
    private modalService: NgbModal,
    private productService: ProductService
  ) {}

  ngOnInit(): void {
    this.getAll();
  }

  getAll() {
    this.dataLoaded = false;
    this.productService.getAll().subscribe((response) => {
      this.products = response.data;
      this.dataLoaded = true;
    });
  }

  openAddForm() {
    var modalReferance = this.modalService.open(ProductCrudComponent, {
      size: 'm',
    });
  }

  // openDeleteForm(product: Product) {
  //   var modalReferance = this.modalService.open(ProductDeleteComponent, {
  //     size: 'm',
  //   });
  //   modalReferance.componentInstance.product = product;
  // }

  // openUpdateForm(product: product) {
  //   var modalReferance = this.modalService.open(productUpdateComponent, {
  //     size: 'm',
  //   });
  //   modalReferance.componentInstance.product = product;
  // }

}
