import { Component, OnInit, AfterViewInit, ViewChild, ElementRef, Renderer2 } from '@angular/core';
import { YmapsComponent } from '@shared/ymaps/ymaps.component';
import { MapService } from './maps.service';

declare var ymaps: any;

@Component({
  selector: 'app-map',
  templateUrl: './maps.component.html',
  styleUrls: ['./maps.component.css']
})
export class MapComponent implements OnInit {

  myMap: ymaps.Map;

  types: any = {};
  keys: string[];
  year: string = '2018';

  @ViewChild('map') map: YmapsComponent
  @ViewChild('container') container: ElementRef;

  constructor(
    public service: MapService,
    private _renderer: Renderer2
  ) {

  }

  onChangeCheckbox(changes) {
    this.types[changes.element.innerText] = changes.value
    let keys = Object.keys(this.types).filter((type) => this.types[type]);
    let data = this.service.getDataByTypes(keys);
    this.map.setMarkers(data);
  }

  onChangeSelect(changes) {
    let bounds = this.map.map['_bounds'];
    this.service.fetch(changes.value, bounds[0][0], bounds[0][1], bounds[1][0], bounds[1][1]);
  }

  ngOnInit() {
    this.map.onInitMap.subscribe((component) => {
      let bounds = this.map.map['_bounds'];
      this.service.fetch(this.year, bounds[0][0], bounds[0][1], bounds[1][0], bounds[1][1]);

      this.map.map.events.add('boundschange', (e: any) => {
        let bounds = this.map.map['_bounds'];
        this.service.fetch(this.year, bounds[0][0], bounds[0][1], bounds[1][0], bounds[1][1]);
      });

      this.map.map.events.add('mousedown', (e: any) => {
        this._renderer.removeClass(this.container.nativeElement, 'open')
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

  public openMenu(event) {
    if (this.container.nativeElement.classList.contains('open')) {
      this._renderer.removeClass(this.container.nativeElement, 'open');
    } else {
      this._renderer.addClass(this.container.nativeElement, 'open');
    }
  }
}
