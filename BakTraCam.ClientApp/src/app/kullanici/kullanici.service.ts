import { Injectable } from '@angular/core';
import { BaseService } from 'app/shared/base.service';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { KullaniciModel } from 'app/models/kullanici.model';
import { PostResult } from 'app/models';

@Injectable()
export class KullaniciService extends BaseService {

    getirKullanici(kullaniciId: number): Observable<KullaniciModel> {
        return this.getOnly<KullaniciModel>('/Kullanici/KullaniciGetir/');
    }
    getirKullaniciListesi(): Observable<KullaniciModel[]> {
        return this.getOnly<KullaniciModel[]>('/Kullanici/KullaniciListesiniGetir/');
    }
    kaydetKullanici(kullaniciParam: KullaniciModel): Observable<PostResult> {
        return this.postValue('/Kullanici/KaydetKullanici', kullaniciParam).
        pipe(
            map(response => {
                return response;
            }),
            catchError((error) => {
                return of({ success: false } as PostResult);
            }),
        );
    }

}
