import { Injectable } from '@angular/core';
import { BakimModel, PostResult } from 'app/models';
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
    getirBakimListesi(): Observable<BakimModel[]> {
        return this.getOnly<BakimModel[]>('/Bakim/BakimListesiniGetir/');
    }
    kaydetBakim(bakimParam: BakimModel): Observable<PostResult> {
        return this.postValue('/Bakim/kaydetBakim', bakimParam).pipe(
            map(response => {
                return response;
            }),
            catchError((error) => {
                return of({ success: false } as PostResult);
            }),
        );
    }

}
