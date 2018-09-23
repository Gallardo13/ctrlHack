import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { filter } from 'rxjs/operators';
import { YmapsMarkerInput } from '@shared/ymaps/ymaps.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class MapService {
  private _storeMarks$: BehaviorSubject<YmapsMarkerInput[]> = new BehaviorSubject(null);
  public storeMarks$: Observable<YmapsMarkerInput[]> = this._storeMarks$
    .asObservable().pipe(
      filter(item => item !== null)
    );

  private _typeMarks$: BehaviorSubject<any> = new BehaviorSubject({});
  public typeMarks$: Observable<any> = this._typeMarks$
    .asObservable().pipe(
      filter(item => item.length !== 0)
    );

  constructor(
    private _http: HttpClient
  ) {
  }

  public fetch(year, xStart, yStart, xEnd, yEnd) {
    this._http.get(`http://geoinfo.surayfer.com/api/infrastructureobjects/${year}/${yStart}/${xStart}/${yEnd}/${xEnd}`)
      .subscribe((data: any[]) => {
        let d = data.map((item) => {
          return {
            id: item.id,
            data: item.data,
            coordinates: [item.coordinates.x, item.coordinates.y]
          };
        });

        this._storeMarks$.next(d);

        this._typeMarks$.next(this._getTypesMap(d));
      });
  }



  public getDataByTypes(types): any {
    let typeMarks = this._typeMarks$.getValue();
    let data = [];
    types.forEach((type) => {
      console.log(type);
      data = data.concat(typeMarks[type]);
    });

    return data;
  }

  private _getTypesMap(data) {
    let map = {};

    data.forEach((item) => {
      if (!map[item.data.ObjectType]) {
        map[item.data.ObjectType] = [];
      }

      map[item.data.ObjectType].push(item);
    });

    return map;
  }
}
