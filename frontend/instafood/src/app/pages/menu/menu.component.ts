import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastService } from '../../@core/helpers/toast.service';
import { MenuModel } from './menu.model';
import { MenuService } from './menu.service';

@Component({
  selector: 'ngx-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

  menuItem: MenuModel;
  picturePaths: string[];
  menuForm: FormGroup;
  constructor(private menuService: MenuService,
    private toastService: ToastService,
    private fb: FormBuilder) {
    this.menuItem = new MenuModel();
    this.picturePaths = new Array();
    this.picturePaths.push('fries.jfif');
    this.picturePaths.push('veggiePizza.jfif');
    this.picturePaths.push('gardenPizza.jfif');
    this.onReset();
  }

  ngOnInit(): void {
    this.menuForm = this.fb.group({
      nameControl: ['', Validators.required],
      priceControl: ['', Validators.required],
      taxControl: ['', Validators.required],
      picturePathControl: ['', Validators.required]
    });
  }

  changePicture(picture) {
    if (this.menuItem.picturePath !== picture) {
      this.menuItem.picturePath = picture;
    }
  }

  onSubmit() {
    console.log('Menu Item submit is called');
    this.menuService.newMenuItem(this.menuItem).subscribe(
      success => {
        this.toastService.showSuccess('Success', this.menuItem.name + ' created successfully')
        this.onReset();
      },
      error => {
        this.toastService.showError('Failed', 'Failed to create menu item - ' + this.menuItem.name)
        console.log(error);
      }
    );
  }

  onReset() {
    this.menuItem.name = '';
    this.menuItem.picturePath = '';
    this.menuItem.price = 0;
    this.menuItem.tax = 0;
  }
}
