import { Component, OnInit, Input, ChangeDetectorRef, Output, EventEmitter, AfterViewInit, OnDestroy } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { BakimService } from 'app/bakim';
import { deepCopy } from 'app/common';
import { BakimModel } from 'app/models';
import { SnackbarService } from 'app/shared/snackbar.service';
import { Subject } from 'rxjs';
import { takeUntil, filter, tap, mergeMap } from 'rxjs/operators'

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
        private _bakimService: BakimService) {
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
