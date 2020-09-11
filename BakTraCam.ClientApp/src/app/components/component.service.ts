import { Injectable } from '@angular/core';
import { BaseService } from 'app/shared/base.service';
import { Observable, of } from 'rxjs';
import { Select } from 'app/models';

@Injectable()
export class ComponentService extends BaseService {

    getirKullaniciListesi(): Observable<Select[]> {
        debugger;
        return this.getOnly<Select[]>('/Ortak/KullaniciListesiniGetir/');
    }

}
