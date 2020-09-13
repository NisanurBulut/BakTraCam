import { Injectable } from '@angular/core';
import { BakimModel, BakimModelBasic, PostResult } from 'app/models';
import { map, catchError } from 'rxjs/operators';
import { of } from 'rxjs/internal/observable/of';
import { Observable } from 'rxjs/Observable';
import { HttpParams } from '@angular/common/http';
import { BaseService } from 'app/shared/base.service';

@Injectable()
export class BakimService extends BaseService {
    getirBakim(bakimId: number): Observable<BakimModel> {
        return this.getOnly<BakimModel>('/Bakim/BakimGetir/');
    }
    silBakim(bakimId: number): Observable<PostResult> {
        return this.deleteValue('/Bakim/SilBakim?id=' + bakimId).pipe(
            map((response: PostResult) => {
                console.log(response)
                return response;
            }),
            catchError((error) => {
                return of({ success: false } as PostResult);
            }),
        );
    }
    getirBakimListesi(): Observable<BakimModelBasic[]> {
        return this.getOnly<BakimModelBasic[]>('/Bakim/BakimListesiniGetir/');
    }
    kaydetBakim(bakimParam: BakimModel): Observable<PostResult> {
        return this.postValue('/Bakim/KaydetBakim', bakimParam).pipe(
            map((response: PostResult) => {
                return response;
            }),
            catchError((error) => {
                return of({ success: false } as PostResult);
            }),
        );
    }

}
