import { Component, OnInit, Input, ChangeDetectorRef, Output, EventEmitter, AfterViewInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { BakimDurum, BakimModel, BakimPeriod, BakimTip, EnumCategory, Select } from 'app/models';
import { BakimService } from 'app/bakim/bakim.service';
import { compareEnumKeys, deepCopy, markAsTouched } from 'app/common/generic-functions';
import { takeUntil, filter, tap, mergeMap } from 'rxjs/operators';
import { SnackbarService } from 'app/shared/snackbar.service';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-bakim-form',
  templateUrl: './bakim-form.component.html',
  styleUrls: ['./bakim-form.component.css']
})
export class BakimFormComponent implements OnInit, AfterViewInit {

  data: BakimModel;
  defaultData: BakimModel;
  formInit = false;
  form: FormGroup;

  // enums
  EnumCategory = EnumCategory;
  BakimDurums = BakimDurum;
  BakimTips = BakimTip;
  BakimPeroids = BakimPeriod;
  compareEnumKeys = compareEnumKeys;

  private _unsubscribeAll = new Subject();
  private _bakimIdWaiter: Subject<number> = new Subject<number>();

  @Input() kullanici: string;
  @Output() result: EventEmitter<number> = new EventEmitter<number>();

  private _bakimId = 0;
  @Input() set bakimId(value: number) {
    this._bakimId = value;
    if (this._bakimId > 0) {
      this._bakimIdWaiter.next(value);
    }
  }
  get bakimId(): number {
    return this._bakimId;
  }

  constructor(private formBuilder: FormBuilder,
    private _cd: ChangeDetectorRef,
    private _snackbarService: SnackbarService,
    private _translate: TranslateService,
    private _bakimService: BakimService) {

    this.form = this.formBuilder.group({
      Ad: [[]],
      Aciklama: [[]],
      BaslangicTarihi: [[]],
      BitisTarihi: [[]],
      Durum: [[]],
      Tip: [[]],
      Period: [[]],
      Sorumlu1: [[]],
      Sorumlu2: [[]],
      Gerceklestiren1: [[]],
      Gerceklestiren2: [[]],
      Gerceklestiren3: [[]],
      Gerceklestiren4: [[]]
    });


    this._bakimIdWaiter.pipe(
      takeUntil(this._unsubscribeAll),
      filter((id) => id > 0),
      mergeMap((id) => this._bakimService.getirBakim(id))
    ).subscribe((bakim) => {
      if (bakim) {
        this.data = bakim;
        this.defaultData = deepCopy(this.data);
        this.createForm();
      }
    });
  }


  ngOnInit(): void {
    // eğer düzenleme varsa form veriyle dolmalı
    if (!this.bakimId) {
      this.data = {} as BakimModel;
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
        Ad: this.defaultData.Ad,
        Aciklama: this.data.Aciklama,
        BaslangicTarihi: this.data.BaslangicTarihi,
        BitisTarihi: this.data.BitisTarihi,
        kullanici1: this.data.Sorumlu1,
        kullanici2: this.data.Sorumlu2,
        Gerceklestiren1: this.data.Gerceklestiren1,
        Gerceklestiren2: this.data.Gerceklestiren2,
        Gerceklestiren3: this.data.Gerceklestiren3,
        Gerceklestiren4: this.data.Gerceklestiren4,
        Tip: this.data.Tip,
        Period: this.data.Period,
      });
      // veri out edilerek parentine verilir
      this.result.emit(this.form.getRawValue());
    }
  }
  createForm(): void {
    this.form = this.formBuilder.group({
      Ad: [this.defaultData.Ad, [Validators.required, Validators.maxLength(50)]],
      Aciklama: [this.defaultData.Aciklama, [Validators.maxLength(100)]],
      BaslangicTarihi: [this.defaultData.BaslangicTarihi, [Validators.required]],
      BitisTarihi: [this.defaultData.BitisTarihi],
      Tip: [this.defaultData.Tip, [Validators.required, Validators.min(1)]],
      Period: [this.defaultData.Period],
      Sorumlu1: [this.defaultData.Sorumlu1],
      Sorumlu2: [this.defaultData.Sorumlu2],
      Gerceklestiren1: [this.defaultData.Gerceklestiren1],
      Gerceklestiren2: [this.defaultData.Gerceklestiren2],
      Gerceklestiren3: [this.defaultData.Gerceklestiren3],
      Gerceklestiren4: [this.defaultData.Gerceklestiren4]
    });

    // Kullanıcıları Yükle
    this.formInit = true;
    this._cd.detectChanges();
  }
  save(): void {

    if (this.validateForm()) {
      const bakim = {
        Id: this.bakimId,
        ...this.form.getRawValue()
      } as BakimModel;

      this._bakimService.kaydetBakim(bakim).pipe(
        takeUntil(this._unsubscribeAll),
        filter((res) => res.success),
        tap((res) => { console.log(res) }),
        tap(() => {
          const msg = this._translate.instant('Bakım kaydedildi');
          this._snackbarService.show(msg);
        }),
        tap((res) => this.bakimId = res.data.Id),
        tap((res) => this.result.emit(res.data.Id))
      ).subscribe();
    } else {
      this.result.emit(0)
      const msg = this._translate.instant('Bakım bilgileri doğrulanamadı');
      this._snackbarService.show(msg);
    }
  }
  SelectSorumluBir(sorumlu: Select): void {
    if (sorumlu) {
      this.defaultData.Sorumlu1 = sorumlu.Key;
    }
  }
  SelectSorumluIki(sorumlu: Select): void {
    if (sorumlu) {
      this.defaultData.Sorumlu2 = sorumlu.Key;
    }
  }
  GerceklestirenBir(sorumlu: Select): void {
    if (sorumlu) {
      this.defaultData.Gerceklestiren1 = sorumlu.Key;
    }
  }
  GerceklestirenIki(sorumlu: Select): void {
    if (sorumlu) {
      this.defaultData.Gerceklestiren2 = sorumlu.Key;
    }
  }
  GerceklestirenUc(sorumlu: Select): void {
    if (sorumlu) {
      this.defaultData.Gerceklestiren3 = sorumlu.Key;
    }
  }
  GerceklestirenDort(sorumlu: Select): void {
    if (sorumlu) {
      this.defaultData.Gerceklestiren4 = sorumlu.Key;
    }
  }
  trackByPeriodID(index: number, item: any): string {
    return item.ID;
  }
}
