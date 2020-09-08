import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { KullaniciService } from './kullanici.service';
import { KullaniciComponent } from './kullanici.component';
import { KullaniciFormComponent } from './forms/kullanici-form/kullanici-form.component';
import { KullaniciFormPopupComponent } from './popups/kullanici-form-popup/kullanici-form-popup.component';
import { MatInputModule } from '@angular/material/input';
import { MatSelectModule } from '@angular/material/select';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatSortModule } from '@angular/material/sort';
import { BaseCommonModule } from 'app/shared/baseCommon.module';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MaterialModule } from 'app/shared/material.module';

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
        KullaniciComponent,
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
