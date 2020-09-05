import { CommonModule } from '@angular/common';
import { HttpModule } from '@angular/http';
import { NgModule } from '@angular/core';
import { BakimComponent } from './bakim.component';
import { BakimService } from './bakim.service';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
    imports: [
        CommonModule,
        HttpClientModule,

    ],
    declarations: [
        BakimComponent
    ],
    providers: [
        BakimService
    ]
})

export class BakimModule { }
