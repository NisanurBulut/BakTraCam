import { Component, OnInit, Inject, ViewChild } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { BakimFormComponent } from 'app/bakim/forms/bakim-form/bakim-form.component';

@Component({
  selector: 'app-bakim-form-popup',
  templateUrl: './bakim-form-popup.component.html',
  styleUrls: ['./bakim-form-popup.component.scss']
})
export class BakimFormPopupComponent implements OnInit {

  bakimId: number;
  @ViewChild('bakimForm', { static: true }) bakimForm: BakimFormComponent;

  constructor(
    public dialogRef: MatDialogRef<BakimFormPopupComponent>,
    @Inject(MAT_DIALOG_DATA) private _data: any
  ) { }

  ngOnInit(): void {
  }

  closeDialog(): void {
    this.dialogRef.close();
  }

saved(bakimId: number): void {
  this.dialogRef.close(bakimId);
}

save(): void {
  this.bakimForm.save();
  this.closeDialog();
}
}
