import { ChangeDetectorRef, Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, FormGroupName, Validators } from '@angular/forms';
import { MatOption } from '@angular/material/core';
import { MatSelectChange } from '@angular/material/select';
import { compareEnumKeys } from 'app/common';
import { Select } from 'app/models';
import { Subject } from 'rxjs';
import { takeUntil, tap, map } from 'rxjs/operators';
import { ComponentService } from '../component.service';

@Component({
    selector: 'app-kullanici-select',
    templateUrl: './kullanici-select.component.html'
})

export class KullaniciSelectComponent implements OnInit, OnDestroy {

    @Input() parentFormGroup: FormGroup;
    @Input() controlName: string;
    @Input() labelName: string;

    @Output() kullaniciChange = new EventEmitter();
    selectedKullanici: Select = {
        Key: 0,
        Group: '',
        Name: ''
    };

    private _unsubscribeAll = new Subject();
    _kullanicilar: Select[] = [];
    kullaniciKontrol = new FormControl('', [Validators.required]);
    compareKullanici = compareEnumKeys;
    constructor(private _cService: ComponentService, private _cd: ChangeDetectorRef, private formBuilder:FormBuilder) {
        this.loadKullaniciSelect();
    }

    ngOnInit() {
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
