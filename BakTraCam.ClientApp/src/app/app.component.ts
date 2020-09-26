import { Component, Inject } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';
import { FuseTranslationLoaderService } from './shared/translation-loader.service';
import { locale as turkish } from 'i18n/tr';
import { DOCUMENT } from '@angular/common';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private _fuseTranslationLoaderService: FuseTranslationLoaderService,
    private _translateService: TranslateService) {
    this._translateService.addLangs(['tr']);
    this._translateService.setDefaultLang('tr');
    this._fuseTranslationLoaderService.loadTranslations(turkish);
    this._translateService.use('tr');
  }
}
