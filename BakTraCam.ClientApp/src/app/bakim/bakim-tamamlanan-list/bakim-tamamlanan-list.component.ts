import { Component, OnInit, OnDestroy, ViewChild, ElementRef } from '@angular/core';
import { BakimService } from '../bakim.service';
import { BakimDurum, BakimModelBasic } from 'app/models';
import { Subject} from 'rxjs';
import { takeUntil, tap, map, mergeMap, filter } from 'rxjs/operators';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';

import { SnackbarService } from 'app/shared/snackbar.service';
import { TranslateService } from '@ngx-translate/core';
import { BakimDetailPopupComponent, BakimFormPopupComponent } from '../popups';


@Component({
  selector: 'app-bakim-tamamlanan-list',
  templateUrl: './bakim-tamamlanan-list.component.html',
  styleUrls: ['./bakim-tamamlanan-list.component.scss']
})
export class BakimTamamlananListComponent implements OnInit, OnDestroy {

  loading: boolean;
  bakimListe: BakimModelBasic[];

  displayedColumns: string[] = ['Id', 'Ad', 'Tarihi',
    'Sorumlu1', 'Sorumlu2', 'Gerceklestiren1',
    'Gerceklestiren2', 'Gerceklestiren3',
    'Gerceklestiren4', 'Actions'];
  dataSource: MatTableDataSource<BakimModelBasic>;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  @ViewChild('filter', { static: true })
  filter: ElementRef;

  private _unsubscribeAll: Subject<any> = new Subject();
  private _bakimSilAction = new Subject<number>();

  constructor(private _bService: BakimService,
    private _dialog: MatDialog,
    private _snackbarService: SnackbarService,
    private _translate: TranslateService) {
    this.bakimListesiniGetir();
  }
  ngOnInit() {
  }

  ngOnDestroy() {
    this._unsubscribeAll.unsubscribe();
  }
  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  private bakimListesiniGetir() {
    this._bService.getirBakimListesiDurumFiltreli(BakimDurum.Tamamlandi).pipe(
      takeUntil(this._unsubscribeAll),
      tap(() => this.loading = true),
      map((resListe) => {
        this.bakimListe = (resListe as BakimModelBasic[]);
        console.log(this.bakimListe);
        this.dataSource = new MatTableDataSource(this.bakimListe);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }),
      tap(() => this.loading = false),
    ).subscribe();
  }
  viewTask(bakimId: number) {
    this.openBakimDetailPopup({ id: bakimId });
  }

  openBakimDetailPopup(data: any): void {
    this._dialog.open(BakimDetailPopupComponent, {
      disableClose: true,
      panelClass: 'form-dialog',
      data: data
    }).afterClosed().pipe(
      takeUntil(this._unsubscribeAll)
    ).subscribe((res) => {
      if (res) {
        this.bakimListesiniGetir();
      }
    });
  }
  openBakimPopup(data: any): void {
    this._dialog.open(BakimFormPopupComponent, {
      disableClose: true,
      panelClass: 'form-dialog',
      data: data
    }).afterClosed().pipe(
      takeUntil(this._unsubscribeAll)
    ).subscribe((res) => {
      if (res) {
        this.bakimListesiniGetir();
      }
    });
  }
}
