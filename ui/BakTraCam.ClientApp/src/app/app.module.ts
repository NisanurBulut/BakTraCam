import { APP_BASE_HREF, DatePipe, registerLocaleData } from '@angular/common';
import localTr from '@angular/common/locales/tr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LOCALE_ID, NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';


import { AppRoutingModule } from './app.routing';
import { ComponentsModule } from './components/components.module';

import { AppComponent } from './app.component';
import 'hammerjs';
import { AdminLayoutComponent } from './layouts/admin-layout/admin-layout.component';
import { MaterialModule } from './shared/material.module';
import { BaseCommonModule } from './shared/baseCommon.module';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { SnackbarService } from './shared/snackbar.service';
import { FuseTranslationLoaderService } from './shared/translation-loader.service';
import { TranslateModule } from '@ngx-translate/core';
import { BaseService } from './shared/base.service';
import { MatIconRegistry } from '@angular/material/icon';
registerLocaleData(localTr);
@NgModule({
  imports: [
    BrowserAnimationsModule,
    MatSnackBarModule,
    FormsModule,
    ReactiveFormsModule,
    ComponentsModule,
    RouterModule,
    AppRoutingModule,
    MaterialModule,
    BaseCommonModule,
    TranslateModule.forRoot()
  ],
  declarations: [
    AppComponent,
    AdminLayoutComponent
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'tr-TR' },
    { provide: APP_BASE_HREF, useValue: '/' },
    BaseService,
    SnackbarService,
    FuseTranslationLoaderService
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(
    public matIconRegistry: MatIconRegistry
) {
    matIconRegistry.registerFontClassAlias('fontawesome', 'fa');
}

}
