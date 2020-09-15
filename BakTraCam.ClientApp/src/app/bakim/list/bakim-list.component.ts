import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit, ElementRef } from '@angular/core';
import { BakimService } from '../bakim.service';
import { BakimModel, BakimModelBasic } from 'app/models';
import { Subject, fromEvent } from 'rxjs';
import { takeUntil, tap, map, mergeMap, filter } from 'rxjs/operators';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatDialog } from '@angular/material/dialog';
import { BakimFormPopupComponent } from '../popups/bakim-form-popup/bakim-form-popup.component';
import { SnackbarService } from 'app/shared/snackbar.service';
import { TranslateService } from '@ngx-translate/core';


@Component({
  selector: 'app-bakim-list',
  templateUrl: './bakim-list.component.html',
  styleUrls: ['./bakim-list.component.scss']
})
export class BakimListComponent implements OnInit, OnDestroy {

  loading: boolean;
  bakimListe: BakimModelBasic[];

  displayedColumns: string[] = ['Id', 'Ad', 'Aciklama', 'Tarihi',
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
    this._bakimSilAction.pipe(
      takeUntil(this._unsubscribeAll),
      mergeMap((bakimId) => this._bService.silBakim(bakimId)),
      tap((res) => {
        const msg = this._translate.instant('Bakım silindi');
          this._snackbarService.show(msg);
        this.bakimListesiniGetir();
      })
    ).subscribe();
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
  filterTableByTip(tip: number) {
    switch (tip) {
      case 0:
        this.bakimListesiniGetir();
        break;
      case 1:
        this.bakimListesiniTipFiltreliGetir(1);
        break;
      case 2:
        this.bakimListesiniTipFiltreliGetir(2);
        break;
      case 3:
        this.bakimListesiniTipFiltreliGetir(3);
        break;
      case 4:
        this.bakimListesiniTipFiltreliGetir(4);
        break;
    }
  }
  filterTableByDurum(tip: number) {
    switch (tip) {
      case 1:
        this.bakimListesiniDurumFiltreliGetir(1);
        break;
      case 2:
        this.bakimListesiniDurumFiltreliGetir(2);
        break;
      case 3:
        this.bakimListesiniDurumFiltreliGetir(3);
        break;
      case 4:
        this.bakimListesiniDurumFiltreliGetir(4);
        break;
    }
  }
  private bakimListesiniDurumFiltreliGetir(durum: number) {
    this._bService.getirBakimListesiDurumFiltreli(durum).pipe(
      takeUntil(this._unsubscribeAll),
      tap(() => this.loading = true),
      map((resListe) => {
        this.bakimListe = (resListe as BakimModelBasic[]);
        this.dataSource = new MatTableDataSource(this.bakimListe);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }),
      tap(() => this.loading = false),
    ).subscribe()
  }
  private bakimListesiniTipFiltreliGetir(tip: number) {
    this._bService.getirBakimListesiTipFiltreli(tip).pipe(
      takeUntil(this._unsubscribeAll),
      tap(() => this.loading = true),
      map((resListe) => {
        this.bakimListe = (resListe as BakimModelBasic[]);
        this.dataSource = new MatTableDataSource(this.bakimListe);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }),
      tap(() => this.loading = false),
    ).subscribe()
  }
  private bakimListesiniGetir() {
    this._bService.getirBakimListesi().pipe(
      takeUntil(this._unsubscribeAll),
      tap(() => this.loading = true),
      map((resListe) => {
        this.bakimListe = (resListe as BakimModelBasic[]);
        this.dataSource = new MatTableDataSource(this.bakimListe);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      }),
      tap(() => this.loading = false),
    ).subscribe();
  }
  createNewTask(): void {
    this.openBakimPopup({ id: 0 });
  }
  editTask(bakimId: number) {
    this.openBakimPopup({ id: bakimId });
  }
  deleteTask(bakimId: number) {
    this._bakimSilAction.next(bakimId);
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
