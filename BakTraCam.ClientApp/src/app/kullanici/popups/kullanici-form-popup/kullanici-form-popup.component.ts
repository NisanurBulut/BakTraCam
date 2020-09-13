import { Component, OnInit, Inject, ViewChild, OnDestroy } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { KullaniciFormComponent } from 'app/kullanici/forms/kullanici-form/kullanici-form.component';
import { Subject } from 'rxjs';


@Component({
  selector: 'app-kullanici-form-popup',
  templateUrl: './kullanici-form-popup.component.html',
  styleUrls: ['./kullanici-form-popup.component.scss']
})
export class KullaniciFormPopupComponent implements OnInit, OnDestroy {

  private _unsubscribeAll = new Subject();
  kullaniciId: number;

  @ViewChild('kullaniciForm', { static: true }) kullaniciForm: KullaniciFormComponent;

  constructor(
    public dialogRef: MatDialogRef<KullaniciFormComponent>,
    @Inject(MAT_DIALOG_DATA) private _data: any
  ) {
    this.kullaniciId = _data.id as number;
  }

  ngOnInit(): void {
  }
  closeDialog(): void {
    this.dialogRef.close();
  }

  saved(kullaniciId: number): void {
    this.dialogRef.close(kullaniciId);
  }

  save(): void {
    this.kullaniciForm.save();
    this.closeDialog();
  }
  ngOnDestroy(): void {
    this._unsubscribeAll.next();
    this._unsubscribeAll.complete();
  }
}
