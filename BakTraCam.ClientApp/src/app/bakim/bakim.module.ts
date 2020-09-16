import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { BakimService } from './bakim.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { BakimFormPopupComponent, BakimListComponent, BakimFormComponent,
    BakimDetailFormComponent, BakimDetailPopupComponent } from '../bakim';
import { MaterialModule } from 'app/shared/material.module';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ComponentsModule } from 'app/components/components.module';
import { BaseCommonModule } from 'app/shared/baseCommon.module';

@NgModule({
    imports: [
        CommonModule,
        BaseCommonModule,
        ComponentsModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        MaterialModule,
    ],
    declarations: [
        BakimListComponent,
        BakimFormComponent,
        BakimFormPopupComponent,
        BakimDetailFormComponent,
        BakimDetailPopupComponent
    ],
    providers: [
        BakimService,
        { provide: MatDialogRef, useValue: {} },
        { provide: MAT_DIALOG_DATA, useValue: [] }
    ]
})

export class BakimModule { }
