import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { filter } from 'rxjs/operators';
import { YmapsMarker } from './ymaps.model';

@Injectable()
export class YmapsService {
  private _scriptLoadingPromise: Promise<void>;

  private _storeMarks$: BehaviorSubject<YmapsMarker[]> = new BehaviorSubject([]);
  public storeMarks$: Observable<YmapsMarker[]> = this._storeMarks$
    .asObservable().pipe(
      filter(item => item.length !== 0)
    );

  constructor(
  ) {
  }

  public load(): Promise<void> {
    const script = document.createElement('script');
    script.type = 'text/javascript';
    script.async = false;
    script.defer = true;
    script.id = 'YaScript';
    script.src = 'https://api-maps.yandex.ru/2.1/?lang=ru_RU';

    // tslint:disable-next-line:ban-types
    this._scriptLoadingPromise = new Promise<void>((resolve: Function, reject: Function) => {
        script.onload = () => { resolve(); };
        script.onerror = (error: Event) => { reject(); };
    });

    document.body.appendChild(script);
    return this._scriptLoadingPromise;
  }

  public addMarker(marker: YmapsMarker): void {
    let data = this._storeMarks$.getValue();
    data.push(marker);
    this._storeMarks$.next(data);
  }

  public setMarkers(markers: YmapsMarker[]): void {
    this._storeMarks$.next(markers);
  }

  public getMarker(id: string): YmapsMarker {
    let data = this._storeMarks$.getValue();
    return data.find((item) => {
      return item.id === id;
    });
  }
}
