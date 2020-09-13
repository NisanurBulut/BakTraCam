import { ChangeDetectorRef, Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { MatOption } from '@angular/material/core';
import { MatSelectChange } from '@angular/material/select';
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

    @Output() kullaniciChange = new EventEmitter();
    selectedKullanici: Select = {
        Key: 0,
        Group: '',
        Name: ''
    };
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
        });
    }
    ngOnDestroy() {
        this._unsubscribeAll.next();
        this._unsubscribeAll.complete();
    }
    public onChangeKullaniciSelect(_event: MatSelectChange): void {
        this.selectedKullanici.Name = (_event.source.selected as MatOption).viewValue;
        this.selectedKullanici.Key = _event.source.value;
        this.kullaniciChange.emit(this.selectedKullanici);

    }
}
