import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { YmapsComponent } from './ymaps.component';
import { YmapsService } from './ymaps.service';
import { YmapsHintContentComponent } from './components/ymaps-hint-content/ymaps-hint-content.component';
import { MomentModule } from 'ngx-moment';

@NgModule({
  imports: [
    CommonModule,
    MomentModule
  ],
  exports: [
    YmapsComponent
  ],
  providers: [
    YmapsService
  ],
  declarations: [
    YmapsComponent,
    YmapsHintContentComponent
  ],
  entryComponents: [
    YmapsHintContentComponent
  ]
})
export class YmapsModule { }
