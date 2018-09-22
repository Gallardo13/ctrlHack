import { Component, OnInit, AfterViewInit, ViewChild } from '@angular/core';
import { YmapsComponent } from '@shared/ymaps/ymaps.component';
import { AppService } from './app.service';

declare var ymaps: any;

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  myMap: ymaps.Map;

  types: any = {};
  keys: string[];

  @ViewChild('map') map: YmapsComponent

  constructor(
    public service: AppService
  ) {

  }

  onChangeCheckbox(changes) {
    this.types[changes.element.innerText] = changes.value
    let keys = Object.keys(this.types).filter((type) => this.types[type]);
    let data = this.service.getDataByTypes(keys);
    this.map.setMarkers(data);
  }

  ngOnInit() {
    this.map.onInitMap.subscribe((component) => {
      let bounds = this.map.map['_bounds'];
      this.service.fetch('2018', bounds[0][0], bounds[0][1], bounds[1][0], bounds[1][1]);

      this.map.map.events.add('boundschange', (e: any) => {
        let bounds = this.map.map['_bounds'];
        this.service.fetch('2018', bounds[0][0], bounds[0][1], bounds[1][0], bounds[1][1]);
      });

      this.map.map.events.add('mousedown', (e: any) => {
        console.log(e);
      });

      this.service.storeMarks$.subscribe((data) => {
        component.setMarkers(data);
      });

      this.service.typeMarks$.subscribe((data) => {
        let keys = Object.keys(data);
        keys.forEach((key) => {
          this.types[key] = true;
        })

        this.keys = keys;

      });
    });
  }

  public getRandomColor(): string {
    var letters = '0123456789ABCDEF';
    var color = '#';
    for (var i = 0; i < 6; i++) {
      color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
  }

}
