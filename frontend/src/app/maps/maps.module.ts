import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';

import { DxSelectBoxModule, DxCheckBoxModule } from 'devextreme-angular';

import { MapComponent } from './maps.component';
import { MapService } from './maps.service';

import { YmapsModule } from '@shared/ymaps/ymaps.module';
import { MapRoutingModule } from './maps-routing.module';

@NgModule({
  imports: [
    CommonModule,
    DxSelectBoxModule,
    DxCheckBoxModule,
    HttpClientModule,
    YmapsModule,
    MapRoutingModule
  ],
  declarations: [MapComponent],
  providers: [
    MapService,
    HttpClient
  ]
})
export class MapModule { }
