import { ChangeDetectorRef, Component, Input, OnDestroy, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { compareEnumKeys } from 'app/common';
import { Select } from 'app/models';
import { Observable, Subject } from 'rxjs';
import { takeUntil, tap, map } from 'rxjs/operators';
import { ComponentService } from '../component.service';

@Component({
    selector: 'app-kullanici-select',
    templateUrl: './kullanici-select.component.html'
})

export class KullaniciSelectComponent implements OnInit, OnDestroy {

    @Input() parentFormGroup: FormGroup;
    @Input() controlName: string;
    private _unsubscribeAll = new Subject();
    _kullanicilar: Select[] = [];

    compareKullanici = compareEnumKeys;
    constructor(private _cService: ComponentService, private _cd: ChangeDetectorRef) {
    }

    ngOnInit() {
        this.loadKullaniciSelect();
    }
    loadKullaniciSelect(): void {
        this._cService.getirKullaniciListesi().pipe(
            takeUntil(this._unsubscribeAll)
        ).subscribe(data => {
            this._kullanicilar = data;
            console.log(this._kullanicilar);
        });
    }
    ngOnDestroy() {
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }
}
