import { Component, OnInit, ViewChild, ElementRef, OnDestroy } from '@angular/core';
import { YmapsService } from './ymaps.service';
import { Subject } from 'rxjs';
import { YmapsMarkerInput, YmapsMarker } from './ymaps.model';

declare var ymaps: any;

@Component({
  selector: 'app-ymaps',
  templateUrl: './ymaps.component.html',
  styleUrls: ['./ymaps.component.css']
})
export class YmapsComponent implements OnInit, OnDestroy {
  private _map: Promise<ymaps.Map>;
  private _mapResolver: (value?: ymaps.Map) => void;
  private _marks: ymaps.Placemark[] = [];

  public map: ymaps.Map;
  public onInitMap: Subject<YmapsComponent> = new Subject<YmapsComponent>();

  @ViewChild('mapContainer') mapContainer: ElementRef;

  constructor(
    private _service: YmapsService
  ) {
    this._map = new Promise<ymaps.Map>((resolve: () => void) => {
      this._mapResolver = resolve;
    });
  }

  ngOnDestroy() {
    this.map.destroy();
  }

  ngOnInit() {
    this.createMap(this.mapContainer.nativeElement, {
      center: [55.76, 37.64],
      controls: ['zoomControl'],
      zoom: 7
    });
  }

  public createMap(el: HTMLElement, mapOptions: ymaps.IMapState): Promise<void> {
    const res = this._service.load().then((e) => {
      const create = () => setTimeout(() => {
        if (ymaps.Map) {
          this.map = new ymaps.Map(el, mapOptions);
          this._mapResolver(this.map as ymaps.Map);
          this.onInitMap.next(this);
        } else {
          create();
        }
      }, 100);
      create();
    }).catch((e) => console.log(e));
    return res;
  }

  public addMarker(marker: YmapsMarkerInput): ymaps.Placemark {
    if (!this.map) {
      return;
    }

    let placemark = new ymaps.Placemark(marker.coordinates);
    this.map.geoObjects.add(placemark);

    this._service.addMarker({
      id: marker.id,
      marker: placemark,
      data: marker.data
    });

    return placemark;
  }

  public setMarkers(markers: YmapsMarkerInput[]): void {
    if (!this.map) {
      return;
    }
    this.map.geoObjects.removeAll();
    let objects = [];

    this._service.setMarkers(markers.map((marker) => {
      let placemark = new ymaps.GeoObject({
        geometry: {
          type: 'Point',
          coordinates: marker.coordinates
        },
        properties: {
          clusterCaption: 'Адрес',
          balloonContentBody: 'Контент'
        }
      });

      placemark.properties.events.add("hintopen", (e) => {
        console.log(e);
      });

      objects.push(placemark);

      return {
        id: marker.id,
        marker: new ymaps.Placemark(marker.coordinates),
        data: marker.data
      };
    }));
    let cluster = new ymaps.Clusterer(
      {clusterDisableClickZoom: true}
    );

    cluster.events.add("balloonopen", (e) => {
      console.log(e);
    });

    cluster.add(objects);
    this.map.geoObjects.add(cluster);
  }

  public getMarker(id: string): YmapsMarker {
    return this._service.getMarker(id);
  }
}
