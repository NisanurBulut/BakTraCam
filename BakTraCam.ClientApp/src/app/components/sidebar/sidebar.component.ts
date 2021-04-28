import { Component, OnInit } from '@angular/core';

declare const $: any;
declare interface RouteInfo {
  path: string;
  title: string;
  icon: string;
  class: string;
}
export const ROUTES: RouteInfo[] = [
  { path: '/home', title: 'Anasayfa', icon: 'home', class: '' },
  { path: '/bakim', title: 'Bakım Ekranı', icon: 'build', class: '' },
  { path: '/tamamlananbakim', title: 'Tamamlanan Bakımlar', icon: 'directions_run', class: '' },
  { path: '/kullanici', title: 'Kullanicilar', icon: 'supervisor_account', class: '' },
  { path: '/duyuru', title: 'Duyurular', icon: 'campaign', class: '' }
];

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.css']
})
export class SidebarComponent implements OnInit {
  menuItems: any[];

  constructor() { }

  ngOnInit() {
    this.menuItems = ROUTES.filter(menuItem => menuItem);
  }
  isMobileMenu() {
    if ($(window).width() > 991) {
      return false;
    }
    return true;
  };
}
