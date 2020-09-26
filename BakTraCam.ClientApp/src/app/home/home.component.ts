import { Component, OnInit } from '@angular/core';
import { BakimService } from 'app/bakim';
import { BakimDurum, BakimModelBasic, BakimTip } from 'app/models';
import { Subject } from 'rxjs';
import { map, takeUntil, tap } from 'rxjs/operators';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  loading: boolean;
  bakimListe: BakimModelBasic[];
  BakimTip = BakimTip;
  bakimDurum = BakimDurum;
  private _unsubscribeAll: Subject<any> = new Subject();
  constructor(private _bService: BakimService) {
    this._bService.getirOnBesGunYaklasanBakimListesi().pipe(
      takeUntil(this._unsubscribeAll),
      tap(() => this.loading = true),
      map((resListe) => {
        this.bakimListe = (resListe as BakimModelBasic[]);
        console.log(this.bakimListe);
      }),
      tap(() => this.loading = false),
    ).subscribe();
  }

  ngOnInit() {

  }

}
