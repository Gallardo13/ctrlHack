import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { MapModule } from './maps/maps.module';
import { MomentModule } from 'ngx-moment';

import {
	DxSelectBoxModule,
	DxTextAreaModule,
	DxDateBoxModule,
  DxFormModule,
  DxButtonModule,
  DxDataGridModule,
  DxBulletModule,
  DxTemplateModule,
} from 'devextreme-angular';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { AppService } from './app.service';
import { WelcomeComponent } from './welcome/welcome.component';
import { InfoComponent } from './info/info.component';

@NgModule({
  declarations: [
    AppComponent,
    WelcomeComponent,
    InfoComponent,
  ],
  imports: [
    BrowserModule,
    CommonModule,
    MapModule,
    HttpClientModule,
    AppRoutingModule,
    DxSelectBoxModule,
    DxTextAreaModule,
    DxDateBoxModule,
    DxFormModule,
    DxButtonModule,
    DxDataGridModule,
    DxBulletModule,
    DxTemplateModule,
    MomentModule
  ],
  providers: [
    AppService,
    HttpClient
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
