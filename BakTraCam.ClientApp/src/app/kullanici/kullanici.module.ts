import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { BaseCommonModule } from 'app/shared/baseCommon.module';
import { MaterialModule } from 'app/shared/material.module';
import { KullaniciListComponent } from './list/kullanici-list.component';
import { KullaniciFormComponent } from './forms/kullanici-form/kullanici-form.component';
import { KullaniciFormPopupComponent } from './popups/kullanici-form-popup/kullanici-form-popup.component';
import { KullaniciService } from './kullanici.service';

@NgModule({
    imports: [
        CommonModule,
        BaseCommonModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        MaterialModule
    ],
    declarations: [
        KullaniciListComponent,
        KullaniciFormComponent,
        KullaniciFormPopupComponent
    ],
    providers: [
        KullaniciService,
        { provide: MatDialogRef, useValue: {} },
        { provide: MAT_DIALOG_DATA, useValue: [] }
    ]
})

export class KullaniciModule { }
