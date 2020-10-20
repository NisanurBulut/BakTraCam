import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { MaterialModule } from 'app/shared/material.module';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ComponentsModule } from 'app/components/components.module';
import { BaseCommonModule } from 'app/shared/baseCommon.module';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { KullaniciListComponent } from './list/kullanici-list.component';
import { KullaniciFormComponent } from './forms/kullanici-form/kullanici-form.component';
import { KullaniciFormPopupComponent } from './popups/kullanici-form-popup/kullanici-form-popup.component';
import { KullaniciService } from './kullanici.service';


@NgModule({
    imports: [
        CommonModule,
        BaseCommonModule,
        ComponentsModule,
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
        { provide: MAT_DATE_LOCALE, useValue: 'tr-TR' },
        { provide: MatDialogRef, useValue: {} },
        { provide: MAT_DIALOG_DATA, useValue: [] }
    ]
})

export class KullaniciModule { }
