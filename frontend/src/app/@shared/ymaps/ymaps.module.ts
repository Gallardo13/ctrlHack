import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { YmapsComponent } from './ymaps.component';
import { YmapsService } from './ymaps.service';

@NgModule({
  imports: [
    CommonModule
  ],
  exports: [
    YmapsComponent
  ],
  providers: [
    YmapsService
  ],
  declarations: [
    YmapsComponent
  ]
})
export class YmapsModule { }
