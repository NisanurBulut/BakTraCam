import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { NgModule } from '@angular/core';
import { BakimComponent } from './bakim.component';
import { BakimService } from './bakim.service';
import { HttpClientModule } from '@angular/common/http';
import { MaterialModule } from 'app/shared/material.module';
import { BakimFormComponent } from './forms/bakim-form/bakim-form.component';
import { BakimFormPopupComponent } from './popups/bakim-form-popup/bakim-form-popup.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

@NgModule({
    imports: [
        CommonModule,
        HttpClientModule,
        FormsModule,
        ReactiveFormsModule,
        MaterialModule
    ],
    declarations: [
        BakimComponent,
        BakimFormComponent,
        BakimFormPopupComponent
    ],
    providers: [
        BakimService
    ]
})

export class BakimModule { }
