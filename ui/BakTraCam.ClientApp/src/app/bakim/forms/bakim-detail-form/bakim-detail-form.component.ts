import { Component, OnInit, Input } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { BakimService } from 'app/bakim';
import { compareEnumKeys, deepCopy } from 'app/common';
import { BakimDurum, BakimModel, BakimPeriod, BakimTip, EnumCategory } from 'app/models';
import { Subject } from 'rxjs';
import { takeUntil, filter, mergeMap } from 'rxjs/operators'

@Component({
  selector: 'app-bakim-detail-form',
  templateUrl: './bakim-detail-form.component.html',
  styleUrls: ['./bakim-detail-form.component.scss']
})
export class BakimDetailFormComponent implements OnInit {

  private _unsubscribeAll = new Subject();
  private _bakimIdWaiter: Subject<number> = new Subject<number>();
  private _bakimId = 0;

  data: BakimModel;
  defaultData: BakimModel;
  formInit = false;
  form: FormGroup;

  EnumCategory = EnumCategory;
  bakimTip = BakimTip;
  bakimDurum = BakimDurum;
  bakimPeriod = BakimPeriod;
  compareEnumKeys = compareEnumKeys;
  @Input() set bakimId(value: number) {
    this._bakimId = value;
    if (this._bakimId > 0) {
      this._bakimIdWaiter.next(value);
    }
  }
  get bakimId(): number {
    return this._bakimId;
  }

  constructor(
    private _bakimService: BakimService, private translateservice:TranslateService) {
    // bakım bilgisini getirmeli ve göstermeli
    this._bakimIdWaiter.pipe(
      takeUntil(this._unsubscribeAll),
      filter((id) => id > 0),
      mergeMap((id) => this._bakimService.getirBakim(id))
    ).subscribe((bakim) => {
      if (bakim) {
        this.data = bakim;
        console.log(this.data);
        this.defaultData = deepCopy(this.data);
      }
    });
  }
  ngOnInit(): void {
    // eğer düzenleme varsa form veriyle dolmalı
    if (!this.bakimId) {
      this.data = {} as BakimModel;
      this.defaultData = deepCopy(this.data);
    }
  }
}
