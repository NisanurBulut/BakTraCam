import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BakimComponent } from './bakim.component';
import { BakimService } from './bakim.service';
import { HttpClientModule } from '@angular/common/http';
import { MaterialModule } from 'app/shared/material.module';
import { BakimFormComponent } from './forms/bakim-form/bakim-form.component';
import { BakimFormPopupComponent } from './popups/bakim-form-popup/bakim-form-popup.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { KullaniciSelectComponent } from 'app/components/kullanici-select/kullanici-select.component';
import { ComponentsModule } from 'app/components/components.module';

@NgModule({
    imports: [
        CommonModule,
        ComponentsModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        MaterialModule,
    ],
    declarations: [
        BakimComponent,
        BakimFormComponent,
        BakimFormPopupComponent
    ],
    providers: [
        BakimService,
        { provide: MatDialogRef, useValue: {} },
        { provide: MAT_DIALOG_DATA, useValue: [] }
    ]
})

export class BakimModule { }
