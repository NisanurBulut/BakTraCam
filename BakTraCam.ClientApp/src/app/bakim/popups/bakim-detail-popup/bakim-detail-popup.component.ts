import { Component, OnInit, Inject, ViewChild, OnDestroy } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { BakimService } from 'app/bakim';
import { Subject } from 'rxjs';


@Component({
    selector: 'app-bakim-detail-popup',
    templateUrl: './bakim-detail-popup.component.html',
    styleUrls: ['./bakim-detail-popup.component.scss']
})
export class BakimDetailPopupComponent implements OnInit, OnDestroy {

    private _unsubcribeAll = new Subject();
    bakimId: number;
    constructor(
        public dialogRef: MatDialogRef<BakimDetailPopupComponent>,
        @Inject(MAT_DIALOG_DATA) private _data: any,
        private _bService: BakimService) {
        this.bakimId = _data.id as number;
        // bakım detay bilgisini getir
    }
    ngOnInit(): void {

    }

    ngOnDestroy(): void { }
    save(): void { }
    closeDialog(): void {
        this.dialogRef.close();
    }
}
