import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { filter } from 'rxjs/operators';
import { YmapsMarker, YmapsMarkerInput } from '@shared/ymaps/ymaps.model';
import { HttpResponse, HttpClient } from '@angular/common/http';

@Injectable()
export class AppService {

  private _storeMarks$: BehaviorSubject<YmapsMarkerInput[]> = new BehaviorSubject([]);
  public storeMarks$: Observable<YmapsMarkerInput[]> = this._storeMarks$
    .asObservable().pipe(
      filter(item => item.length !== 0)
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
    console.log(`http://geoinfo.surayfer.com/api/infrastructureobjects/${year}/${yStart}/${xStart}/${yEnd}/${xEnd}`);
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
    console.log(arguments);

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

  public data = [
    {
      coordinates: [55.8, 37.8],
      id: "1",
      data: {
        type: "Магазины"
      }
    },
    {
      coordinates: [55.84, 37.86],
      id: "11",
      data: {
        type: "Магазины"
      }
    },
    {
      coordinates: [55.82, 37.83],
      id: "111",
      data: {
        type: "Магазины"
      }
    },
    {
      coordinates: [55.7, 37.8],
      id: "2",
      data: {
        type: "Кафе"
      }
    },
    {
      coordinates: [55.9, 37.8],
      id: "3",
      data: {
        type: "Школы"
      }
    },
    {
      coordinates: [55.8, 38.7],
      id: "4",
      data: {
        type: "Бизнес-центры"
      }
    },
    {
      coordinates: [56.8, 37.9],
      id: "5",
      data: {
        type: "Университеты"
      }
    }
  ]

}
