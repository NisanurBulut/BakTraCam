import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';

import { FooterComponent } from './footer/footer.component';
import { NavbarComponent } from './navbar/navbar.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { KullaniciSelectComponent } from './kullanici-select/kullanici-select.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ComponentService } from './component.service';
import { MatInputModule } from '@angular/material/input';
@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    FlexLayoutModule
  ],
  declarations: [
    FooterComponent,
    NavbarComponent,
    SidebarComponent,
    KullaniciSelectComponent
  ],
  exports: [
    FooterComponent,
    NavbarComponent,
    SidebarComponent,
    KullaniciSelectComponent
  ],
  providers: [
    ComponentService
  ]
})
export class ComponentsModule { }
