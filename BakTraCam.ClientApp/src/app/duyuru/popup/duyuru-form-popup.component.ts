import { Component, OnInit, Inject, ViewChild, OnDestroy } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { KullaniciFormComponent } from 'app/kullanici/forms/kullanici-form/kullanici-form.component';
import { Subject } from 'rxjs';
import { DuyuruFormComponent } from '../form/duyuru-form.component';


@Component({
  selector: 'app-duyuru-form-popup',
  templateUrl: './duyuru-form-popup.component.html',
  styleUrls: ['./duyuru-form-popup.component.scss']
})
export class DuyuruFormPopupComponent implements OnInit, OnDestroy {

  private _unsubscribeAll = new Subject();
  duyuruId: number;

  @ViewChild('duyuruForm', { static: true }) duyuruForm: DuyuruFormComponent;

  constructor(
    public dialogRef: MatDialogRef<KullaniciFormComponent>,
    @Inject(MAT_DIALOG_DATA) private _data: any) {
    this.duyuruId = _data.id as number;
  }

  ngOnInit(): void {
  }
  closeDialog(): void {
    this.dialogRef.close();
  }

  saved(duyuruId: any): void {
    console.log(duyuruId);
    this.dialogRef.close(duyuruId);
  }

  save(): void {
    this.duyuruForm.save();
    this.closeDialog();
  }
  ngOnDestroy(): void {
    this._unsubscribeAll.next();
    this._unsubscribeAll.complete();
  }
}
