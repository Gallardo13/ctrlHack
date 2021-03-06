import { Component, OnInit, ViewChild, Injector, ElementRef,
  ComponentRef, OnDestroy, ComponentFactoryResolver, ViewContainerRef
} from '@angular/core';

import { YmapsService } from './ymaps.service';
import { Subject } from 'rxjs';
import { YmapsMarkerInput, YmapsMarker } from './ymaps.model';
import { YmapsHintContentComponent } from './components/ymaps-hint-content/ymaps-hint-content.component';

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
  private componentRef: ComponentRef<any>;

  public map: ymaps.Map;
  public onInitMap: Subject<YmapsComponent> = new Subject<YmapsComponent>();

  @ViewChild('mapContainer') mapContainer: ElementRef;
  @ViewChild('contentContainer', {read: ViewContainerRef}) contentContainer: ViewContainerRef;

  constructor(
    private _componentFactoryResolver: ComponentFactoryResolver,
    private _service: YmapsService,
    private injector: Injector,
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
      let data = marker.data;
      const componentFactory = this._componentFactoryResolver.resolveComponentFactory(YmapsHintContentComponent);
      this.componentRef = this.contentContainer.createComponent(componentFactory);
      data.FinishDate = new Date(data.FinishDate);
      data.StartDate = new Date(data.StartDate);
      this.componentRef.instance.value = data;
      this.componentRef.instance.Id = marker.id;
      this.componentRef.changeDetectorRef.detectChanges()

      let div = document.createElement('div');
      div.appendChild(this.componentRef.location.nativeElement);
      let color = 'twirl#blueIcon';
      if (data.isObjectHaveBadReviews) {
        color = 'twirl#redIcon';
      }
      let placemark = new ymaps.GeoObject({
        geometry: {
          type: 'Point',
          coordinates: marker.coordinates,
        },
        properties: {
          clusterCaption: '<b>' + data.ObjectType + '</b><br />' + data.Address,
          balloonContentBody: div.innerHTML,
        },
        options: {
          fillColor: "#ff0000"
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

    });

    cluster.add(objects);
    this.map.geoObjects.add(cluster);
  }

  public getMarker(id: string): YmapsMarker {
    return this._service.getMarker(id);
  }
}
