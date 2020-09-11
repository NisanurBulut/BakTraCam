import { ChangeDetectorRef, Component, Input, OnDestroy, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { compareEnumKeys } from 'app/common';
import { Select } from 'app/models';
import { Subject } from 'rxjs';
import { takeUntil, tap } from 'rxjs/operators';
import { ComponentService } from '../component.service';

@Component({
    selector: 'app-kullanici-select',
    templateUrl: './kullanici-select.component.html'
})

export class KullaniciSelectComponent implements OnInit, OnDestroy {

    @Input() parentFormGroup: FormGroup;
    @Input() controlName: string;
    private _unsubscribeAll: Subject<any>;
    _kullanicilar: Select[] = [];

    compareKullanici = compareEnumKeys;
    constructor(private _cService: ComponentService, private _cd: ChangeDetectorRef) {
        this._cService.getirKullaniciListesi().pipe(
            takeUntil(this._unsubscribeAll),
            tap((kullaniciList: Select[]) => {
                this._kullanicilar = [...kullaniciList];
                this._cd.detectChanges();
            }),
        ).subscribe();
    }

    ngOnInit() {


    }
    ngOnDestroy() {
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }
}
