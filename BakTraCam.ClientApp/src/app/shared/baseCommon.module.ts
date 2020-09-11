import { NgModule } from '@angular/core';
import { MatRippleModule } from '@angular/material/core';
import { EnumKeysPipe, EnumTranslatePipe, NullStringPipe } from '../common';
import { CommonModule } from '@angular/common';

@NgModule({
    declarations: [
        EnumKeysPipe,
        EnumTranslatePipe,
        NullStringPipe
    ],
    imports: [
        CommonModule,
        MatRippleModule
    ],
    exports: [
        EnumKeysPipe,
        EnumTranslatePipe,
        NullStringPipe
    ],
    providers: [

        // {
        //     provide: DateAdapter, useClass: SarpDateAdapter
        // },
        // {
        //     provide: MAT_DATE_FORMATS, useValue: SARP_DATE_FORMATS
        // }
    ],
})
export class BaseCommonModule {

}
