import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';

import { DxSelectBoxModule, DxCheckBoxModule } from 'devextreme-angular';

import { AppComponent } from './app.component';
import { YmapsModule } from '@shared/ymaps/ymaps.module';
import { AppService } from './app.service';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    YmapsModule,
    DxSelectBoxModule,
    DxCheckBoxModule,
    HttpClientModule
  ],
  providers: [
    AppService,
    HttpClient
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
