import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

import { BakimFormComponent, BakimDetailFormComponent } from './forms';
import { BakimFormPopupComponent, BakimDetailPopupComponent } from './popups';
import { BakimService, BakimListComponent, BakimTamamlananListComponent} from '../bakim';

import { MaterialModule } from 'app/shared/material.module';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ComponentsModule } from 'app/components/components.module';
import { BaseCommonModule } from 'app/shared/baseCommon.module';
import { MAT_DATE_LOCALE } from '@angular/material/core';

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
        BakimTamamlananListComponent,
        BakimFormComponent,
        BakimFormPopupComponent,
        BakimDetailFormComponent,
        BakimDetailPopupComponent
    ],
    providers: [
        BakimService,
        { provide: MAT_DATE_LOCALE, useValue: 'tr-TR' },
        { provide: MatDialogRef, useValue: {} },
        { provide: MAT_DIALOG_DATA, useValue: [] }
    ]
})

export class BakimModule { }
