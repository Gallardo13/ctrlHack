import { Component, OnInit, Input } from '@angular/core';
@Component({
  selector: 'app-ymaps-hint-content',
  templateUrl: './ymaps-hint-content.component.html',
  styleUrls: ['./ymaps-hint-content.component.css'],
})
export class YmapsHintContentComponent {
  @Input() value = {};

  constructor(
  ) {
  }



}
