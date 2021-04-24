import { Component, OnInit, Input, ChangeDetectorRef, Output, EventEmitter, AfterViewInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { compareEnumKeys, deepCopy, markAsTouched } from 'app/common/generic-functions';
import { takeUntil, filter, tap, mergeMap } from 'rxjs/operators';
import { Unvan, EnumCategory, DuyuruModel } from 'app/models';
import { TranslateService } from '@ngx-translate/core';
import { DuyuruService } from '../duyuru.service';
import { SnackbarService } from 'app/shared/snackbar.service';

@Component({
  selector: 'app-duyuru-form',
  templateUrl: './duyuru-form.component.html',
  styleUrls: ['./duyuru-form.component.scss']
})
export class DuyuruFormComponent implements OnInit, AfterViewInit {

  data: DuyuruModel;
  defaultData: DuyuruModel;
  formInit = false;
  form: FormGroup;

  private _unsubscribeAll = new Subject();
  private _duyuruIdWaiter: Subject<number> = new Subject<number>();

  // enums
  EnumCategory = EnumCategory;
  Unvans = Unvan;
  compareEnumKeys = compareEnumKeys;

  @Output() result: EventEmitter<number> = new EventEmitter<number>();

  private _duyuruId = 0;
  @Input() set duyuruId(value: number) {
    this._duyuruId = value;
    if (this._duyuruId > 0) {
      this._duyuruIdWaiter.next(value);
    }
  }
  get duyuruId(): number {
    return this._duyuruId;
  }

  constructor(private formBuilder: FormBuilder,
    private _translate: TranslateService,
    private _snackbarService: SnackbarService,
    private _cd: ChangeDetectorRef,
    private _dService: DuyuruService) {

    this.form = this.formBuilder.group({
      Aciklama: [[]],
      Id: [[]]
    });

    this._duyuruIdWaiter.pipe(
      takeUntil(this._unsubscribeAll),
      filter((id) => id > 0),
      mergeMap((id) => this._dService.getirDuyuru(id))
    ).subscribe((duyuru) => {
      if (duyuru) {
        this.data = duyuru;
        this.defaultData = deepCopy(this.data);
        this.createForm();
      }
    });
  }


  ngOnInit(): void {
    // eğer düzenleme varsa form veriyle dolmalı
    if (!this._duyuruId) {
      this.data = {} as DuyuruModel;
      this.defaultData = deepCopy(this.data);
      this.createForm();
    }
  }
  ngAfterViewInit() { }
  public validateForm(): boolean {
    markAsTouched(this.form);
    return this.form.valid;
  }
  public isClean(): boolean {
    return this.form.pristine;
  }
  public cancel(): void {
    if (!this.isClean()) {
      this.form.reset({
        Aciklama: this.defaultData.Aciklama,
        Id: this.data.Id
      });
      // veri out edilerek parentine verilir
      this.result.emit(this.form.getRawValue());
    }
  }
  createForm(): void {
    this.form = this.formBuilder.group({
      Aciklama: [this.data.Aciklama, [Validators.required, Validators.maxLength(250)]],
      Id: [this.data.Id, [Validators.min(1)]]
    });

    // duyuruları Yükle
    this.formInit = true;
    this._cd.detectChanges();
  }
  save(): void {
    if (this.validateForm()) {
      const duyuru: DuyuruModel = {
        Id: this._duyuruId,
        ...this.form.getRawValue()
      };

      this._dService.kaydetDuyuru(duyuru).pipe(
        takeUntil(this._unsubscribeAll),
        filter((res) => res.success),
        tap((res) => this._duyuruId = res.data.Id),
        tap((res) => this.result.emit(res.data.Id))
      ).subscribe();
    } else {
      this.result.emit(-1)
      const msg = this._translate.instant('Duyuru bilgileri doğrulanamadı');
      this._snackbarService.show(msg);
    }
  }
}
