import { Component, OnInit, Input, ChangeDetectorRef, Output, EventEmitter, AfterViewInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Subject } from 'rxjs';
import { MatDialog } from '@angular/material/dialog';
import { deepCopy, markAsTouched, compareEnumKeys } from '../../../common';
import { takeUntil, filter, tap, mergeMap } from 'rxjs/operators';
import { KullaniciModel, Unvan, EnumCategory } from '../../../models';
import { KullaniciService } from 'app/kullanici/kullanici.service';


@Component({
  selector: 'app-kullanici-form',
  templateUrl: './kullanici-form.component.html',
  styleUrls: ['./kullanici-form.component.scss']
})
export class KullaniciFormComponent implements OnInit, AfterViewInit {

  data: KullaniciModel;
  defaultData: KullaniciModel;
  formInit = false;
  form: FormGroup;

  private _unsubscribeAll = new Subject();
  private _kullaniciIdWaiter: Subject<number> = new Subject<number>();

  // enums
  EnumCategory = EnumCategory;
  Unvan = Unvan;
  compareEnumKeys = compareEnumKeys;

  @Output() result: EventEmitter<number> = new EventEmitter<number>();

  private _bakimId = 0;
  @Input() set kullaniciId(value: number) {
    this._bakimId = value;
    if (this._bakimId > 0) {
      this._kullaniciIdWaiter.next(value);
    }
  }
  get kullaniciId(): number {
    return this._bakimId;
  }

  constructor(private formBuilder: FormBuilder,
    private _cd: ChangeDetectorRef,
    private _kService: KullaniciService) {


    this.form = this.formBuilder.group({
      Ad: [[]],
      UnvanId: [[]]
    });


    this._kullaniciIdWaiter.pipe(
      takeUntil(this._unsubscribeAll),
      filter((id) => id > 0),
      mergeMap((id) => this._kService.getirKullanici(id))
    ).subscribe((kullanici) => {
      if (kullanici) {
        this.data = kullanici;
        this.defaultData = deepCopy(this.data);
        this.createForm();
      }
    });
  }


  ngOnInit(): void {
    // eğer düzenleme varsa form veriyle dolmalı
    if (!this.kullaniciId) {
      this.data = {} as KullaniciModel;
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
        UnvanId: this.data.UnvanId
      });
      // veri out edilerek parentine verilir
      this.result.emit(this.form.getRawValue());
    }
  }
  createForm(): void {
    this.form = this.formBuilder.group({
      Ad: [this.data.Ad, [Validators.required, Validators.maxLength(50)]],
      UnvanId: [this.data.UnvanId, [Validators.min(1)]]
    });

    // Kullanıcıları Yükle
    this.formInit = true;
    this._cd.detectChanges();
  }
  save(): void {
    if (this.validateForm()) {
      const kullanici: KullaniciModel = {
        Id: this.kullaniciId,
        ...this.form.getRawValue()
      };

      this._kService.kaydetKullanici(kullanici).pipe(
        takeUntil(this._unsubscribeAll),
        filter((res) => res.success),
        tap((res) => { console.log(res) }),
        tap((res) => this.kullaniciId = res.data.Id),
        tap((res) => this.result.emit(res.data.Id))
      ).subscribe();
    }
  }
}
