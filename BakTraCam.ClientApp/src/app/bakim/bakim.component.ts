import { Component, OnInit, OnDestroy, ViewChild, AfterViewInit } from '@angular/core';
import { BakimService } from './bakim.service';
import { BakimModel } from 'app/models';
import { Subject } from 'rxjs';
import { takeUntil, tap, map } from 'rxjs/operators';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';

@Component({
  selector: 'app-bakim',
  templateUrl: './bakim.component.html',
  styleUrls: ['./bakim.component.scss']
})
export class BakimComponent implements OnInit, OnDestroy, AfterViewInit {

  loading: boolean;
  bakimListe: BakimModel[];

  displayedColumns: string[] = ['id', 'aciklama', 'actions'];
  dataSource: MatTableDataSource<BakimModel>;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;
  private _unsubscribeAll: Subject<any> = new Subject();

  constructor(private _bService: BakimService) {
    this.bakimListesiniGetir();
  }
  ngOnInit() {

  }
  ngAfterViewInit() {
    // this.dataSource.paginator = this.paginator;
    // this.dataSource.sort = this.sort;
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
    this._bService.getirBakimListesi().pipe(
      takeUntil(this._unsubscribeAll),
      tap(() => this.loading = true),
      map((resListe) => {
        this.bakimListe = (resListe as BakimModel[]);
        console.log(this.bakimListe);
        this.dataSource = new MatTableDataSource(this.bakimListe);
console.log(this.dataSource.data);
      }),
      tap(() => this.loading = false),
    ).subscribe()
  }
}
