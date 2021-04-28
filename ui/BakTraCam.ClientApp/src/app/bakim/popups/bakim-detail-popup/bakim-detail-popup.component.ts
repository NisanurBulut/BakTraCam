import { Component, OnInit, Inject, ViewChild, OnDestroy } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { BakimService } from 'app/bakim';
import { BakimDetailFormComponent } from 'app/bakim/forms';
import { Subject } from 'rxjs';


@Component({
    selector: 'app-bakim-detail-popup',
    templateUrl: './bakim-detail-popup.component.html',
    styleUrls: ['./bakim-detail-popup.component.scss']
})
export class BakimDetailPopupComponent implements OnInit, OnDestroy {

    private _unsubscribeAll = new Subject();
    bakimId: number;
    @ViewChild('bakimDetailForm', { static: true }) bakimForm: BakimDetailFormComponent;
    constructor(
        public dialogRef: MatDialogRef<BakimDetailPopupComponent>,
        @Inject(MAT_DIALOG_DATA) private _data: any) {
        this.bakimId = _data.id as number;
        // bakım detay bilgisini getir
    }
    ngOnInit(): void {

    }

    ngOnDestroy(): void {
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }
    closeDialog(): void {
        this.dialogRef.close(false)
    }
}
