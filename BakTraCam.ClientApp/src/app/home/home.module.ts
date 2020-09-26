import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';


import { BakimService } from '../bakim';

import { MaterialModule } from 'app/shared/material.module';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ComponentsModule } from 'app/components/components.module';
import { BaseCommonModule } from 'app/shared/baseCommon.module';
import { MAT_DATE_LOCALE } from '@angular/material/core';
import { HomeComponent } from './home.component';

@NgModule({
    imports: [
        CommonModule,
        BaseCommonModule,
        ComponentsModule,
        HttpClientModule,
        FormsModule,
        MaterialModule
    ],
    declarations: [
        HomeComponent
    ],
    providers: [
        BakimService,
        { provide: MAT_DATE_LOCALE, useValue: 'tr-TR' },
        { provide: MatDialogRef, useValue: {} },
        { provide: MAT_DIALOG_DATA, useValue: [] }
    ]
})

export class HomeModule { }
