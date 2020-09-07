import { Component, OnInit, Inject, ViewChild, OnDestroy, AfterViewInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { BakimFormComponent } from 'app/bakim/forms/bakim-form/bakim-form.component';
import { Subject } from 'rxjs';


@Component({
  selector: 'app-bakim-form-popup',
  templateUrl: './bakim-form-popup.component.html',
  styleUrls: ['./bakim-form-popup.component.scss']
})
export class BakimFormPopupComponent implements OnInit, OnDestroy {

  private _unsubscribeAll = new Subject();
  bakimId: number;

  @ViewChild('bakimForm', { static: true }) bakimForm: BakimFormComponent;

  constructor(
    public dialogRef: MatDialogRef<BakimFormPopupComponent>,
    @Inject(MAT_DIALOG_DATA) private _data: any
  ) {
    this.bakimId = _data.id as number;
  }

  ngOnInit(): void {
  }
  closeDialog(): void {
    this.dialogRef.close();
  }

  saved(bakimId: number): void {
    this.dialogRef.close(bakimId);
  }

  save(): void {
    console.log(this.bakimForm);
    this.bakimForm.save();
    this.closeDialog();
  }
  ngOnDestroy(): void {
    this._unsubscribeAll.next();
    this._unsubscribeAll.complete();
  }
}
