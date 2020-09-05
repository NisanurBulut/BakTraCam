import { Injectable } from '@angular/core';
import { BakimModel } from 'app/models';
import { Observable } from 'rxjs';
import { BaseService } from 'app/shared/base.service';

@Injectable()
export class BakimService extends BaseService {
    getirBakimListesi(): Observable<BakimModel[]> {
        return this.getOnly<BakimModel[]>('/Bakim/BakimlistesiGetirAsync/');
    }
}
