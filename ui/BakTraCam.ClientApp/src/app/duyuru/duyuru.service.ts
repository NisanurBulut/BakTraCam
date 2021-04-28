import { Injectable } from '@angular/core';
import { BaseService } from 'app/shared/base.service';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';
import { DuyuruModel, PostResult } from 'app/models';

@Injectable()
export class DuyuruService extends BaseService {

    getirDuyuru(duyuruId: number): Observable<DuyuruModel> {
        return this.getOnly<DuyuruModel>('/Ortak/DuyuruGetir?id=' + duyuruId);
    }
    getirDuyuruListesi(): Observable<DuyuruModel[]> {
        return this.getOnly<DuyuruModel[]>('/Ortak/DuyuruListesiniGetir/');
    }
    silDuyuru(duyuruId: number): Observable<PostResult> {
        return this.deleteValue('/Ortak/SilDuyuru?id=' + duyuruId).pipe(
            map((response: PostResult) => {
                return response;
            }),
            catchError((error) => {
                return of({ success: false } as PostResult);
            }),
        );
    }
    kaydetDuyuru(DuyuruParam: DuyuruModel): Observable<PostResult> {
        return this.postValue('/Ortak/KaydetDuyuru', DuyuruParam).
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
